using Helper;
using Microsoft.Win32;
using Expandit.Data;
using Expandit.Models;
using Expandit.Services;
using Expandit.View;
using SQLitePCL;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Text;
using WindowsInput.Native;
using WindowsInput;

namespace Expandit
{
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

		private string currentText = string.Empty;

		private List<TextShortcutModel> textShortcuts;
		private TextShortcutsService _textShortcutService;
		private CategoryService _categoriesService;


		private NotifyIcon notifyIcon;
		private ContextMenuStrip contextMenuStrip;


		public MainWindow()
		{
			InitializeComponent();

			Batteries.Init();
			DatabaseHelper.InitializeDatabase();
			kh.KeyDown += Kh_KeyDown;
			kh.KeyUp += Kh_KeyUp;

			_categoriesService = new CategoryService();

			_textShortcutService = new TextShortcutsService();

			UpdateInMemoryTextShortcuts();
			PopulateDataGrid();
			PopulateCategoriesComboBox();

			InitializeNotifyIcon();
			AddApplicationToStartup();



			InitializeForegroundWindowChecker();

		}
		private void MainWindow_Load(object sender, EventArgs e)
		{
			Batteries.Init();
			DatabaseHelper.InitializeDatabase();
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
			notifyIcon.Icon = new Icon("icon.ico");
			notifyIcon.Visible = true;
			notifyIcon.Text = "Expandit";


			Image openImage = Image.FromFile("btnOpen.png");
			Image exitImage = Image.FromFile("btnExit.png");
			ToolStripMenuItem menuItemOpen = new ToolStripMenuItem("Open", openImage, onClick: (s, e) => ShowMainWindow());
			ToolStripMenuItem menuItemExit = new ToolStripMenuItem("Exit", exitImage, onClick: (s, e) => ExitApplication());
			// Initialize ContextMenu
			contextMenuStrip = new ContextMenuStrip();
			contextMenuStrip.Items.Add(menuItemOpen);
			contextMenuStrip.Items.Add(menuItemExit);
			notifyIcon.ContextMenuStrip = contextMenuStrip;

			// Handle events
			this.FormClosing += MainForm_FormClosing;
			notifyIcon.DoubleClick += (s, e) => ShowMainWindow();



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

			//if (e.KeyCode == Keys.Space || e.KeyCode == Keys.Enter)

			if (IsTriggerKey(e.KeyCode))
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

			if (IsSpecialKey(e.KeyCode))
			{
				return;
			}

			var adjustedKey = AdjustPressedKey(e.KeyCode);
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


		private bool IsTriggerKey(Keys e)
		{
			return Settings.Default.TriggerKeys.Contains(e.ToString());
		}

		private void ReplaceKeyWithValue(TextShortcutModel shortcutModel)
		{
			var sim = new InputSimulator();

			for (int i = 0; i < shortcutModel.Key.Length; i++)
			{
				//SendKey(VK_BACKSPACE);          // not works apps which has spell checkers , fast
				//SendKeys.Send("{BACKSPACE}");				// works everywhere, slow
				sim.Keyboard.KeyPress(VirtualKeyCode.BACK);   // not works vs code & notepad , fast

			}


			Clipboard.SetText(shortcutModel.Value);

			//ClipboardHelpers.PasteText();
			SendKeys.Send("^(v)");
			//sim.Keyboard.ModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.VK_V);


		}
		private string AdjustPressedKey(Keys keys)
		{
			var res = string.Empty;

			switch (keys)
			{

				case Keys.Oemtilde:
					res = shift ? "~" : "`";
					break;

				case Keys.Oemplus:
					res = shift ? "+" : "=";
					break;
				case Keys.Add:
					res = "+";
					break;
				case Keys.OemMinus:
					res = shift ? "_" : "-";
					break;
				case Keys.Subtract:
					res = "-";
					break;
				case Keys.Divide:
					res = "/";
					break;
				case Keys.Multiply:
					res = "*";
					break;



				case Keys.D1:
					res = shift ? "!" : "1";
					break;
				case Keys.D2:
					res = shift ? "@" : "2";

					break;
				case Keys.D3:
					res = shift ? "#" : "3";

					break;
				case Keys.D4:
					res = shift ? "$" : "4";


					break;
				case Keys.D5:
					res = shift ? "%" : "5";

					break;
				case Keys.D6:
					res = shift ? "^" : "6";

					break;
				case Keys.D7:
					res = shift ? "&" : "7";

					break;
				case Keys.D8:
					res = shift ? "*" : "8";

					break;
				case Keys.D9:
					res = shift ? "(" : "9";
					break;
				case Keys.D0:
					res = shift ? ")" : "0";

					break;

				case Keys.NumPad1:
					res = "1";
					break;
				case Keys.NumPad2:
					res = "2";
					break;
				case Keys.NumPad3:
					res = "3";
					break;
				case Keys.NumPad4:
					res = "4";
					break;
				case Keys.NumPad5:
					res = "5";
					break;
				case Keys.NumPad6:
					res = "6";
					break;
				case Keys.NumPad7:
					res = "7";
					break;
				case Keys.NumPad8:
					res = "8";
					break;
				case Keys.NumPad9:
					res = "9";
					break;
				case Keys.NumPad0:
					res = "0";
					break;
				case Keys.Decimal:
					res = ".";
					break;




				case Keys.OemOpenBrackets:
					res = shift ? "{" : "[";
					break;
				case Keys.Oem6:
					res = shift ? "}" : "]";
					break;
				case Keys.Oem5:
					res = shift ? "|" : "\\";
					break;
				case Keys.Oem1:
					res = shift ? ":" : ";";
					break;
				case Keys.Oem7:
					res = shift ? "\"" : "'";
					break;
				case Keys.OemQuestion:
					res = shift ? "?" : "/";
					break;
				case Keys.OemPeriod:
					res = shift ? ">" : ".";
					break;
				case Keys.Oemcomma:
					res = shift ? "<" : ",";
					break;

				case Keys.A:
					res = shift ? "A" : "a";
					break;
				case Keys.B:
					res = shift ? "B" : "b";
					break;
				case Keys.C:
					res = shift ? "C" : "c";
					break;
				case Keys.D:
					res = shift ? "D" : "d";
					break;
				case Keys.E:
					res = shift ? "E" : "e";
					break;
				case Keys.F:
					res = shift ? "F" : "f";
					break;
				case Keys.G:
					res = shift ? "G" : "g";
					break;
				case Keys.H:
					res = shift ? "H" : "h";
					break;
				case Keys.I:
					res = shift ? "I" : "i";
					break;
				case Keys.J:
					res = shift ? "J" : "j";
					break;
				case Keys.K:
					res = shift ? "K" : "k";
					break;
				case Keys.L:
					res = shift ? "L" : "l";
					break;
				case Keys.M:
					res = shift ? "M" : "m";
					break;
				case Keys.N:
					res = shift ? "N" : "n";
					break;
				case Keys.O:
					res = shift ? "O" : "o";
					break;
				case Keys.P:
					res = shift ? "P" : "p";
					break;
				case Keys.Q:
					res = shift ? "Q" : "q";
					break;
				case Keys.R:
					res = shift ? "R" : "r";
					break;
				case Keys.S:
					res = shift ? "S" : "s";
					break;
				case Keys.T:
					res = shift ? "T" : "t";
					break;
				case Keys.U:
					res = shift ? "U" : "u";
					break;
				case Keys.V:
					res = shift ? "V" : "v";
					break;
				case Keys.W:
					res = shift ? "W" : "w";
					break;
				case Keys.X:
					res = shift ? "X" : "x";
					break;
				case Keys.Y:
					res = shift ? "Y" : "y";
					break;
				case Keys.Z:
					res = shift ? "Z" : "z";
					break;



				default: break;


			}

			return res;

		}
		private bool IsSpecialKey(Keys key)
		{
			List<Keys> specialKeys = new List<Keys>
			{

			Keys.LWin, Keys.RWin,
			Keys.LControlKey, Keys.RControlKey,
			Keys.RMenu,Keys.LMenu,
			Keys.Tab,
			Keys.LShiftKey,Keys.RShiftKey,
			Keys.Escape,
			Keys.CapsLock, Keys.NumLock,
			Keys.LWin, Keys.RWin,
			Keys.Up, Keys.Down, Keys.Left , Keys.Right,
			Keys.Enter, Keys.Return,
			Keys.Back,Keys.Delete,
			Keys.F1, Keys.F2, Keys.F3, Keys.F4, Keys.F5, Keys.F6, Keys.F7, Keys.F8,  Keys.F9, Keys.F10,  Keys.F11, Keys.F12,
			Keys.Home, Keys.PageUp, Keys.PageDown, Keys.End,
			Keys.Clear, Keys.Insert,
			Keys.PrintScreen,
			Keys.None,
			Keys.VolumeDown, Keys.VolumeUp, Keys.VolumeMute,
			Keys.MediaNextTrack, Keys.MediaPreviousTrack, Keys.MediaPlayPause, Keys.MediaStop
			};

			return specialKeys.Contains(key);
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
		private void PopulateCategoriesComboBox()
		{
			var categories = _categoriesService.GetAll();

			// Create a new list to hold the combined items
			var combinedCategories = new List<CategoryModel>();

			// Add the "All Categories" item at the beginning
			combinedCategories.Add(new CategoryModel { Id = -1, Name = "All Categories" });

			// Add the rest of the categories
			combinedCategories.AddRange(categories);

			// Bind the combined list to the ComboBox
			comboBoxCategories.DataSource = combinedCategories;
			comboBoxCategories.DisplayMember = "Name"; // Property name to display
			comboBoxCategories.ValueMember = "Id"; // Property name for value


		}
		private void MakeDataGridWrappable()
		{
			/*foreach (DataGridViewColumn column in dataGridView.Columns)
			{
				column.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
			}
*/
			// Adjust the row heights to fit the wrapped content
			dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

			// Optionally: Set other DataGridView properties
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
					FilterDataGrid(searchBox.Text, comboBoxCategories.SelectedItem as CategoryModel);
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
			FilterDataGrid(searchBox.Text, comboBoxCategories.SelectedItem as CategoryModel);
		}
		private void searchBox_TextChanged(object sender, EventArgs e)
		{
			FilterDataGrid(searchBox.Text, comboBoxCategories.SelectedItem as CategoryModel);
		}
		private void FilterDataGrid(string searchTerm, CategoryModel selectedCategory)
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

				//Apply ComboBox selection

				if (selectedCategory.Id == -1)
				{

				}
				else
				{
					// Filter by selected category
					if (t.CategoryId == selectedCategory.Id)
						result = result && true;
					else
						result = false;
				}


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
				// Registry key where the application should be added
				RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);

				// Add the application to the startup list
				registryKey.SetValue("Expandit", Application.ExecutablePath);
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
				if (registryKey.GetValue("Expandit") != null)
				{
					registryKey.DeleteValue("Expandit", false);
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
}
