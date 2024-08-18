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
using System.Reflection;
using System.Resources;
using System.Windows.Forms;
using System.Drawing;

namespace Expandit;

public partial class MainWindow : Form
{
	#region Unmanaged (user32.dll) code import

	[DllImport("user32.dll")]
	static extern IntPtr GetForegroundWindow();

	[DllImport("user32.dll")]
	static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);

	const int VK_BACKSPACE = 0x08;
	const int WM_KEYDOWN = 0x0100;
	const int WM_KEYUP = 0x0101;

	KeyHelper kh = new KeyHelper();

	#endregion

	private bool ctrl, shift, alt;
	private bool isApplicationDisabled = false;
	private string currentText = string.Empty;

	private List<TextShortcutModel> textShortcuts;
	private TextShortcutsService _textShortcutService;


	private NotifyIcon notifyIcon;
	private ContextMenuStrip contextMenuStrip;


	public MainWindow()
	{
		InitializeComponent();

		kh.KeyDown += Kh_KeyDown;
		kh.KeyUp += Kh_KeyUp;


		_textShortcutService = new TextShortcutsService();

		UpdateInMemoryTextShortcuts();
		PopulateDataGrid();

		InitializeNotifyIcon();
		AddApplicationToStartup();

		InitializeForegroundWindowChecker();
	}

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
	#endregion
	// *****************************************************************************************************//


	#region NotifyIcon


	private void InitializeNotifyIcon()
	{
		notifyIcon = new NotifyIcon();

		// Use the image directly from the resource file

		//ResourceManager rm = Resources.ResourceManager;
		string iconPath = System.IO.Path.Combine(Application.StartupPath, "icon.ico");

		// Assign the transparent icon to the NotifyIcon
		notifyIcon.Icon = new Icon(iconPath);


		notifyIcon.Visible = true;

		notifyIcon.Text = GlobalVariables.APP_NAME;

		//Image openImage = ByteArrayToImage(Properties.Resources.btnOpen);
		//Image openImage = Properties.Resources.btnOpen;
		//Image exitImage = ByteArrayToImage(Properties.Resources.btnExit);
		//Image exitImage = Properties.Resources.btnExit;

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
				var selectedShortcut = dataGridView.SelectedRows[0].DataBoundItem as TextShortcutModel;

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
				var selectedShortcut = dataGridView.SelectedRows[0].DataBoundItem as TextShortcutModel;

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


	private void ReplaceKeyWithValue(TextShortcutModel shortcutModel)
	{
		var sim = new InputSimulator();
		for (int i = 0; i < shortcutModel.Key.Length; i++)
		{
			sim.Keyboard.KeyPress(VirtualKeyCode.BACK);   // not works vs code & notepad , fast

		}
		Clipboard.SetText(shortcutModel.Value);

		SendKeys.Send("^(v)");
	}

	#endregion


	#region DB & Memory operations

	private List<TextShortcutModel> GetAllTextShortcutsFromDb()
	{
		return _textShortcutService.GetAll();

	}

	private void UpdateInMemoryTextShortcuts()
	{
		textShortcuts = GetAllTextShortcutsFromDb();
	}

	private void PopulateDataGrid()
	{
		UpdateInMemoryTextShortcuts();

		dataGridView.DataSource = new BindingList<TextShortcutModel>(textShortcuts);

		MakeDataGridWrappable();

	}

	private void MakeDataGridWrappable()
	{

		dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

		dataGridView.AllowUserToAddRows = false;
		dataGridView.AllowUserToDeleteRows = false;
		dataGridView.ReadOnly = true;
	}


	private TextShortcutModel GetTextShortcutModel(string? key)
	{

		return Settings.Default.IsMatchingCaseSensitive ?
			textShortcuts.FirstOrDefault(t => string.Equals(t.Key, key)) :
			textShortcuts.FirstOrDefault(t => string.Equals(t.Key, key, StringComparison.OrdinalIgnoreCase));
	}
	#endregion

	#region Handle Button Clicks

	private void buttonAdd_Click(object sender, EventArgs e)
	{
		var window = new AddTextShortcutWindow();
		window.Owner = this;
		this.Opacity = 0.9;
		window.ShowDialog();
		this.Opacity = 1.0;
		PopulateDataGrid();
	}

	private void buttonDeleteTextShortcut_Click(TextShortcutModel textShortcutToDelete)
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


	private void buttonEditTextShortcut_Click(TextShortcutModel textShortcutToEdit)
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

		Func<TextShortcutModel, bool> filterPredicate = t =>
		{
			bool result = false;
			if (Settings.Default.SearchByName)
				result = result || t.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase);
			if (Settings.Default.SearchByKey)
				result = result || t.Key.Contains(searchTerm, StringComparison.OrdinalIgnoreCase);
			if (Settings.Default.SearchByValue)
				result = result || t.Value.Contains(searchTerm, StringComparison.OrdinalIgnoreCase);



			return result;
		};

		var filteredShortcuts = textShortcuts.Where(filterPredicate).ToList();

		dataGridView.DataSource = new BindingList<TextShortcutModel>(filteredShortcuts);
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

		checkBoxSearchByName.Checked = false;
		checkBoxSearchByKey.Checked = false;
		checkBoxSearchByValue.Checked = false;

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


	private void PopulateSearchByCheckBoxes()
	{
		checkBoxSearchByName.Checked = Settings.Default.SearchByName;
		checkBoxSearchByKey.Checked = Settings.Default.SearchByKey;
		checkBoxSearchByValue.Checked = Settings.Default.SearchByValue;
	}

	private void SaveSearchBySettings()
	{
		Settings.Default.SearchByName = checkBoxSearchByName.Checked;
		Settings.Default.SearchByKey = checkBoxSearchByKey.Checked;
		Settings.Default.SearchByValue = checkBoxSearchByValue.Checked;
	}

	private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (tabControl.SelectedIndex == 1)
		{
			ClearAllCheckBoxes();
			PopulateOtherSettingsCheckBoxes();
			PopulateTriggerKeysCheckBoxes();
			PopulateSearchByCheckBoxes();
			buttonSaveSettings.Enabled = false;

		}

	}
	private void buttonSaveSettings_Click(object sender, EventArgs e)
	{
		SaveOtherSettings();
		SaveTriggerKeysSettings();
		SaveSearchBySettings();

		SaveSettingsToMemory();

		MessageBox.Show("Settings are saved successfully ! ", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
	}

	private void checkBox_CheckedChanged(object sender, EventArgs e)
	{
		buttonSaveSettings.Enabled = true;
	}


	#endregion


}
