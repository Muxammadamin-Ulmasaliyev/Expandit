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
            dataGridView = new DataGridView();
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            keyDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            valueDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            buttonEditInCell = new DataGridViewButtonColumn();
            buttonDeleteInCell = new DataGridViewButtonColumn();
            textShortcutModelBindingSource1 = new BindingSource(components);
            buttonAdd = new Button();
            searchBox = new TextBox();
            textShortcutModelBindingSource = new BindingSource(components);
            tabControl = new TabControl();
            tabPageShortcuts = new TabPage();
            currentTextLabel = new Label();
            tabPagePreferences = new TabPage();
            tableLayoutPanel1 = new TableLayoutPanel();
            groupBox2 = new GroupBox();
            checkBoxIsStrictMatching = new CheckBox();
            checkBoxStartup = new CheckBox();
            groupBox3 = new GroupBox();
            groupBox4 = new GroupBox();
            groupBox5 = new GroupBox();
            groupBox6 = new GroupBox();
            buttonSaveSettings = new Button();
            groupBox1 = new GroupBox();
            checkBoxTab = new CheckBox();
            checkBoxEnter = new CheckBox();
            checkBoxSpace = new CheckBox();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            importShortcutsToolStripMenuItem = new ToolStripMenuItem();
            exportShortcutsToolStripMenuItem = new ToolStripMenuItem();
            tabPageAbout = new TabPage();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)textShortcutModelBindingSource1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)textShortcutModelBindingSource).BeginInit();
            tabControl.SuspendLayout();
            tabPageShortcuts.SuspendLayout();
            tabPagePreferences.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox6.SuspendLayout();
            groupBox1.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AllowUserToOrderColumns = true;
            dataGridView.AutoGenerateColumns = false;
            dataGridView.BackgroundColor = SystemColors.Control;
            dataGridView.BorderStyle = BorderStyle.None;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, nameDataGridViewTextBoxColumn, keyDataGridViewTextBoxColumn, valueDataGridViewTextBoxColumn, buttonEditInCell, buttonDeleteInCell });
            dataGridView.DataSource = textShortcutModelBindingSource1;
            dataGridView.Location = new Point(8, 119);
            dataGridView.MultiSelect = false;
            dataGridView.Name = "dataGridView";
            dataGridView.ReadOnly = true;
            dataGridView.RowHeadersWidth = 51;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.Size = new Size(952, 478);
            dataGridView.TabIndex = 4;
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
            nameDataGridViewTextBoxColumn.MinimumWidth = 140;
            nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            nameDataGridViewTextBoxColumn.ReadOnly = true;
            nameDataGridViewTextBoxColumn.Width = 140;
            // 
            // keyDataGridViewTextBoxColumn
            // 
            keyDataGridViewTextBoxColumn.DataPropertyName = "Key";
            keyDataGridViewTextBoxColumn.HeaderText = "Key";
            keyDataGridViewTextBoxColumn.MinimumWidth = 140;
            keyDataGridViewTextBoxColumn.Name = "keyDataGridViewTextBoxColumn";
            keyDataGridViewTextBoxColumn.ReadOnly = true;
            keyDataGridViewTextBoxColumn.Width = 140;
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
            // buttonEditInCell
            // 
            buttonEditInCell.HeaderText = "";
            buttonEditInCell.MinimumWidth = 6;
            buttonEditInCell.Name = "buttonEditInCell";
            buttonEditInCell.ReadOnly = true;
            buttonEditInCell.Resizable = DataGridViewTriState.True;
            buttonEditInCell.SortMode = DataGridViewColumnSortMode.Automatic;
            buttonEditInCell.Text = "Edit";
            buttonEditInCell.UseColumnTextForButtonValue = true;
            buttonEditInCell.Width = 125;
            // 
            // buttonDeleteInCell
            // 
            buttonDeleteInCell.HeaderText = "";
            buttonDeleteInCell.MinimumWidth = 6;
            buttonDeleteInCell.Name = "buttonDeleteInCell";
            buttonDeleteInCell.ReadOnly = true;
            buttonDeleteInCell.Text = "Delete";
            buttonDeleteInCell.UseColumnTextForButtonValue = true;
            buttonDeleteInCell.Width = 125;
            // 
            // textShortcutModelBindingSource1
            // 
            textShortcutModelBindingSource1.DataSource = typeof(Models.TextShortcut);
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
            // textShortcutModelBindingSource
            // 
            textShortcutModelBindingSource.DataSource = typeof(Models.TextShortcut);
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabPageShortcuts);
            tabControl.Controls.Add(tabPagePreferences);
            tabControl.Controls.Add(tabPageAbout);
            tabControl.Dock = DockStyle.Fill;
            tabControl.Location = new Point(0, 31);
            tabControl.Margin = new Padding(5);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(982, 618);
            tabControl.TabIndex = 3;
            tabControl.SelectedIndexChanged += tabControl_SelectedIndexChanged;
            // 
            // tabPageShortcuts
            // 
            tabPageShortcuts.Controls.Add(dataGridView);
            tabPageShortcuts.Controls.Add(currentTextLabel);
            tabPageShortcuts.Controls.Add(buttonAdd);
            tabPageShortcuts.Controls.Add(searchBox);
            tabPageShortcuts.Location = new Point(4, 40);
            tabPageShortcuts.Name = "tabPageShortcuts";
            tabPageShortcuts.Padding = new Padding(3);
            tabPageShortcuts.Size = new Size(974, 574);
            tabPageShortcuts.TabIndex = 0;
            tabPageShortcuts.Text = "Shortcuts";
            tabPageShortcuts.UseVisualStyleBackColor = true;
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
            tabPagePreferences.Location = new Point(4, 40);
            tabPagePreferences.Name = "tabPagePreferences";
            tabPagePreferences.Padding = new Padding(3);
            tabPagePreferences.Size = new Size(974, 574);
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
            tableLayoutPanel1.Controls.Add(groupBox6, 1, 2);
            tableLayoutPanel1.Controls.Add(groupBox1, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(3, 3);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 34F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(968, 568);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(checkBoxIsStrictMatching);
            groupBox2.Controls.Add(checkBoxStartup);
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Location = new Point(3, 190);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(478, 187);
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
            checkBoxStartup.Location = new Point(18, 38);
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
            groupBox3.Location = new Point(3, 383);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(478, 182);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            groupBox3.Text = "Predefined shortcuts";
            // 
            // groupBox4
            // 
            groupBox4.Dock = DockStyle.Fill;
            groupBox4.Location = new Point(487, 3);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(478, 181);
            groupBox4.TabIndex = 4;
            groupBox4.TabStop = false;
            // 
            // groupBox5
            // 
            groupBox5.Dock = DockStyle.Fill;
            groupBox5.Location = new Point(487, 190);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(478, 187);
            groupBox5.TabIndex = 5;
            groupBox5.TabStop = false;
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(buttonSaveSettings);
            groupBox6.Dock = DockStyle.Fill;
            groupBox6.Location = new Point(487, 383);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new Size(478, 182);
            groupBox6.TabIndex = 6;
            groupBox6.TabStop = false;
            // 
            // buttonSaveSettings
            // 
            buttonSaveSettings.Enabled = false;
            buttonSaveSettings.Location = new Point(334, 129);
            buttonSaveSettings.Name = "buttonSaveSettings";
            buttonSaveSettings.Size = new Size(138, 48);
            buttonSaveSettings.TabIndex = 0;
            buttonSaveSettings.Text = "Save";
            buttonSaveSettings.UseVisualStyleBackColor = true;
            buttonSaveSettings.Click += buttonSaveSettings_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(checkBoxTab);
            groupBox1.Controls.Add(checkBoxEnter);
            groupBox1.Controls.Add(checkBoxSpace);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(3, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(478, 181);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Trigger Key";
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
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(982, 31);
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
            importShortcutsToolStripMenuItem.Size = new Size(224, 28);
            importShortcutsToolStripMenuItem.Text = "Import shortcuts";
            importShortcutsToolStripMenuItem.Click += importShortcutsToolStripMenuItem_Click;
            // 
            // exportShortcutsToolStripMenuItem
            // 
            exportShortcutsToolStripMenuItem.Font = new Font("Segoe UI", 10F);
            exportShortcutsToolStripMenuItem.Name = "exportShortcutsToolStripMenuItem";
            exportShortcutsToolStripMenuItem.Size = new Size(224, 28);
            exportShortcutsToolStripMenuItem.Text = "Export shortcuts";
            exportShortcutsToolStripMenuItem.Click += exportShortcutsToolStripMenuItem_Click;
            // 
            // tabPageAbout
            // 
            tabPageAbout.Location = new Point(4, 40);
            tabPageAbout.Name = "tabPageAbout";
            tabPageAbout.Size = new Size(974, 574);
            tabPageAbout.TabIndex = 2;
            tabPageAbout.Text = "About";
            tabPageAbout.UseVisualStyleBackColor = true;
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(13F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(982, 649);
            Controls.Add(tabControl);
            Controls.Add(menuStrip1);
            Font = new Font("Segoe UI", 14F);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            HelpButton = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Margin = new Padding(5);
            MaximizeBox = false;
            Name = "MainWindow";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Expandit";
            Load += MainWindow_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)textShortcutModelBindingSource1).EndInit();
            ((System.ComponentModel.ISupportInitialize)textShortcutModelBindingSource).EndInit();
            tabControl.ResumeLayout(false);
            tabPageShortcuts.ResumeLayout(false);
            tabPageShortcuts.PerformLayout();
            tabPagePreferences.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox6.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
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
		private DataGridView dataGridView;
		private BindingSource textShortcutModelBindingSource1;
		private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn keyDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn valueDataGridViewTextBoxColumn;
		private DataGridViewButtonColumn buttonEditInCell;
		private DataGridViewButtonColumn buttonDeleteInCell;
        private TableLayoutPanel tableLayoutPanel1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private Button buttonSaveSettings;
        private CheckBox checkBoxIsStrictMatching;
        private CheckBox checkBoxStartup;
        private GroupBox groupBox4;
        private GroupBox groupBox5;
        private GroupBox groupBox6;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem importShortcutsToolStripMenuItem;
        private ToolStripMenuItem exportShortcutsToolStripMenuItem;
        private GroupBox groupBox1;
        private CheckBox checkBoxTab;
        private CheckBox checkBoxEnter;
        private CheckBox checkBoxSpace;
        private TabPage tabPageAbout;
    }
}
