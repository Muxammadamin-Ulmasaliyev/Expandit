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
			buttonCancel = new Button();
			SuspendLayout();
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Font = new Font("Segoe UI", 10F);
			label4.ForeColor = Color.DarkRed;
			label4.Location = new Point(14, 457);
			label4.Name = "label4";
			label4.Size = new Size(159, 23);
			label4.TabIndex = 23;
			label4.Text = "* are required fields";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(48, 203);
			label3.Name = "label3";
			label3.Size = new Size(82, 32);
			label3.TabIndex = 22;
			label3.Text = "*Value";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(14, 124);
			label2.Name = "label2";
			label2.Size = new Size(116, 32);
			label2.TabIndex = 21;
			label2.Text = "*Keyword";
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(42, 45);
			label1.Name = "label1";
			label1.Size = new Size(88, 32);
			label1.TabIndex = 20;
			label1.Text = "*Name";
			// 
			// textBoxValue
			// 
			textBoxValue.Location = new Point(138, 203);
			textBoxValue.Name = "textBoxValue";
			textBoxValue.Size = new Size(759, 205);
			textBoxValue.TabIndex = 19;
			textBoxValue.Text = "";
			// 
			// buttonSave
			// 
			buttonSave.Location = new Point(602, 428);
			buttonSave.Margin = new Padding(5);
			buttonSave.Name = "buttonSave";
			buttonSave.Size = new Size(141, 52);
			buttonSave.TabIndex = 18;
			buttonSave.Text = "Save";
			buttonSave.UseVisualStyleBackColor = true;
			buttonSave.Click += buttonSave_Click;
			// 
			// textBoxKey
			// 
			textBoxKey.Location = new Point(138, 118);
			textBoxKey.Margin = new Padding(5);
			textBoxKey.Name = "textBoxKey";
			textBoxKey.Size = new Size(329, 39);
			textBoxKey.TabIndex = 17;
			// 
			// textBoxName
			// 
			textBoxName.Location = new Point(138, 42);
			textBoxName.Margin = new Padding(5);
			textBoxName.Name = "textBoxName";
			textBoxName.Size = new Size(759, 39);
			textBoxName.TabIndex = 16;
			// 
			// buttonCancel
			// 
			buttonCancel.Location = new Point(756, 428);
			buttonCancel.Name = "buttonCancel";
			buttonCancel.Size = new Size(141, 52);
			buttonCancel.TabIndex = 30;
			buttonCancel.Text = "Cancel";
			buttonCancel.UseVisualStyleBackColor = true;
			buttonCancel.Click += buttonCancel_Click;
			// 
			// EditTextShortcutWindow
			// 
			AutoScaleDimensions = new SizeF(13F, 31F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(918, 497);
			Controls.Add(buttonCancel);
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
		private Button buttonSave;
		private Label label4;
		private Label label3;
		private Label label2;
		private Label label1;
		private RichTextBox textBoxValue;
		private TextBox textBoxKey;
		private TextBox textBoxName;
		private Button buttonCancel;
	}
}