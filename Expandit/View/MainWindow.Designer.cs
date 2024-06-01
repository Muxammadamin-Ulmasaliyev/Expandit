using System.Windows.Forms;

namespace Expandit
{
	partial class MainWindow
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
			buttonAdd = new Button();
			searchBox = new TextBox();
			dataGridView = new DataGridView();
			idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			nameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			keyDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			valueDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			EditButtonInCell = new DataGridViewButtonColumn();
			DeleteButtonInCell = new DataGridViewButtonColumn();
			textShortcutModelBindingSource = new BindingSource(components);
			sqliteCommand1 = new Microsoft.Data.Sqlite.SqliteCommand();
			tabControl = new TabControl();
			tabPageMain = new TabPage();
			currentTextLabel = new Label();
			tabPageSettings = new TabPage();
			tableLayoutPanel1 = new TableLayoutPanel();
			groupBox2 = new GroupBox();
			checkBoxSearchByValue = new CheckBox();
			checkBoxSearchByKey = new CheckBox();
			checkBoxSearchByName = new CheckBox();
			groupBox3 = new GroupBox();
			buttonSaveSettings = new Button();
			tableLayoutPanel2 = new TableLayoutPanel();
			groupBox1 = new GroupBox();
			checkBoxCustom = new CheckBox();
			checkBoxTab = new CheckBox();
			checkBoxEnter = new CheckBox();
			checkBoxSpace = new CheckBox();
			groupBox4 = new GroupBox();
			checkBoxStartup = new CheckBox();
			((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
			((System.ComponentModel.ISupportInitialize)textShortcutModelBindingSource).BeginInit();
			tabControl.SuspendLayout();
			tabPageMain.SuspendLayout();
			tabPageSettings.SuspendLayout();
			tableLayoutPanel1.SuspendLayout();
			groupBox2.SuspendLayout();
			groupBox3.SuspendLayout();
			tableLayoutPanel2.SuspendLayout();
			groupBox1.SuspendLayout();
			groupBox4.SuspendLayout();
			SuspendLayout();
			// 
			// buttonAdd
			// 
			buttonAdd.Cursor = Cursors.Hand;
			buttonAdd.Font = new Font("Segoe UI Black", 20F, FontStyle.Bold, GraphicsUnit.Point, 204);
			buttonAdd.Location = new Point(799, 13);
			buttonAdd.Margin = new Padding(5);
			buttonAdd.Name = "buttonAdd";
			buttonAdd.Size = new Size(161, 64);
			buttonAdd.TabIndex = 0;
			buttonAdd.Text = "+";
			buttonAdd.UseVisualStyleBackColor = true;
			buttonAdd.Click += buttonAdd_Click;
			// 
			// searchBox
			// 
			searchBox.Font = new Font("Segoe UI", 16F);
			searchBox.Location = new Point(8, 34);
			searchBox.Margin = new Padding(5);
			searchBox.Name = "searchBox";
			searchBox.PlaceholderText = "Search... ";
			searchBox.Size = new Size(386, 43);
			searchBox.TabIndex = 1;
			searchBox.TextChanged += searchBox_TextChanged;
			// 
			// dataGridView
			// 
			dataGridView.AllowUserToAddRows = false;
			dataGridView.AllowUserToDeleteRows = false;
			dataGridView.AutoGenerateColumns = false;
			dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
			dataGridView.BackgroundColor = Color.FromArgb(224, 224, 224);
			dataGridView.BorderStyle = BorderStyle.None;
			dataGridView.CellBorderStyle = DataGridViewCellBorderStyle.Raised;
			dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridView.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, nameDataGridViewTextBoxColumn, keyDataGridViewTextBoxColumn, valueDataGridViewTextBoxColumn, EditButtonInCell, DeleteButtonInCell });
			dataGridView.DataSource = textShortcutModelBindingSource;
			dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle1.BackColor = SystemColors.Window;
			dataGridViewCellStyle1.Font = new Font("Segoe UI", 14F);
			dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
			dataGridViewCellStyle1.Padding = new Padding(2);
			dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
			dataGridView.DefaultCellStyle = dataGridViewCellStyle1;
			dataGridView.Location = new Point(10, 99);
			dataGridView.Margin = new Padding(5);
			dataGridView.Name = "dataGridView";
			dataGridView.ReadOnly = true;
			dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = SystemColors.Control;
			dataGridViewCellStyle2.Font = new Font("Segoe UI", 14F);
			dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle2.SelectionBackColor = SystemColors.GradientActiveCaption;
			dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
			dataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
			dataGridView.RowHeadersWidth = 50;
			dataGridViewCellStyle3.Padding = new Padding(1);
			dataGridView.RowsDefaultCellStyle = dataGridViewCellStyle3;
			dataGridView.RowTemplate.Height = 40;
			dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dataGridView.Size = new Size(950, 498);
			dataGridView.TabIndex = 2;
			dataGridView.CellContentClick += dataGridView_CellContentClick;
			// 
			// idDataGridViewTextBoxColumn
			// 
			idDataGridViewTextBoxColumn.DataPropertyName = "Id";
			idDataGridViewTextBoxColumn.HeaderText = "Id";
			idDataGridViewTextBoxColumn.MinimumWidth = 6;
			idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
			idDataGridViewTextBoxColumn.ReadOnly = true;
			idDataGridViewTextBoxColumn.Visible = false;
			idDataGridViewTextBoxColumn.Width = 125;
			// 
			// nameDataGridViewTextBoxColumn
			// 
			nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
			nameDataGridViewTextBoxColumn.HeaderText = "Name";
			nameDataGridViewTextBoxColumn.MinimumWidth = 150;
			nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
			nameDataGridViewTextBoxColumn.ReadOnly = true;
			nameDataGridViewTextBoxColumn.Width = 150;
			// 
			// keyDataGridViewTextBoxColumn
			// 
			keyDataGridViewTextBoxColumn.DataPropertyName = "Key";
			keyDataGridViewTextBoxColumn.HeaderText = "Key";
			keyDataGridViewTextBoxColumn.MinimumWidth = 125;
			keyDataGridViewTextBoxColumn.Name = "keyDataGridViewTextBoxColumn";
			keyDataGridViewTextBoxColumn.ReadOnly = true;
			keyDataGridViewTextBoxColumn.Width = 125;
			// 
			// valueDataGridViewTextBoxColumn
			// 
			valueDataGridViewTextBoxColumn.DataPropertyName = "Value";
			valueDataGridViewTextBoxColumn.HeaderText = "Value";
			valueDataGridViewTextBoxColumn.MinimumWidth = 350;
			valueDataGridViewTextBoxColumn.Name = "valueDataGridViewTextBoxColumn";
			valueDataGridViewTextBoxColumn.ReadOnly = true;
			valueDataGridViewTextBoxColumn.Width = 350;
			// 
			// EditButtonInCell
			// 
			EditButtonInCell.HeaderText = "";
			EditButtonInCell.MinimumWidth = 100;
			EditButtonInCell.Name = "EditButtonInCell";
			EditButtonInCell.ReadOnly = true;
			EditButtonInCell.Text = "Edit";
			EditButtonInCell.ToolTipText = "Edit shortcut";
			EditButtonInCell.UseColumnTextForButtonValue = true;
			EditButtonInCell.Width = 125;
			// 
			// DeleteButtonInCell
			// 
			DeleteButtonInCell.HeaderText = "";
			DeleteButtonInCell.MinimumWidth = 100;
			DeleteButtonInCell.Name = "DeleteButtonInCell";
			DeleteButtonInCell.ReadOnly = true;
			DeleteButtonInCell.Text = "Delete";
			DeleteButtonInCell.UseColumnTextForButtonValue = true;
			DeleteButtonInCell.Width = 125;
			// 
			// textShortcutModelBindingSource
			// 
			textShortcutModelBindingSource.DataSource = typeof(Models.TextShortcutModel);
			// 
			// sqliteCommand1
			// 
			sqliteCommand1.CommandTimeout = 30;
			sqliteCommand1.Connection = null;
			sqliteCommand1.Transaction = null;
			sqliteCommand1.UpdatedRowSource = System.Data.UpdateRowSource.None;
			// 
			// tabControl
			// 
			tabControl.Controls.Add(tabPageMain);
			tabControl.Controls.Add(tabPageSettings);
			tabControl.Dock = DockStyle.Fill;
			tabControl.Location = new Point(0, 0);
			tabControl.Margin = new Padding(5);
			tabControl.Name = "tabControl";
			tabControl.SelectedIndex = 0;
			tabControl.Size = new Size(982, 649);
			tabControl.TabIndex = 3;
			tabControl.SelectedIndexChanged += tabControl_SelectedIndexChanged;
			// 
			// tabPageMain
			// 
			tabPageMain.Controls.Add(currentTextLabel);
			tabPageMain.Controls.Add(buttonAdd);
			tabPageMain.Controls.Add(dataGridView);
			tabPageMain.Controls.Add(searchBox);
			tabPageMain.Location = new Point(4, 40);
			tabPageMain.Name = "tabPageMain";
			tabPageMain.Padding = new Padding(3);
			tabPageMain.Size = new Size(974, 605);
			tabPageMain.TabIndex = 0;
			tabPageMain.Text = "Main";
			tabPageMain.UseVisualStyleBackColor = true;
			// 
			// currentTextLabel
			// 
			currentTextLabel.AutoSize = true;
			currentTextLabel.Location = new Point(10, 3);
			currentTextLabel.Name = "currentTextLabel";
			currentTextLabel.Size = new Size(0, 32);
			currentTextLabel.TabIndex = 3;
			// 
			// tabPageSettings
			// 
			tabPageSettings.Controls.Add(tableLayoutPanel1);
			tabPageSettings.Location = new Point(4, 29);
			tabPageSettings.Name = "tabPageSettings";
			tabPageSettings.Padding = new Padding(3);
			tabPageSettings.Size = new Size(974, 616);
			tabPageSettings.TabIndex = 1;
			tabPageSettings.Text = "Settings";
			tabPageSettings.UseVisualStyleBackColor = true;
			// 
			// tableLayoutPanel1
			// 
			tableLayoutPanel1.ColumnCount = 1;
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
			tableLayoutPanel1.Controls.Add(groupBox2, 0, 1);
			tableLayoutPanel1.Controls.Add(groupBox3, 0, 2);
			tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 0);
			tableLayoutPanel1.Dock = DockStyle.Fill;
			tableLayoutPanel1.Location = new Point(3, 3);
			tableLayoutPanel1.Name = "tableLayoutPanel1";
			tableLayoutPanel1.RowCount = 3;
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 34F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33F));
			tableLayoutPanel1.Size = new Size(968, 610);
			tableLayoutPanel1.TabIndex = 0;
			// 
			// groupBox2
			// 
			groupBox2.Controls.Add(checkBoxSearchByValue);
			groupBox2.Controls.Add(checkBoxSearchByKey);
			groupBox2.Controls.Add(checkBoxSearchByName);
			groupBox2.Dock = DockStyle.Fill;
			groupBox2.Location = new Point(3, 204);
			groupBox2.Name = "groupBox2";
			groupBox2.Size = new Size(962, 201);
			groupBox2.TabIndex = 1;
			groupBox2.TabStop = false;
			groupBox2.Text = "Search Bar ;";
			// 
			// checkBoxSearchByValue
			// 
			checkBoxSearchByValue.AutoSize = true;
			checkBoxSearchByValue.Location = new Point(18, 122);
			checkBoxSearchByValue.Name = "checkBoxSearchByValue";
			checkBoxSearchByValue.Size = new Size(94, 36);
			checkBoxSearchByValue.TabIndex = 2;
			checkBoxSearchByValue.Text = "Value";
			checkBoxSearchByValue.UseVisualStyleBackColor = true;
			checkBoxSearchByValue.CheckedChanged += checkBox_CheckedChanged;
			// 
			// checkBoxSearchByKey
			// 
			checkBoxSearchByKey.AutoSize = true;
			checkBoxSearchByKey.Location = new Point(18, 80);
			checkBoxSearchByKey.Name = "checkBoxSearchByKey";
			checkBoxSearchByKey.Size = new Size(75, 36);
			checkBoxSearchByKey.TabIndex = 1;
			checkBoxSearchByKey.Text = "Key";
			checkBoxSearchByKey.UseVisualStyleBackColor = true;
			checkBoxSearchByKey.CheckedChanged += checkBox_CheckedChanged;
			// 
			// checkBoxSearchByName
			// 
			checkBoxSearchByName.AutoSize = true;
			checkBoxSearchByName.Location = new Point(18, 38);
			checkBoxSearchByName.Name = "checkBoxSearchByName";
			checkBoxSearchByName.Size = new Size(100, 36);
			checkBoxSearchByName.TabIndex = 0;
			checkBoxSearchByName.Text = "Name";
			checkBoxSearchByName.UseVisualStyleBackColor = true;
			checkBoxSearchByName.CheckedChanged += checkBox_CheckedChanged;
			// 
			// groupBox3
			// 
			groupBox3.Controls.Add(buttonSaveSettings);
			groupBox3.Dock = DockStyle.Fill;
			groupBox3.Location = new Point(3, 411);
			groupBox3.Name = "groupBox3";
			groupBox3.Size = new Size(962, 196);
			groupBox3.TabIndex = 2;
			groupBox3.TabStop = false;
			groupBox3.Text = "Predefined shortcuts";
			// 
			// buttonSaveSettings
			// 
			buttonSaveSettings.Enabled = false;
			buttonSaveSettings.Location = new Point(818, 139);
			buttonSaveSettings.Name = "buttonSaveSettings";
			buttonSaveSettings.Size = new Size(138, 48);
			buttonSaveSettings.TabIndex = 0;
			buttonSaveSettings.Text = "Save";
			buttonSaveSettings.UseVisualStyleBackColor = true;
			buttonSaveSettings.Click += buttonSaveSettings_Click;
			// 
			// tableLayoutPanel2
			// 
			tableLayoutPanel2.ColumnCount = 2;
			tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
			tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
			tableLayoutPanel2.Controls.Add(groupBox1, 0, 0);
			tableLayoutPanel2.Controls.Add(groupBox4, 1, 0);
			tableLayoutPanel2.Dock = DockStyle.Fill;
			tableLayoutPanel2.Location = new Point(3, 3);
			tableLayoutPanel2.Name = "tableLayoutPanel2";
			tableLayoutPanel2.RowCount = 1;
			tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
			tableLayoutPanel2.Size = new Size(962, 195);
			tableLayoutPanel2.TabIndex = 3;
			// 
			// groupBox1
			// 
			groupBox1.Controls.Add(checkBoxCustom);
			groupBox1.Controls.Add(checkBoxTab);
			groupBox1.Controls.Add(checkBoxEnter);
			groupBox1.Controls.Add(checkBoxSpace);
			groupBox1.Dock = DockStyle.Fill;
			groupBox1.Location = new Point(3, 3);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new Size(475, 189);
			groupBox1.TabIndex = 1;
			groupBox1.TabStop = false;
			groupBox1.Text = "Trigger Key";
			// 
			// checkBoxCustom
			// 
			checkBoxCustom.AutoSize = true;
			checkBoxCustom.Location = new Point(129, 43);
			checkBoxCustom.Name = "checkBoxCustom";
			checkBoxCustom.Size = new Size(118, 36);
			checkBoxCustom.TabIndex = 3;
			checkBoxCustom.Text = "Custom";
			checkBoxCustom.UseVisualStyleBackColor = true;
			checkBoxCustom.CheckedChanged += checkBox_CheckedChanged;
			// 
			// checkBoxTab
			// 
			checkBoxTab.AutoSize = true;
			checkBoxTab.Location = new Point(15, 127);
			checkBoxTab.Name = "checkBoxTab";
			checkBoxTab.Size = new Size(72, 36);
			checkBoxTab.TabIndex = 2;
			checkBoxTab.Text = "Tab";
			checkBoxTab.UseVisualStyleBackColor = true;
			checkBoxTab.CheckedChanged += checkBox_CheckedChanged;
			// 
			// checkBoxEnter
			// 
			checkBoxEnter.AutoSize = true;
			checkBoxEnter.Location = new Point(15, 85);
			checkBoxEnter.Name = "checkBoxEnter";
			checkBoxEnter.Size = new Size(91, 36);
			checkBoxEnter.TabIndex = 1;
			checkBoxEnter.Text = "Enter";
			checkBoxEnter.UseVisualStyleBackColor = true;
			checkBoxEnter.CheckedChanged += checkBox_CheckedChanged;
			// 
			// checkBoxSpace
			// 
			checkBoxSpace.AutoSize = true;
			checkBoxSpace.Location = new Point(15, 43);
			checkBoxSpace.Name = "checkBoxSpace";
			checkBoxSpace.Size = new Size(99, 36);
			checkBoxSpace.TabIndex = 0;
			checkBoxSpace.Text = "Space";
			checkBoxSpace.UseVisualStyleBackColor = true;
			checkBoxSpace.CheckedChanged += checkBox_CheckedChanged;
			// 
			// groupBox4
			// 
			groupBox4.Controls.Add(checkBoxStartup);
			groupBox4.Dock = DockStyle.Fill;
			groupBox4.Location = new Point(484, 3);
			groupBox4.Name = "groupBox4";
			groupBox4.Size = new Size(475, 189);
			groupBox4.TabIndex = 2;
			groupBox4.TabStop = false;
			groupBox4.Text = "Startup settings";
			// 
			// checkBoxStartup
			// 
			checkBoxStartup.AutoSize = true;
			checkBoxStartup.Location = new Point(6, 43);
			checkBoxStartup.Name = "checkBoxStartup";
			checkBoxStartup.Size = new Size(194, 36);
			checkBoxStartup.TabIndex = 0;
			checkBoxStartup.Text = "Run on startup";
			checkBoxStartup.UseVisualStyleBackColor = true;
			checkBoxStartup.CheckedChanged += checkBox_CheckedChanged;
			// 
			// MainWindow
			// 
			AutoScaleDimensions = new SizeF(13F, 31F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(982, 649);
			Controls.Add(tabControl);
			Font = new Font("Segoe UI", 14F);
			FormBorderStyle = FormBorderStyle.Fixed3D;
			Icon = (Icon)resources.GetObject("$this.Icon");
			Margin = new Padding(5);
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "MainWindow";
			Text = "Expandit";
			Load += MainWindow_Load;
			((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
			((System.ComponentModel.ISupportInitialize)textShortcutModelBindingSource).EndInit();
			tabControl.ResumeLayout(false);
			tabPageMain.ResumeLayout(false);
			tabPageMain.PerformLayout();
			tabPageSettings.ResumeLayout(false);
			tableLayoutPanel1.ResumeLayout(false);
			groupBox2.ResumeLayout(false);
			groupBox2.PerformLayout();
			groupBox3.ResumeLayout(false);
			tableLayoutPanel2.ResumeLayout(false);
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			groupBox4.ResumeLayout(false);
			groupBox4.PerformLayout();
			ResumeLayout(false);
		}

		#endregion

		private Button buttonAdd;
		private TextBox searchBox;
		private DataGridView dataGridView;
		private BindingSource textShortcutModelBindingSource;
		private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn keyDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn valueDataGridViewTextBoxColumn;
		private DataGridViewButtonColumn EditButtonInCell;
		private DataGridViewButtonColumn DeleteButtonInCell;
		private Microsoft.Data.Sqlite.SqliteCommand sqliteCommand1;
		private TabControl tabControl;
		private TabPage tabPageMain;
		private TabPage tabPageSettings;
		private TableLayoutPanel tableLayoutPanel1;
		private GroupBox groupBox2;
		private GroupBox groupBox3;
		private Label currentTextLabel;
		private Button buttonSaveSettings;
		private TableLayoutPanel tableLayoutPanel2;
		private GroupBox groupBox1;
		private CheckBox checkBoxCustom;
		private CheckBox checkBoxTab;
		private CheckBox checkBoxEnter;
		private CheckBox checkBoxSpace;
		private GroupBox groupBox4;
		private CheckBox checkBoxStartup;
		private CheckBox checkBoxSearchByValue;
		private CheckBox checkBoxSearchByKey;
		private CheckBox checkBoxSearchByName;
	}
}
