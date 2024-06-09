namespace Expandit.View
{
	partial class AddTextShortcutWindow
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
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
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddTextShortcutWindow));
			textBoxName = new TextBox();
			textBoxKey = new TextBox();
			buttonAdd = new Button();
			textBoxValue = new RichTextBox();
			label1 = new Label();
			label2 = new Label();
			label3 = new Label();
			label4 = new Label();
			labelCategory = new Label();
			comboBoxCategories = new ComboBox();
			categoryModelBindingSource = new BindingSource(components);
			buttonCreateCategory = new Button();
			textBoxNewCategory = new TextBox();
			buttonSaveCategory = new Button();
			buttonCancelNewCategory = new Button();
			buttonCancel = new Button();
			((System.ComponentModel.ISupportInitialize)categoryModelBindingSource).BeginInit();
			SuspendLayout();
			// 
			// textBoxName
			// 
			textBoxName.Location = new Point(138, 44);
			textBoxName.Margin = new Padding(5);
			textBoxName.Name = "textBoxName";
			textBoxName.Size = new Size(759, 39);
			textBoxName.TabIndex = 0;
			textBoxName.TextChanged += textBox_TextChanged;
			// 
			// textBoxKey
			// 
			textBoxKey.Location = new Point(138, 120);
			textBoxKey.Margin = new Padding(5);
			textBoxKey.Name = "textBoxKey";
			textBoxKey.Size = new Size(329, 39);
			textBoxKey.TabIndex = 1;
			textBoxKey.TextChanged += textBox_TextChanged;
			// 
			// buttonAdd
			// 
			buttonAdd.Location = new Point(602, 430);
			buttonAdd.Margin = new Padding(5);
			buttonAdd.Name = "buttonAdd";
			buttonAdd.Size = new Size(141, 52);
			buttonAdd.TabIndex = 3;
			buttonAdd.Text = "Add";
			buttonAdd.UseVisualStyleBackColor = true;
			buttonAdd.Click += buttonAdd_Click;
			// 
			// textBoxValue
			// 
			textBoxValue.Location = new Point(138, 205);
			textBoxValue.Name = "textBoxValue";
			textBoxValue.Size = new Size(759, 205);
			textBoxValue.TabIndex = 4;
			textBoxValue.Text = "";
			textBoxValue.TextChanged += textBox_TextChanged;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(42, 47);
			label1.Name = "label1";
			label1.Size = new Size(88, 32);
			label1.TabIndex = 5;
			label1.Text = "*Name";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(14, 126);
			label2.Name = "label2";
			label2.Size = new Size(116, 32);
			label2.TabIndex = 6;
			label2.Text = "*Keyword";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(48, 205);
			label3.Name = "label3";
			label3.Size = new Size(82, 32);
			label3.TabIndex = 7;
			label3.Text = "*Value";
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Font = new Font("Segoe UI", 10F);
			label4.ForeColor = Color.DarkRed;
			label4.Location = new Point(14, 459);
			label4.Name = "label4";
			label4.Size = new Size(159, 23);
			label4.TabIndex = 8;
			label4.Text = "* are required fields";
			// 
			// labelCategory
			// 
			labelCategory.AutoSize = true;
			labelCategory.Location = new Point(475, 123);
			labelCategory.Name = "labelCategory";
			labelCategory.Size = new Size(110, 32);
			labelCategory.TabIndex = 9;
			labelCategory.Text = "Category";
			// 
			// comboBoxCategories
			// 
			comboBoxCategories.DropDownStyle = ComboBoxStyle.DropDownList;
			comboBoxCategories.FormattingEnabled = true;
			comboBoxCategories.Location = new Point(582, 120);
			comboBoxCategories.Name = "comboBoxCategories";
			comboBoxCategories.Size = new Size(186, 39);
			comboBoxCategories.TabIndex = 10;
			// 
			// categoryModelBindingSource
			// 
			categoryModelBindingSource.DataSource = typeof(Models.CategoryModel);
			// 
			// buttonCreateCategory
			// 
			buttonCreateCategory.Location = new Point(774, 116);
			buttonCreateCategory.Name = "buttonCreateCategory";
			buttonCreateCategory.Size = new Size(123, 42);
			buttonCreateCategory.TabIndex = 11;
			buttonCreateCategory.Text = "New";
			buttonCreateCategory.UseVisualStyleBackColor = true;
			buttonCreateCategory.Click += buttonCreateCategory_Click;
			// 
			// textBoxNewCategory
			// 
			textBoxNewCategory.Location = new Point(486, 120);
			textBoxNewCategory.Name = "textBoxNewCategory";
			textBoxNewCategory.PlaceholderText = "New category . . .";
			textBoxNewCategory.Size = new Size(267, 39);
			textBoxNewCategory.TabIndex = 12;
			textBoxNewCategory.Visible = false;
			textBoxNewCategory.TextChanged += textBoxNewCategory_TextChanged;
			// 
			// buttonSaveCategory
			// 
			buttonSaveCategory.Enabled = false;
			buttonSaveCategory.Location = new Point(759, 116);
			buttonSaveCategory.Name = "buttonSaveCategory";
			buttonSaveCategory.Size = new Size(97, 42);
			buttonSaveCategory.TabIndex = 13;
			buttonSaveCategory.Text = "Save";
			buttonSaveCategory.UseVisualStyleBackColor = true;
			buttonSaveCategory.Visible = false;
			buttonSaveCategory.Click += buttonSaveCategory_Click;
			// 
			// buttonCancelNewCategory
			// 
			buttonCancelNewCategory.BackColor = Color.OrangeRed;
			buttonCancelNewCategory.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
			buttonCancelNewCategory.ForeColor = SystemColors.ButtonHighlight;
			buttonCancelNewCategory.Location = new Point(855, 116);
			buttonCancelNewCategory.Name = "buttonCancelNewCategory";
			buttonCancelNewCategory.Size = new Size(42, 42);
			buttonCancelNewCategory.TabIndex = 14;
			buttonCancelNewCategory.Text = "X";
			buttonCancelNewCategory.UseVisualStyleBackColor = false;
			buttonCancelNewCategory.Visible = false;
			buttonCancelNewCategory.Click += buttonCancelNewCategory_Click;
			// 
			// buttonCancel
			// 
			buttonCancel.Location = new Point(756, 430);
			buttonCancel.Name = "buttonCancel";
			buttonCancel.Size = new Size(141, 52);
			buttonCancel.TabIndex = 15;
			buttonCancel.Text = "Cancel";
			buttonCancel.UseVisualStyleBackColor = true;
			buttonCancel.Click += buttonCancel_Click;
			// 
			// AddTextShortcutWindow
			// 
			AutoScaleDimensions = new SizeF(13F, 31F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(918, 497);
			Controls.Add(labelCategory);
			Controls.Add(buttonCancel);
			Controls.Add(label4);
			Controls.Add(label3);
			Controls.Add(label2);
			Controls.Add(label1);
			Controls.Add(textBoxValue);
			Controls.Add(buttonAdd);
			Controls.Add(textBoxKey);
			Controls.Add(textBoxName);
			Controls.Add(buttonCreateCategory);
			Controls.Add(buttonCancelNewCategory);
			Controls.Add(comboBoxCategories);
			Controls.Add(textBoxNewCategory);
			Controls.Add(buttonSaveCategory);
			Font = new Font("Segoe UI", 14F);
			FormBorderStyle = FormBorderStyle.Fixed3D;
			Icon = (Icon)resources.GetObject("$this.Icon");
			Margin = new Padding(5);
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "AddTextShortcutWindow";
			StartPosition = FormStartPosition.CenterParent;
			Text = "Add";
			((System.ComponentModel.ISupportInitialize)categoryModelBindingSource).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private TextBox textBoxName;
		private TextBox textBoxKey;
		private Button buttonAdd;
		private RichTextBox textBoxValue;
		private Label label1;
		private Label label2;
		private Label label3;
		private Label label4;
		private Label labelCategory;
		private ComboBox comboBoxCategories;
		private Button buttonCreateCategory;
		private BindingSource categoryModelBindingSource;
		private TextBox textBoxNewCategory;
		private Button buttonSaveCategory;
		private Button buttonCancelNewCategory;
		private Button buttonCancel;
	}
}