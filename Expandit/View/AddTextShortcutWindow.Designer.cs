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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddTextShortcutWindow));
			textBoxName = new TextBox();
			textBoxKey = new TextBox();
			buttonAdd = new Button();
			textBoxValue = new RichTextBox();
			label1 = new Label();
			label2 = new Label();
			label3 = new Label();
			label4 = new Label();
			SuspendLayout();
			// 
			// textBoxName
			// 
			textBoxName.Location = new Point(121, 53);
			textBoxName.Margin = new Padding(5);
			textBoxName.Name = "textBoxName";
			textBoxName.Size = new Size(380, 39);
			textBoxName.TabIndex = 0;
			textBoxName.TextChanged += textBox_TextChanged;
			// 
			// textBoxKey
			// 
			textBoxKey.Location = new Point(121, 133);
			textBoxKey.Margin = new Padding(5);
			textBoxKey.Name = "textBoxKey";
			textBoxKey.Size = new Size(380, 39);
			textBoxKey.TabIndex = 1;
			textBoxKey.TextChanged += textBox_TextChanged;
			// 
			// buttonAdd
			// 
			buttonAdd.Location = new Point(169, 377);
			buttonAdd.Margin = new Padding(5);
			buttonAdd.Name = "buttonAdd";
			buttonAdd.Size = new Size(188, 67);
			buttonAdd.TabIndex = 3;
			buttonAdd.Text = "Add";
			buttonAdd.UseVisualStyleBackColor = true;
			buttonAdd.Click += buttonAdd_Click;
			// 
			// textBoxValue
			// 
			textBoxValue.Location = new Point(121, 214);
			textBoxValue.Name = "textBoxValue";
			textBoxValue.Size = new Size(380, 123);
			textBoxValue.TabIndex = 4;
			textBoxValue.Text = "";
			textBoxValue.TextChanged += textBox_TextChanged;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(14, 56);
			label1.Name = "label1";
			label1.Size = new Size(100, 32);
			label1.TabIndex = 5;
			label1.Text = "*Name :";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(39, 136);
			label2.Name = "label2";
			label2.Size = new Size(75, 32);
			label2.TabIndex = 6;
			label2.Text = "*Key :";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(20, 252);
			label3.Name = "label3";
			label3.Size = new Size(94, 32);
			label3.TabIndex = 7;
			label3.Text = "*Value :";
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Font = new Font("Segoe UI", 10F);
			label4.ForeColor = Color.DarkRed;
			label4.Location = new Point(369, 452);
			label4.Name = "label4";
			label4.Size = new Size(159, 23);
			label4.TabIndex = 8;
			label4.Text = "* are required fields";
			// 
			// AddTextShortcutWindow
			// 
			AutoScaleDimensions = new SizeF(13F, 31F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(540, 484);
			Controls.Add(label4);
			Controls.Add(label3);
			Controls.Add(label2);
			Controls.Add(label1);
			Controls.Add(textBoxValue);
			Controls.Add(buttonAdd);
			Controls.Add(textBoxKey);
			Controls.Add(textBoxName);
			Font = new Font("Segoe UI", 14F);
			FormBorderStyle = FormBorderStyle.Fixed3D;
			Icon = (Icon)resources.GetObject("$this.Icon");
			Margin = new Padding(5);
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "AddTextShortcutWindow";
			StartPosition = FormStartPosition.CenterParent;
			Text = "Add";
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
	}
}