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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            textShortcutModelBindingSource1 = new BindingSource(components);
            buttonAdd = new Button();
            searchBox = new TextBox();
            textShortcutModelBindingSource = new BindingSource(components);
            tabControl = new TabControl();
            tabPageShortcuts = new TabPage();
            tableLayoutPanelShortcuts = new TableLayoutPanel();
            dataGridView = new DataGridView();
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            keyDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            valueDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            buttonEditInCell = new DataGridViewButtonColumn();
            buttonDeleteInCell = new DataGridViewButtonColumn();
            currentTextLabel = new Label();
            tabPagePreferences = new TabPage();
            tableLayoutPanel1 = new TableLayoutPanel();
            groupBox2 = new GroupBox();
            checkBoxIsStrictMatching = new CheckBox();
            checkBoxStartup = new CheckBox();
            groupBox3 = new GroupBox();
            groupBox4 = new GroupBox();
            groupBox5 = new GroupBox();
            groupBox1 = new GroupBox();
            checkBoxTab = new CheckBox();
            checkBoxEnter = new CheckBox();
            checkBoxSpace = new CheckBox();
            groupBox6 = new GroupBox();
            buttonSaveSettings = new Button();
            tabPageStatistics = new TabPage();
            labelDailyKeypresses = new Label();
            dataGridStatistics = new DataGridView();
            colDate = new DataGridViewTextBoxColumn();
            colAppName = new DataGridViewTextBoxColumn();
            colKeyPresses = new DataGridViewTextBoxColumn();
            labelStatsHeader = new Label();
            labelTotalExpansions = new Label();
            labelTotalCharsSaved = new Label();
            labelTotalTimeSaved = new Label();
            dateTimePickerFilter = new DateTimePicker();
            btnRefreshStats = new Button();
            tabPageAbout = new TabPage();
            tableLayoutPanel2 = new TableLayoutPanel();
            groupBoxAboutApplication = new GroupBox();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            linkLabelSourceCode = new LinkLabel();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            groupBoxAboutDeveloper = new GroupBox();
            linkLabelEmail = new LinkLabel();
            label9 = new Label();
            linkLabelLeetCode = new LinkLabel();
            linkLabelGithub = new LinkLabel();
            linkLabelLinkedIn = new LinkLabel();
            label5 = new Label();
            label4 = new Label();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            importShortcutsToolStripMenuItem = new ToolStripMenuItem();
            exportShortcutsToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)textShortcutModelBindingSource1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)textShortcutModelBindingSource).BeginInit();
            tabControl.SuspendLayout();
            tabPageShortcuts.SuspendLayout();
            tableLayoutPanelShortcuts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            tabPagePreferences.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox6.SuspendLayout();
            tabPageStatistics.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridStatistics).BeginInit();
            tabPageAbout.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            groupBoxAboutApplication.SuspendLayout();
            groupBoxAboutDeveloper.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // textShortcutModelBindingSource1
            // 
            textShortcutModelBindingSource1.DataSource = typeof(Models.TextShortcut);
            // 
            // buttonAdd
            // 
            buttonAdd.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonAdd.Cursor = Cursors.Hand;
            buttonAdd.Font = new Font("Segoe UI Black", 20F, FontStyle.Bold, GraphicsUnit.Point, 204);
            buttonAdd.Location = new Point(802, 5);
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
            searchBox.Location = new Point(5, 5);
            searchBox.Margin = new Padding(5);
            searchBox.Name = "searchBox";
            searchBox.PlaceholderText = "Search... ";
            searchBox.Size = new Size(386, 43);
            searchBox.TabIndex = 1;
            searchBox.TextChanged += searchBox_TextChanged;
            // 
            // textShortcutModelBindingSource
            // 
            textShortcutModelBindingSource.DataSource = typeof(Models.TextShortcut);
            // 
            // tabControl
            // 
            tabControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl.Controls.Add(tabPageShortcuts);
            tabControl.Controls.Add(tabPagePreferences);
            tabControl.Controls.Add(tabPageStatistics);
            tabControl.Controls.Add(tabPageAbout);
            tabControl.Location = new Point(0, 33);
            tabControl.Margin = new Padding(5);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(982, 618);
            tabControl.TabIndex = 3;
            tabControl.SelectedIndexChanged += tabControl_SelectedIndexChanged;
            // 
            // tabPageShortcuts
            // 
            tabPageShortcuts.Controls.Add(tableLayoutPanelShortcuts);
            tabPageShortcuts.Controls.Add(currentTextLabel);
            tabPageShortcuts.Location = new Point(4, 40);
            tabPageShortcuts.Name = "tabPageShortcuts";
            tabPageShortcuts.Padding = new Padding(3);
            tabPageShortcuts.Size = new Size(974, 574);
            tabPageShortcuts.TabIndex = 0;
            tabPageShortcuts.Text = "Shortcuts";
            tabPageShortcuts.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanelShortcuts
            // 
            tableLayoutPanelShortcuts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanelShortcuts.ColumnCount = 2;
            tableLayoutPanelShortcuts.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanelShortcuts.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanelShortcuts.Controls.Add(dataGridView, 0, 1);
            tableLayoutPanelShortcuts.Controls.Add(buttonAdd, 1, 0);
            tableLayoutPanelShortcuts.Controls.Add(searchBox, 0, 0);
            tableLayoutPanelShortcuts.Location = new Point(3, 3);
            tableLayoutPanelShortcuts.Name = "tableLayoutPanelShortcuts";
            tableLayoutPanelShortcuts.RowCount = 2;
            tableLayoutPanelShortcuts.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanelShortcuts.RowStyles.Add(new RowStyle(SizeType.Percent, 83.3333359F));
            tableLayoutPanelShortcuts.Size = new Size(968, 568);
            tableLayoutPanelShortcuts.TabIndex = 4;
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AllowUserToOrderColumns = true;
            dataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView.AutoGenerateColumns = false;
            dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView.BackgroundColor = SystemColors.Control;
            dataGridView.BorderStyle = BorderStyle.None;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, nameDataGridViewTextBoxColumn, keyDataGridViewTextBoxColumn, valueDataGridViewTextBoxColumn, buttonEditInCell, buttonDeleteInCell });
            tableLayoutPanelShortcuts.SetColumnSpan(dataGridView, 2);
            dataGridView.DataSource = textShortcutModelBindingSource1;
            dataGridView.Location = new Point(3, 97);
            dataGridView.MultiSelect = false;
            dataGridView.Name = "dataGridView";
            dataGridView.ReadOnly = true;
            dataGridView.RowHeadersWidth = 51;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.Size = new Size(962, 468);
            dataGridView.TabIndex = 5;
            dataGridView.CellContentClick += dataGridView_CellContentClick;
            // 
            // idDataGridViewTextBoxColumn
            // 
            idDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            idDataGridViewTextBoxColumn.HeaderText = "Id";
            idDataGridViewTextBoxColumn.MinimumWidth = 6;
            idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            idDataGridViewTextBoxColumn.ReadOnly = true;
            idDataGridViewTextBoxColumn.Visible = false;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            nameDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            nameDataGridViewTextBoxColumn.FillWeight = 85.07134F;
            nameDataGridViewTextBoxColumn.HeaderText = "Name";
            nameDataGridViewTextBoxColumn.MinimumWidth = 140;
            nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // keyDataGridViewTextBoxColumn
            // 
            keyDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            keyDataGridViewTextBoxColumn.DataPropertyName = "Key";
            keyDataGridViewTextBoxColumn.FillWeight = 88.4174652F;
            keyDataGridViewTextBoxColumn.HeaderText = "Key";
            keyDataGridViewTextBoxColumn.MinimumWidth = 140;
            keyDataGridViewTextBoxColumn.Name = "keyDataGridViewTextBoxColumn";
            keyDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // valueDataGridViewTextBoxColumn
            // 
            valueDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            valueDataGridViewTextBoxColumn.DataPropertyName = "Value";
            valueDataGridViewTextBoxColumn.FillWeight = 203.36293F;
            valueDataGridViewTextBoxColumn.HeaderText = "Value";
            valueDataGridViewTextBoxColumn.MinimumWidth = 350;
            valueDataGridViewTextBoxColumn.Name = "valueDataGridViewTextBoxColumn";
            valueDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // buttonEditInCell
            // 
            buttonEditInCell.FillWeight = 58.6400261F;
            buttonEditInCell.HeaderText = "";
            buttonEditInCell.MinimumWidth = 6;
            buttonEditInCell.Name = "buttonEditInCell";
            buttonEditInCell.ReadOnly = true;
            buttonEditInCell.Resizable = DataGridViewTriState.True;
            buttonEditInCell.SortMode = DataGridViewColumnSortMode.Automatic;
            buttonEditInCell.Text = "Edit";
            buttonEditInCell.UseColumnTextForButtonValue = true;
            buttonEditInCell.Width = 106;
            // 
            // buttonDeleteInCell
            // 
            buttonDeleteInCell.FillWeight = 64.50813F;
            buttonDeleteInCell.HeaderText = "";
            buttonDeleteInCell.MinimumWidth = 6;
            buttonDeleteInCell.Name = "buttonDeleteInCell";
            buttonDeleteInCell.ReadOnly = true;
            buttonDeleteInCell.Text = "Delete";
            buttonDeleteInCell.UseColumnTextForButtonValue = true;
            buttonDeleteInCell.Width = 118;
            // 
            // currentTextLabel
            // 
            currentTextLabel.AutoSize = true;
            currentTextLabel.Location = new Point(10, 3);
            currentTextLabel.Name = "currentTextLabel";
            currentTextLabel.Size = new Size(0, 32);
            currentTextLabel.TabIndex = 3;
            currentTextLabel.Visible = false;
            // 
            // tabPagePreferences
            // 
            tabPagePreferences.Controls.Add(tableLayoutPanel1);
            tabPagePreferences.Location = new Point(4, 29);
            tabPagePreferences.Name = "tabPagePreferences";
            tabPagePreferences.Padding = new Padding(3);
            tabPagePreferences.Size = new Size(974, 585);
            tabPagePreferences.TabIndex = 1;
            tabPagePreferences.Text = "Preferences";
            tabPagePreferences.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(groupBox2, 0, 1);
            tableLayoutPanel1.Controls.Add(groupBox3, 0, 2);
            tableLayoutPanel1.Controls.Add(groupBox4, 1, 0);
            tableLayoutPanel1.Controls.Add(groupBox5, 1, 1);
            tableLayoutPanel1.Controls.Add(groupBox1, 0, 0);
            tableLayoutPanel1.Controls.Add(groupBox6, 1, 2);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(3, 3);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 34F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(968, 579);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(checkBoxIsStrictMatching);
            groupBox2.Controls.Add(checkBoxStartup);
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Location = new Point(3, 194);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(478, 190);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            // 
            // checkBoxIsStrictMatching
            // 
            checkBoxIsStrictMatching.AutoSize = true;
            checkBoxIsStrictMatching.Location = new Point(15, 80);
            checkBoxIsStrictMatching.Name = "checkBoxIsStrictMatching";
            checkBoxIsStrictMatching.Size = new Size(197, 36);
            checkBoxIsStrictMatching.TabIndex = 1;
            checkBoxIsStrictMatching.Text = "Strict Matching";
            checkBoxIsStrictMatching.UseVisualStyleBackColor = true;
            checkBoxIsStrictMatching.CheckedChanged += checkBox_CheckedChanged;
            // 
            // checkBoxStartup
            // 
            checkBoxStartup.AutoSize = true;
            checkBoxStartup.Location = new Point(15, 38);
            checkBoxStartup.Name = "checkBoxStartup";
            checkBoxStartup.Size = new Size(194, 36);
            checkBoxStartup.TabIndex = 0;
            checkBoxStartup.Text = "Run on startup";
            checkBoxStartup.UseVisualStyleBackColor = true;
            checkBoxStartup.CheckedChanged += checkBox_CheckedChanged;
            // 
            // groupBox3
            // 
            groupBox3.Dock = DockStyle.Fill;
            groupBox3.Location = new Point(3, 390);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(478, 186);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            // 
            // groupBox4
            // 
            groupBox4.Dock = DockStyle.Fill;
            groupBox4.Location = new Point(487, 3);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(478, 185);
            groupBox4.TabIndex = 4;
            groupBox4.TabStop = false;
            // 
            // groupBox5
            // 
            groupBox5.Dock = DockStyle.Fill;
            groupBox5.Location = new Point(487, 194);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(478, 190);
            groupBox5.TabIndex = 5;
            groupBox5.TabStop = false;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(checkBoxTab);
            groupBox1.Controls.Add(checkBoxEnter);
            groupBox1.Controls.Add(checkBoxSpace);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(3, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(478, 185);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Trigger Key";
            // 
            // checkBoxTab
            // 
            checkBoxTab.AutoSize = true;
            checkBoxTab.Location = new Point(271, 43);
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
            checkBoxEnter.Location = new Point(147, 43);
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
            // groupBox6
            // 
            groupBox6.Controls.Add(buttonSaveSettings);
            groupBox6.Dock = DockStyle.Fill;
            groupBox6.Location = new Point(487, 390);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new Size(478, 186);
            groupBox6.TabIndex = 6;
            groupBox6.TabStop = false;
            // 
            // buttonSaveSettings
            // 
            buttonSaveSettings.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonSaveSettings.Enabled = false;
            buttonSaveSettings.Location = new Point(334, 132);
            buttonSaveSettings.Name = "buttonSaveSettings";
            buttonSaveSettings.Size = new Size(138, 48);
            buttonSaveSettings.TabIndex = 0;
            buttonSaveSettings.Text = "Save";
            buttonSaveSettings.UseVisualStyleBackColor = true;
            buttonSaveSettings.Click += buttonSaveSettings_Click;
            // 
            // tabPageStatistics
            // 
            tabPageStatistics.Controls.Add(labelDailyKeypresses);
            tabPageStatistics.Controls.Add(dataGridStatistics);
            tabPageStatistics.Controls.Add(labelStatsHeader);
            tabPageStatistics.Controls.Add(labelTotalExpansions);
            tabPageStatistics.Controls.Add(labelTotalCharsSaved);
            tabPageStatistics.Controls.Add(labelTotalTimeSaved);
            tabPageStatistics.Controls.Add(dateTimePickerFilter);
            tabPageStatistics.Controls.Add(btnRefreshStats);
            tabPageStatistics.Location = new Point(4, 29);
            tabPageStatistics.Name = "tabPageStatistics";
            tabPageStatistics.Padding = new Padding(3);
            tabPageStatistics.Size = new Size(974, 585);
            tabPageStatistics.TabIndex = 3;
            tabPageStatistics.Text = "Statistics";
            tabPageStatistics.UseVisualStyleBackColor = true;
            // 
            // labelDailyKeypresses
            // 
            labelDailyKeypresses.AutoSize = true;
            labelDailyKeypresses.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            labelDailyKeypresses.Location = new Point(33, 243);
            labelDailyKeypresses.Name = "labelDailyKeypresses";
            labelDailyKeypresses.Size = new Size(349, 37);
            labelDailyKeypresses.TabIndex = 9;
            labelDailyKeypresses.Text = "Daily keypresses per app :";
            // 
            // dataGridStatistics
            // 
            dataGridStatistics.AllowUserToAddRows = false;
            dataGridStatistics.AllowUserToDeleteRows = false;
            dataGridStatistics.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridStatistics.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridStatistics.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridStatistics.BackgroundColor = SystemColors.Control;
            dataGridStatistics.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridStatistics.Columns.AddRange(new DataGridViewColumn[] { colDate, colAppName, colKeyPresses });
            dataGridStatistics.Location = new Point(33, 305);
            dataGridStatistics.Name = "dataGridStatistics";
            dataGridStatistics.ReadOnly = true;
            dataGridStatistics.RowHeadersWidth = 51;
            dataGridStatistics.Size = new Size(933, 241);
            dataGridStatistics.TabIndex = 5;
            // 
            // colDate
            // 
            colDate.HeaderText = "Date";
            colDate.MinimumWidth = 6;
            colDate.Name = "colDate";
            colDate.ReadOnly = true;
            // 
            // colAppName
            // 
            colAppName.HeaderText = "Application";
            colAppName.MinimumWidth = 6;
            colAppName.Name = "colAppName";
            colAppName.ReadOnly = true;
            // 
            // colKeyPresses
            // 
            colKeyPresses.HeaderText = "Keypresses";
            colKeyPresses.MinimumWidth = 6;
            colKeyPresses.Name = "colKeyPresses";
            colKeyPresses.ReadOnly = true;
            // 
            // labelStatsHeader
            // 
            labelStatsHeader.AutoSize = true;
            labelStatsHeader.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            labelStatsHeader.Location = new Point(23, 23);
            labelStatsHeader.Name = "labelStatsHeader";
            labelStatsHeader.Size = new Size(394, 54);
            labelStatsHeader.TabIndex = 0;
            labelStatsHeader.Text = "Productivity Report";
            // 
            // labelTotalExpansions
            // 
            labelTotalExpansions.AutoSize = true;
            labelTotalExpansions.Font = new Font("Segoe UI", 16F);
            labelTotalExpansions.Location = new Point(33, 96);
            labelTotalExpansions.Name = "labelTotalExpansions";
            labelTotalExpansions.Size = new Size(240, 37);
            labelTotalExpansions.TabIndex = 1;
            labelTotalExpansions.Text = "Total Expansions: 0";
            // 
            // labelTotalCharsSaved
            // 
            labelTotalCharsSaved.AutoSize = true;
            labelTotalCharsSaved.Font = new Font("Segoe UI", 16F);
            labelTotalCharsSaved.Location = new Point(33, 145);
            labelTotalCharsSaved.Name = "labelTotalCharsSaved";
            labelTotalCharsSaved.Size = new Size(247, 37);
            labelTotalCharsSaved.TabIndex = 2;
            labelTotalCharsSaved.Text = "Characters Saved: 0";
            // 
            // labelTotalTimeSaved
            // 
            labelTotalTimeSaved.AutoSize = true;
            labelTotalTimeSaved.Font = new Font("Segoe UI", 16F);
            labelTotalTimeSaved.Location = new Point(33, 194);
            labelTotalTimeSaved.Name = "labelTotalTimeSaved";
            labelTotalTimeSaved.Size = new Size(204, 37);
            labelTotalTimeSaved.TabIndex = 3;
            labelTotalTimeSaved.Text = "Time Saved: 0m";
            // 
            // dateTimePickerFilter
            // 
            dateTimePickerFilter.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dateTimePickerFilter.Font = new Font("Segoe UI", 12F);
            dateTimePickerFilter.Format = DateTimePickerFormat.Short;
            dateTimePickerFilter.Location = new Point(683, 245);
            dateTimePickerFilter.Name = "dateTimePickerFilter";
            dateTimePickerFilter.Size = new Size(150, 34);
            dateTimePickerFilter.TabIndex = 5;
            dateTimePickerFilter.ValueChanged += dateTimePickerFilter_ValueChanged;
            // 
            // btnRefreshStats
            // 
            btnRefreshStats.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRefreshStats.Font = new Font("Segoe UI", 10F);
            btnRefreshStats.Location = new Point(857, 243);
            btnRefreshStats.Name = "btnRefreshStats";
            btnRefreshStats.Size = new Size(100, 40);
            btnRefreshStats.TabIndex = 8;
            btnRefreshStats.Text = "Refresh";
            btnRefreshStats.UseVisualStyleBackColor = true;
            btnRefreshStats.Click += btnRefreshStats_Click;
            // 
            // tabPageAbout
            // 
            tabPageAbout.Controls.Add(tableLayoutPanel2);
            tabPageAbout.Location = new Point(4, 29);
            tabPageAbout.Name = "tabPageAbout";
            tabPageAbout.Size = new Size(974, 585);
            tabPageAbout.TabIndex = 2;
            tabPageAbout.Text = "About";
            tabPageAbout.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(groupBoxAboutApplication, 0, 0);
            tableLayoutPanel2.Controls.Add(groupBoxAboutDeveloper, 1, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(0, 0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.Size = new Size(974, 585);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // groupBoxAboutApplication
            // 
            groupBoxAboutApplication.Controls.Add(label8);
            groupBoxAboutApplication.Controls.Add(label7);
            groupBoxAboutApplication.Controls.Add(label6);
            groupBoxAboutApplication.Controls.Add(linkLabelSourceCode);
            groupBoxAboutApplication.Controls.Add(label3);
            groupBoxAboutApplication.Controls.Add(label2);
            groupBoxAboutApplication.Controls.Add(label1);
            groupBoxAboutApplication.Dock = DockStyle.Fill;
            groupBoxAboutApplication.Location = new Point(3, 3);
            groupBoxAboutApplication.Name = "groupBoxAboutApplication";
            groupBoxAboutApplication.Size = new Size(481, 579);
            groupBoxAboutApplication.TabIndex = 0;
            groupBoxAboutApplication.TabStop = false;
            groupBoxAboutApplication.Text = "About Application";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(155, 114);
            label8.Name = "label8";
            label8.Size = new Size(63, 32);
            label8.TabIndex = 6;
            label8.Text = "1.0.1";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(113, 71);
            label7.Name = "label7";
            label7.Size = new Size(105, 32);
            label7.TabIndex = 5;
            label7.Text = "Expandit";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(72, 208);
            label6.Name = "label6";
            label6.Size = new Size(215, 32);
            label6.TabIndex = 4;
            label6.Text = " .NET8 + Winforms";
            // 
            // linkLabelSourceCode
            // 
            linkLabelSourceCode.AutoSize = true;
            linkLabelSourceCode.Location = new Point(293, 208);
            linkLabelSourceCode.Name = "linkLabelSourceCode";
            linkLabelSourceCode.Size = new Size(157, 32);
            linkLabelSourceCode.TabIndex = 3;
            linkLabelSourceCode.TabStop = true;
            linkLabelSourceCode.Text = "(source code)";
            linkLabelSourceCode.LinkClicked += linkLabelSourceCode_LinkClicked;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label3.Location = new Point(0, 160);
            label3.Name = "label3";
            label3.Size = new Size(238, 32);
            label3.TabIndex = 2;
            label3.Text = "Technologies used :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label2.Location = new Point(0, 114);
            label2.Name = "label2";
            label2.Size = new Size(120, 32);
            label2.TabIndex = 1;
            label2.Text = "Version : ";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label1.Location = new Point(0, 71);
            label1.Name = "label1";
            label1.Size = new Size(102, 32);
            label1.TabIndex = 0;
            label1.Text = "Name : ";
            // 
            // groupBoxAboutDeveloper
            // 
            groupBoxAboutDeveloper.Controls.Add(linkLabelEmail);
            groupBoxAboutDeveloper.Controls.Add(label9);
            groupBoxAboutDeveloper.Controls.Add(linkLabelLeetCode);
            groupBoxAboutDeveloper.Controls.Add(linkLabelGithub);
            groupBoxAboutDeveloper.Controls.Add(linkLabelLinkedIn);
            groupBoxAboutDeveloper.Controls.Add(label5);
            groupBoxAboutDeveloper.Controls.Add(label4);
            groupBoxAboutDeveloper.Dock = DockStyle.Fill;
            groupBoxAboutDeveloper.Location = new Point(490, 3);
            groupBoxAboutDeveloper.Name = "groupBoxAboutDeveloper";
            groupBoxAboutDeveloper.Size = new Size(481, 579);
            groupBoxAboutDeveloper.TabIndex = 1;
            groupBoxAboutDeveloper.TabStop = false;
            groupBoxAboutDeveloper.Text = "About Developer";
            // 
            // linkLabelEmail
            // 
            linkLabelEmail.AutoSize = true;
            linkLabelEmail.LinkColor = Color.Black;
            linkLabelEmail.Location = new Point(143, 279);
            linkLabelEmail.Name = "linkLabelEmail";
            linkLabelEmail.Size = new Size(323, 32);
            linkLabelEmail.TabIndex = 8;
            linkLabelEmail.TabStop = true;
            linkLabelEmail.Text = "ulmasaliyev2005@gmail.com";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label9.Location = new Point(6, 279);
            label9.Name = "label9";
            label9.Size = new Size(123, 32);
            label9.TabIndex = 7;
            label9.Text = "Contact : ";
            // 
            // linkLabelLeetCode
            // 
            linkLabelLeetCode.AutoSize = true;
            linkLabelLeetCode.Location = new Point(351, 208);
            linkLabelLeetCode.Name = "linkLabelLeetCode";
            linkLabelLeetCode.Size = new Size(115, 32);
            linkLabelLeetCode.TabIndex = 3;
            linkLabelLeetCode.TabStop = true;
            linkLabelLeetCode.Text = "LeetCode";
            linkLabelLeetCode.LinkClicked += linkLabelLeetCode_LinkClicked;
            // 
            // linkLabelGithub
            // 
            linkLabelGithub.AutoSize = true;
            linkLabelGithub.Location = new Point(380, 160);
            linkLabelGithub.Name = "linkLabelGithub";
            linkLabelGithub.Size = new Size(86, 32);
            linkLabelGithub.TabIndex = 3;
            linkLabelGithub.TabStop = true;
            linkLabelGithub.Text = "Github";
            linkLabelGithub.LinkClicked += linkLabelGithub_LinkClicked;
            // 
            // linkLabelLinkedIn
            // 
            linkLabelLinkedIn.AutoSize = true;
            linkLabelLinkedIn.Location = new Point(362, 114);
            linkLabelLinkedIn.Name = "linkLabelLinkedIn";
            linkLabelLinkedIn.Size = new Size(104, 32);
            linkLabelLinkedIn.TabIndex = 2;
            linkLabelLinkedIn.TabStop = true;
            linkLabelLinkedIn.Text = "Linkedin";
            linkLabelLinkedIn.LinkClicked += linkLabel1_LinkClicked;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 114);
            label5.Name = "label5";
            label5.Size = new Size(327, 32);
            label5.TabIndex = 1;
            label5.Text = "Muxammadamin Ulmasaliyev";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label4.Location = new Point(6, 71);
            label4.Name = "label4";
            label4.Size = new Size(159, 32);
            label4.TabIndex = 0;
            label4.Text = "Developer :  ";
            // 
            // menuStrip1
            // 
            menuStrip1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            menuStrip1.Dock = DockStyle.None;
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(49, 31);
            menuStrip1.TabIndex = 4;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { importShortcutsToolStripMenuItem, exportShortcutsToolStripMenuItem });
            fileToolStripMenuItem.Font = new Font("Segoe UI", 10F);
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(49, 27);
            fileToolStripMenuItem.Text = "File";
            // 
            // importShortcutsToolStripMenuItem
            // 
            importShortcutsToolStripMenuItem.Font = new Font("Segoe UI", 10F);
            importShortcutsToolStripMenuItem.Name = "importShortcutsToolStripMenuItem";
            importShortcutsToolStripMenuItem.Size = new Size(221, 28);
            importShortcutsToolStripMenuItem.Text = "Import shortcuts";
            importShortcutsToolStripMenuItem.Click += importShortcutsToolStripMenuItem_Click;
            // 
            // exportShortcutsToolStripMenuItem
            // 
            exportShortcutsToolStripMenuItem.Font = new Font("Segoe UI", 10F);
            exportShortcutsToolStripMenuItem.Name = "exportShortcutsToolStripMenuItem";
            exportShortcutsToolStripMenuItem.Size = new Size(221, 28);
            exportShortcutsToolStripMenuItem.Text = "Export shortcuts";
            exportShortcutsToolStripMenuItem.Click += exportShortcutsToolStripMenuItem_Click;
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(13F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 661);
            Controls.Add(tabControl);
            Controls.Add(menuStrip1);
            Font = new Font("Segoe UI", 14F);
            HelpButton = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Margin = new Padding(5);
            MinimumSize = new Size(1000, 700);
            Name = "MainWindow";
            RightToLeftLayout = true;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Expandit v1.2";
            Load += MainWindow_Load;
            ((System.ComponentModel.ISupportInitialize)textShortcutModelBindingSource1).EndInit();
            ((System.ComponentModel.ISupportInitialize)textShortcutModelBindingSource).EndInit();
            tabControl.ResumeLayout(false);
            tabPageShortcuts.ResumeLayout(false);
            tabPageShortcuts.PerformLayout();
            tableLayoutPanelShortcuts.ResumeLayout(false);
            tableLayoutPanelShortcuts.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            tabPagePreferences.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox6.ResumeLayout(false);
            tabPageStatistics.ResumeLayout(false);
            tabPageStatistics.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridStatistics).EndInit();
            tabPageAbout.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            groupBoxAboutApplication.ResumeLayout(false);
            groupBoxAboutApplication.PerformLayout();
            groupBoxAboutDeveloper.ResumeLayout(false);
            groupBoxAboutDeveloper.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonAdd;
		private TextBox searchBox;
		private BindingSource textShortcutModelBindingSource;
		private TabControl tabControl;
		private TabPage tabPageShortcuts;
		private TabPage tabPagePreferences;
		private Label currentTextLabel;
		private BindingSource textShortcutModelBindingSource1;
        private TableLayoutPanel tableLayoutPanel1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private Button buttonSaveSettings;
        private CheckBox checkBoxIsStrictMatching;
        private CheckBox checkBoxStartup;
        private GroupBox groupBox4;
        private GroupBox groupBox5;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem importShortcutsToolStripMenuItem;
        private ToolStripMenuItem exportShortcutsToolStripMenuItem;
        private GroupBox groupBox1;
        private CheckBox checkBoxTab;
        private CheckBox checkBoxEnter;
        private CheckBox checkBoxSpace;
        private TabPage tabPageAbout;
        private TableLayoutPanel tableLayoutPanel2;
        private GroupBox groupBoxAboutApplication;
        private Label label1;
        private GroupBox groupBoxAboutDeveloper;
        private Label label3;
        private Label label2;
        private Label label5;
        private Label label4;
        private LinkLabel linkLabelLinkedIn;
        private LinkLabel linkLabelGithub;
        private LinkLabel linkLabelLeetCode;
        private Label label6;
        private LinkLabel linkLabelSourceCode;
        private Label label8;
        private Label label7;
        private Label label9;
        private LinkLabel linkLabelEmail;
        private GroupBox groupBox6;
        private TableLayoutPanel tableLayoutPanelShortcuts;
        private DataGridView dataGridView;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn keyDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn valueDataGridViewTextBoxColumn;
        private DataGridViewButtonColumn buttonEditInCell;
        private DataGridViewButtonColumn buttonDeleteInCell;
        private TabPage tabPageStatistics;
        private Label labelTotalExpansions;
        private Label labelTotalCharsSaved;
        private Label labelTotalTimeSaved;
        private Label labelStatsHeader;
        private DateTimePicker dateTimePickerFilter;
        private Button btnRefreshStats;
        private DataGridView dataGridStatistics;
        private DataGridViewTextBoxColumn colDate;
        private DataGridViewTextBoxColumn colAppName;
        private DataGridViewTextBoxColumn colKeyPresses;
        private Label labelDailyKeypresses;
    }
}
