using Helper;
using Microsoft.Win32;
using Expandit.Models;
using Expandit.Services;
using Expandit.View;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Text;
using WindowsInput.Native;
using WindowsInput;
using Expandit.Data;
using Expandit.Helpers;
using System.Diagnostics;
using static Expandit.Data.GlobalVariables;

namespace Expandit;

public partial class MainWindow : Form
{
    #region Unmanaged (user32.dll) code import

    [DllImport("user32.dll")]
    static extern IntPtr GetForegroundWindow();

    [DllImport("user32.dll")]
    static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);

    [DllImport("user32.dll")]
    static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint processId);

    const int VK_BACKSPACE = 0x08;
    const int WM_KEYDOWN = 0x0100;
    const int WM_KEYUP = 0x0101;

    KeyHelper kh = new KeyHelper();

    #endregion

    private bool ctrl, shift, alt;
    private bool isApplicationDisabled = false;
    private string currentText = string.Empty;
    private volatile bool _isExpanding = false;

    private List<TextShortcut> textShortcuts;
    private TextShortcutsService _textShortcutService;
    private StatisticsService _statsService;
    private Trie<TextShortcut> _shortcutTrie = new Trie<TextShortcut>();

    private NotifyIcon notifyIcon;
    private ContextMenuStrip contextMenuStrip;

    public MainWindow()
    {
        InitializeComponent();

        _textShortcutService = new();
        _statsService = new();
        UpdateInMemoryTextShortcuts();

        PopulateDataGrid();

        InitializeNotifyIcon();
        AddApplicationToStartup();

        InitializeForegroundWindowChecker();

        kh.KeyDown += Kh_KeyDown;
        kh.KeyUp += Kh_KeyUp;

        LoadAppLogo();
    }

    private void LoadAppLogo()
    {
        try
        {
            string fullPath = System.IO.Path.Combine(Application.StartupPath, LOGO_NAME);
            if (System.IO.File.Exists(fullPath))
            {
                // Set form icon from png
                using (Bitmap bmp = new Bitmap(fullPath))
                {
                    IntPtr hIcon = bmp.GetHicon();
                    try
                    {
                        using (Icon icon = Icon.FromHandle(hIcon))
                        {
                            this.Icon = (Icon)icon.Clone();
                            if (notifyIcon != null)
                            {
                                notifyIcon.Icon = (Icon)icon.Clone();
                            }
                        }
                    }
                    finally
                    {
                        DestroyIcon(hIcon);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Failed to load logo: {ex.Message}");
        }
    }

    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    extern static bool DestroyIcon(IntPtr handle);

    private void MainWindow_Load(object sender, EventArgs e)
    {
        // NOT SHOWS THE WINDOW IN STARTUP
        this.Hide();
        this.ShowInTaskbar = false;
    }

    // *****************************************************************************************************//
    #region EXPIRIMENTAL - - - CustomForegroundWindowChanged Event


    [DllImport("user32.dll")]
    private static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

    [DllImport("user32.dll")]
    private static extern int GetWindowTextLength(IntPtr hWnd);

    private System.Windows.Forms.Timer _timer;
    private IntPtr _lastForegroundWindow = IntPtr.Zero;

    private void InitializeForegroundWindowChecker()
    {
        _timer = new System.Windows.Forms.Timer();
        _timer.Interval = 1000; // Check every second
        _timer.Tick += Timer_Tick;
        _timer.Start();
    }

    private void Timer_Tick(object sender, EventArgs e)
    {
        IntPtr currentForegroundWindow = GetForegroundWindow();

        if (currentForegroundWindow != _lastForegroundWindow)
        {
            _lastForegroundWindow = currentForegroundWindow;

            int length = GetWindowTextLength(currentForegroundWindow);
            StringBuilder stringBuilder = new StringBuilder(length + 1);
            GetWindowText(currentForegroundWindow, stringBuilder, stringBuilder.Capacity);

            string windowTitle = stringBuilder.ToString();

            // Handle the foreground window change
            OnForegroundWindowChanged(windowTitle);
        }
    }

    private void OnForegroundWindowChanged(string windowTitle)
    {
        // Handle the foreground window change event
        currentText = string.Empty;
        currentTextLabel.Text = string.Empty;
        //MessageBox.Show($"Foreground window changed to: {windowTitle}", "Foreground Window Changed");
    }

    private string GetActiveProcessName()
    {
        IntPtr hwnd = GetForegroundWindow();
        if (hwnd == IntPtr.Zero) return "Unknown";
        uint pid;
        GetWindowThreadProcessId(hwnd, out pid);
        try
        {
            using (var proc = Process.GetProcessById((int)pid))
            {
                return proc.ProcessName;
            }
        }
        catch { return "Unknown"; }
    }
    #endregion
    // *****************************************************************************************************//


    #region NotifyIcon


    private void InitializeNotifyIcon()
    {
        notifyIcon = new NotifyIcon();

        string brandIconPath = Path.Combine(Application.StartupPath, LOGO_NAME);

        if (File.Exists(brandIconPath))
        {
            using (Bitmap bmp = new Bitmap(brandIconPath))
            {
                notifyIcon.Icon = Icon.FromHandle(bmp.GetHicon());
            }
        }
        else
        {
            string iconPath = Path.Combine(Application.StartupPath, "icon.ico");
            if (File.Exists(iconPath))
            {
                notifyIcon.Icon = new Icon(iconPath);
            }
        }


        notifyIcon.Visible = true;

        notifyIcon.Text = GlobalVariables.APP_NAME;


        ToolStripMenuItem menuItemOpen = new ToolStripMenuItem("Open", null, onClick: (s, e) => ShowMainWindow());
        ToolStripMenuItem menuItemExit = new ToolStripMenuItem("Exit", null, onClick: (s, e) => ExitApplication());
        ToolStripSeparator toolStripSeparator = new ToolStripSeparator();
        ToolStripMenuItem menuItemEnable = new ToolStripMenuItem("Enable", null, onClick: (s, e) => EnableApplication());
        ToolStripMenuItem menuItemDisable = new ToolStripMenuItem("Disable", null, onClick: (s, e) => DisableApplication());

        // Initialize ContextMenu
        contextMenuStrip = new ContextMenuStrip();
        contextMenuStrip.Items.Add(menuItemEnable);
        contextMenuStrip.Items.Add(menuItemDisable);
        contextMenuStrip.Items.Add(toolStripSeparator);
        contextMenuStrip.Items.Add(menuItemOpen);
        contextMenuStrip.Items.Add(menuItemExit);

        CheckStateOfContextMenuStripButtons();

        contextMenuStrip.Font = new Font("Segoe", 10, FontStyle.Regular);

        notifyIcon.ContextMenuStrip = contextMenuStrip;
        // Handle events
        this.FormClosing += MainForm_FormClosing;
        notifyIcon.DoubleClick += (s, e) => ShowMainWindow();
    }
    private void CheckStateOfContextMenuStripButtons()
    {
        if (isApplicationDisabled)
        {
            // menuItemEnable
            contextMenuStrip.Items[0].Visible = true;
            // menuItemDisable
            contextMenuStrip.Items[1].Visible = false;
        }
        else
        {
            // menuItemEnable
            contextMenuStrip.Items[0].Visible = false;
            // menuItemDisable
            contextMenuStrip.Items[1].Visible = true;
        }
    }
    private void EnableApplication()
    {
        isApplicationDisabled = false;
        CheckStateOfContextMenuStripButtons();
    }
    private void DisableApplication()
    {
        isApplicationDisabled = true;
        CheckStateOfContextMenuStripButtons();

    }

    private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (e.CloseReason == CloseReason.UserClosing)
        {
            e.Cancel = true;
            this.Hide();
            notifyIcon.Visible = true;
        }
    }

    private void ShowMainWindow()
    {
        this.Show();
        this.WindowState = FormWindowState.Normal;
        this.ShowInTaskbar = true;
    }

    private void ExitApplication()
    {
        notifyIcon.Visible = false;
        _statsService?.Dispose();
        Application.Exit();
    }

    #endregion

    #region DataGrid Interactions
    private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {

        // Handle for Edit button
        if (e.RowIndex >= 0 && e.ColumnIndex == dataGridView.Columns["buttonEditInCell"].Index)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                var selectedShortcut = dataGridView.SelectedRows[0].DataBoundItem as TextShortcut;

                if (selectedShortcut != null)
                {
                    buttonEditTextShortcut_Click(selectedShortcut);
                }
            }
            else
            {
                MessageBox.Show("Please select an item from the table.");
            }
        }

        // Handle for Delete button
        if (e.RowIndex >= 0 && e.ColumnIndex == dataGridView.Columns["buttonDeleteInCell"].Index)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                var selectedShortcut = dataGridView.SelectedRows[0].DataBoundItem as TextShortcut;

                if (selectedShortcut != null)
                {
                    buttonDeleteTextShortcut_Click(selectedShortcut);
                }
            }
            else
            {
                MessageBox.Show("Please select an item from the table.");
            }
        }

    }
    #endregion


    #region KeyboardListeners


    static void SendKey(int keyCode)
    {
        IntPtr hwnd = GetForegroundWindow();
        SendMessage(hwnd, WM_KEYDOWN, (IntPtr)keyCode, IntPtr.Zero);
        SendMessage(hwnd, WM_KEYUP, (IntPtr)keyCode, IntPtr.Zero);
    }
    private void Kh_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
    {
        if (e.KeyCode == Keys.LControlKey || e.KeyCode == Keys.RControlKey) ctrl = false;
        if (e.KeyCode == Keys.LShiftKey || e.KeyCode == Keys.RShiftKey) shift = false;
        if (e.KeyCode == Keys.Alt) alt = false;
    }

    private void Kh_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
    {
        if (_isExpanding) return;

        // Record keypress for statistics
        string activeApp = GetActiveProcessName();
        _statsService?.RecordKeypress(activeApp);

        if (isApplicationDisabled)
        {
            return;
        }

        if (e.KeyCode == Keys.LControlKey || e.KeyCode == Keys.RControlKey) ctrl = true;
        if (e.KeyCode == Keys.LShiftKey || e.KeyCode == Keys.RShiftKey) shift = true;
        if (e.KeyCode == Keys.Alt) alt = true;

        if (e.KeyCode == Keys.Back && currentText.Length > 0)
        {
            currentText = currentText.Substring(0, currentText.Length - 1);
            currentTextLabel.Text = currentTextLabel.Text.Substring(0, currentTextLabel.Text.Length - 1);
            return;
        }

        if (ctrl || alt) return;

        if (KeyAdjuster.IsTriggerKey(e.KeyCode))
        {
            var textShortcutModel = GetTextShortcutModel(currentText);
            if (textShortcutModel != null)
            {
                ReplaceKeyWithValue(textShortcutModel);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }

            currentText = string.Empty;
            currentTextLabel.Text = string.Empty;
            return;
        }

        if (KeyAdjuster.IsSpecialKey(e.KeyCode))
        {
            return;
        }

        var adjustedKey = KeyAdjuster.AdjustPressedKey(e.KeyCode, shift);
        if (adjustedKey == string.Empty)
        {
            currentText += e.KeyCode.ToString();
            currentTextLabel.Text += e.KeyCode.ToString();
        }
        else
        {
            currentText += adjustedKey;
            currentTextLabel.Text += adjustedKey;
        }

    }

    private void ReplaceKeyWithValue(TextShortcut shortcutModel)
    {
        _isExpanding = true;
        try
        {
            // 1. Record stats
            int charsSaved = shortcutModel.Value.Length - shortcutModel.Key.Length;
            _statsService.RecordExpansion(charsSaved > 0 ? charsSaved : 0);

            // 2. Backup clipboard
            ClipboardHelpers.BackupClipboard();

            var sim = new InputSimulator();

            // 3. Deletion - Use atomic input if possible
            for (int i = 0; i < shortcutModel.Key.Length; i++)
            {
                sim.Keyboard.KeyPress(VirtualKeyCode.BACK);
            }

            // 4. Substitution
            Clipboard.SetText(shortcutModel.Value);
            ClipboardHelpers.PasteText();

            // 5. Restore clipboard
            ClipboardHelpers.RestoreClipboard();
        }
        finally
        {
            _isExpanding = false;
        }
    }

    #endregion


    #region DB & Memory operations

    private List<TextShortcut> GetAllTextShortcutsFromDb()
    {
        return _textShortcutService.GetAll();

    }

    private void UpdateInMemoryTextShortcuts()
    {
        textShortcuts = GetAllTextShortcutsFromDb();
        _shortcutTrie.Clear();
        foreach (var s in textShortcuts)
        {
            // We use the key as the trie key. 
            // Note: Case sensitivity is handled at lookup or by double-inserting if needed.
            _shortcutTrie.Insert(s.Key.ToLower(), s);
        }
    }

    private void PopulateDataGrid()
    {
        UpdateInMemoryTextShortcuts();

        dataGridView.DataSource = new BindingList<TextShortcut>(textShortcuts);
    }


    private TextShortcut GetTextShortcutModel(string? key)
    {
        if (string.IsNullOrEmpty(key)) return null;

        // Trie-based lookup for O(Length of Key) performance
        var match = _shortcutTrie.Search(key.ToLower());

        if (match != null)
        {
            if (Settings.Default.IsMatchingCaseSensitive)
            {
                return string.Equals(match.Key, key) ? match : null;
            }
            return match;
        }
        return null;
    }

    #endregion

    #region Handle Button Clicks
    private void buttonDeleteTextShortcut_Click(TextShortcut textShortcutToDelete)
    {
        var result = MessageBox.Show($"Are you sure to delete textshortcut : {textShortcutToDelete.Name} ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
        if (result == DialogResult.Yes)
        {
            _textShortcutService.Remove(textShortcutToDelete.Id);

            PopulateDataGrid();

            if (isSearching())
            {
                FilterDataGrid(searchBox.Text);
            }

        }
    }
    private void buttonAdd_Click(object sender, EventArgs e)
    {
        var window = new AddTextShortcutWindow();
        window.Owner = this;
        this.Opacity = 0.9;
        window.ShowDialog();
        this.Opacity = 1.0;
        PopulateDataGrid();
    }
    private void buttonEditTextShortcut_Click(TextShortcut textShortcutToEdit)
    {
        var window = new EditTextShortcutWindow(textShortcutToEdit);
        window.Owner = this;
        this.Opacity = 0.9;
        window.ShowDialog();
        this.Opacity = 1.0;
        PopulateDataGrid();
    }
    #endregion

    #region SearchEngine

    private bool isSearching()
    {
        return searchBox.Text.Length > 0;
    }

    private void comboBoxCategories_SelectedIndexChanged(object sender, EventArgs e)
    {
        FilterDataGrid(searchBox.Text);
    }
    private void searchBox_TextChanged(object sender, EventArgs e)
    {
        FilterDataGrid(searchBox.Text);
    }
    private void FilterDataGrid(string searchTerm)
    {
        searchTerm = searchTerm.Trim();

        Func<TextShortcut, bool> filterPredicate = t =>
        {
            bool result = false;
            result = result || t.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase);
            result = result || t.Key.Contains(searchTerm, StringComparison.OrdinalIgnoreCase);
            result = result || t.Value.Contains(searchTerm, StringComparison.OrdinalIgnoreCase);

            return result;
        };

        var filteredShortcuts = textShortcuts.Where(filterPredicate).ToList();

        dataGridView.DataSource = new BindingList<TextShortcut>(filteredShortcuts);
    }

    #endregion


    #region Adding & Removing to Startup Apps List

    public void AddApplicationToStartup()
    {


        try
        {
            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            registryKey.SetValue(GlobalVariables.APP_NAME, Application.ExecutablePath.ToString());

        }
        catch (Exception ex)
        {

            MessageBox.Show("An error occurred while adding the application to startup: " + ex.Message);

        }
    }

    public void RemoveApplicationFromStartup()
    {
        try
        {
            // Registry key where the application is added
            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);

            // Remove the application from the startup list
            if (registryKey.GetValue(GlobalVariables.APP_NAME) != null)
            {
                registryKey.DeleteValue(GlobalVariables.APP_NAME, false);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("An error occurred while removing the application from startup: " + ex.Message);
        }
    }
    #endregion




    #region Settins tab
    //private bool IsSettingsChanged = false;


    private void ClearAllCheckBoxes()
    {
        checkBoxEnter.Checked = false;
        checkBoxSpace.Checked = false;
        checkBoxTab.Checked = false;
        checkBoxStartup.Checked = false;
        checkBoxIsStrictMatching.Checked = false;
    }
    private void PopulateTriggerKeysCheckBoxes()
    {

        foreach (string key in Settings.Default.TriggerKeys)
        {
            switch (key)
            {
                case "Space": checkBoxSpace.Checked = true; break;
                case "Enter": checkBoxEnter.Checked = true; break;
                case "Tab": checkBoxTab.Checked = true; break;
                default: break;
            }
        }
    }

    private void AddToTriggerKeys(string triggerKey)
    {
        Settings.Default.TriggerKeys.Add(triggerKey);

    }
    private void RemoveFromTriggerKeys(string triggerKey)
    {
        Settings.Default.TriggerKeys.Remove(triggerKey);
    }
    private void SaveSettingsToMemory()
    {
        Settings.Default.Save();
    }

    private void SaveTriggerKeysSettings()
    {
        if (checkBoxEnter.Checked)
        {
            if (!Settings.Default.TriggerKeys.Contains("Enter"))
            {

                AddToTriggerKeys("Enter");
            }

        }
        else
        {
            RemoveFromTriggerKeys("Enter");
        }

        if (checkBoxSpace.Checked)
        {
            if (!Settings.Default.TriggerKeys.Contains("Space"))
            {

                AddToTriggerKeys("Space");
            }


        }
        else
        {
            RemoveFromTriggerKeys("Space");
        }

        if (checkBoxTab.Checked)
        {
            if (!Settings.Default.TriggerKeys.Contains("Tab"))
            {

                AddToTriggerKeys("Tab");
            }
        }
        else
        {
            RemoveFromTriggerKeys("Tab");
        }

        SaveSettingsToMemory();

    }



    private void PopulateOtherSettingsCheckBoxes()
    {
        checkBoxStartup.Checked = Settings.Default.IsRunOnStartup;
        checkBoxIsStrictMatching.Checked = Settings.Default.IsMatchingCaseSensitive;
    }

    private void SaveOtherSettings()
    {
        //Startup
        Settings.Default.IsRunOnStartup = checkBoxStartup.Checked;
        if (checkBoxStartup.Checked)
        {

            AddApplicationToStartup();
        }
        else
        {
            RemoveApplicationFromStartup();
        }

        // Strict Matching

        Settings.Default.IsMatchingCaseSensitive = checkBoxIsStrictMatching.Checked;

    }




    private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (tabControl.SelectedIndex == 1) // Preferences
        {
            ClearAllCheckBoxes();
            PopulateOtherSettingsCheckBoxes();
            PopulateTriggerKeysCheckBoxes();
            buttonSaveSettings.Enabled = false;
        }
        else if (tabControl.SelectedIndex == 2) // Statistics
        {
            UpdateStatisticsUI(dateTimePickerFilter.Value.ToString("yyyy-MM-dd"));
        }
    }

    private void UpdateStatisticsUI(string? filterDate = null)
    {
        var stats = _statsService.Stats;
        labelTotalExpansions.Text = $"Total Expansions: {stats.TotalExpansions:N0}";
        labelTotalCharsSaved.Text = $"Characters Saved: {stats.TotalCharactersSaved:N0}";

        // Format time saved
        double totalSeconds = stats.TotalTimeSavedSeconds;
        if (totalSeconds < 60)
            labelTotalTimeSaved.Text = $"Time Saved: {totalSeconds:F1}s";
        else if (totalSeconds < 3600)
            labelTotalTimeSaved.Text = $"Time Saved: {totalSeconds / 60:F1}m";
        else
            labelTotalTimeSaved.Text = $"Time Saved: {totalSeconds / 3600:F1}h";

        // Update Daily Grid
        dataGridStatistics.Rows.Clear();
        if (stats.DailyKeypresses != null)
        {
            var query = stats.DailyKeypresses.AsEnumerable();

            if (!string.IsNullOrEmpty(filterDate))
            {
                query = query.Where(d => d.Key == filterDate);
            }

            foreach (var dateEntry in query.OrderByDescending(d => d.Key))
            {
                foreach (var appEntry in dateEntry.Value.OrderByDescending(a => a.Value))
                {
                    dataGridStatistics.Rows.Add(dateEntry.Key, appEntry.Key, appEntry.Value.ToString("N0"));
                }
            }
        }
    }

    private void dateTimePickerFilter_ValueChanged(object sender, EventArgs e)
    {
        UpdateStatisticsUI(dateTimePickerFilter.Value.ToString("yyyy-MM-dd"));
    }

    private void btnRefreshStats_Click(object sender, EventArgs e)
    {
        UpdateStatisticsUI(dateTimePickerFilter.Value.ToString("yyyy-MM-dd"));
    }
    private void buttonSaveSettings_Click(object sender, EventArgs e)
    {
        SaveOtherSettings();
        SaveTriggerKeysSettings();

        SaveSettingsToMemory();

        MessageBox.Show("Settings are saved successfully ! ", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
    }

    private void checkBox_CheckedChanged(object sender, EventArgs e)
    {
        buttonSaveSettings.Enabled = true;
    }

    #endregion
    private void importShortcutsToolStripMenuItem_Click(object sender, EventArgs e)
    {
        using (OpenFileDialog openFileDialog = new OpenFileDialog())
        {
            openFileDialog.Filter = "JSON Files (*.json)|*.json|All Files (*.*)|*.*";
            openFileDialog.Title = "Import Shortcuts";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string importFilePath = openFileDialog.FileName;
                try
                {
                    _textShortcutService.Import(importFilePath);
                    MessageBox.Show("Shortcuts imported successfully!", "Import", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    PopulateDataGrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to import shortcuts: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }

    private void exportShortcutsToolStripMenuItem_Click(object sender, EventArgs e)
    {
        using (SaveFileDialog saveFileDialog = new SaveFileDialog())
        {
            saveFileDialog.Filter = "JSON Files (*.json)|*.json|All Files (*.*)|*.*";
            saveFileDialog.Title = "Export Shortcuts";
            saveFileDialog.DefaultExt = "json";
            saveFileDialog.AddExtension = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string exportFilePath = saveFileDialog.FileName;
                _textShortcutService.Export(exportFilePath);
                MessageBox.Show("Shortcuts exported successfully!", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }

    private void label1_Click(object sender, EventArgs e)
    {

    }

    private void label5_Click(object sender, EventArgs e)
    {

    }

    private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        Process.Start(new ProcessStartInfo("cmd", $"/c start https://www.linkedin.com/in/muxammadamin-ulmasaliyev-419198251/") { CreateNoWindow = true });
    }

    private void linkLabelGithub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        Process.Start(new ProcessStartInfo("cmd", $"/c start https://github.com/Muxammadamin-Ulmasaliyev") { CreateNoWindow = true });
    }

    private void linkLabelLeetCode_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        Process.Start(new ProcessStartInfo("cmd", $"/c start https://leetcode.com/u/MuxammadaminUlmasaliyev/") { CreateNoWindow = true });
    }

    private void linkLabelSourceCode_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        Process.Start(new ProcessStartInfo("cmd", $"/c start https://github.com/Muxammadamin-Ulmasaliyev/Expandit") { CreateNoWindow = true });
    }
}
