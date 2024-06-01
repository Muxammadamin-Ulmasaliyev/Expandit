namespace Expandit.View
{
	partial class EditTextShortcutWindow
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditTextShortcutWindow));
			label4 = new Label();
			label3 = new Label();
			label2 = new Label();
			label1 = new Label();
			textBoxValue = new RichTextBox();
			buttonSave = new Button();
			textBoxKey = new TextBox();
			textBoxName = new TextBox();
			SuspendLayout();
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Font = new Font("Segoe UI", 10F);
			label4.ForeColor = Color.DarkRed;
			label4.Location = new Point(368, 452);
			label4.Name = "label4";
			label4.Size = new Size(159, 23);
			label4.TabIndex = 16;
			label4.Text = "* are required fields";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(19, 252);
			label3.Name = "label3";
			label3.Size = new Size(94, 32);
			label3.TabIndex = 15;
			label3.Text = "*Value :";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(38, 136);
			label2.Name = "label2";
			label2.Size = new Size(75, 32);
			label2.TabIndex = 14;
			label2.Text = "*Key :";
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(13, 56);
			label1.Name = "label1";
			label1.Size = new Size(100, 32);
			label1.TabIndex = 13;
			label1.Text = "*Name :";
			// 
			// textBoxValue
			// 
			textBoxValue.Location = new Point(120, 214);
			textBoxValue.Name = "textBoxValue";
			textBoxValue.Size = new Size(380, 123);
			textBoxValue.TabIndex = 12;
			textBoxValue.Text = "";
			textBoxValue.TextChanged += textBox_TextChanged;
			// 
			// buttonSave
			// 
			buttonSave.Location = new Point(168, 377);
			buttonSave.Margin = new Padding(5);
			buttonSave.Name = "buttonSave";
			buttonSave.Size = new Size(188, 67);
			buttonSave.TabIndex = 11;
			buttonSave.Text = "Save";
			buttonSave.UseVisualStyleBackColor = true;
			buttonSave.Click += buttonSave_Click;
			// 
			// textBoxKey
			// 
			textBoxKey.Location = new Point(120, 133);
			textBoxKey.Margin = new Padding(5);
			textBoxKey.Name = "textBoxKey";
			textBoxKey.Size = new Size(380, 39);
			textBoxKey.TabIndex = 10;
			textBoxKey.TextChanged += textBox_TextChanged;
			// 
			// textBoxName
			// 
			textBoxName.Location = new Point(120, 53);
			textBoxName.Margin = new Padding(5);
			textBoxName.Name = "textBoxName";
			textBoxName.Size = new Size(380, 39);
			textBoxName.TabIndex = 9;
			textBoxName.TextChanged += textBox_TextChanged;
			// 
			// EditTextShortcutWindow
			// 
			AutoScaleDimensions = new SizeF(13F, 31F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(540, 484);
			Controls.Add(label4);
			Controls.Add(label3);
			Controls.Add(label2);
			Controls.Add(label1);
			Controls.Add(textBoxValue);
			Controls.Add(buttonSave);
			Controls.Add(textBoxKey);
			Controls.Add(textBoxName);
			Font = new Font("Segoe UI", 14F);
			FormBorderStyle = FormBorderStyle.Fixed3D;
			Icon = (Icon)resources.GetObject("$this.Icon");
			Margin = new Padding(5);
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "EditTextShortcutWindow";
			Text = "Edit";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label label3;
		private Label label2;
		private Label label1;
		private RichTextBox textBoxValue;
		private Button buttonSave;
		private TextBox textBoxKey;
		private TextBox textBoxName;
		private Label label4;
		private Button buttonAdd;
	}
}