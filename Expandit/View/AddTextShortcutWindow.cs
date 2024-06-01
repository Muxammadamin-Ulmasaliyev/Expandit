using Expandit.Models;
using Expandit.Services;

namespace Expandit.View
{
	public partial class AddTextShortcutWindow : Form
	{
		private TextShortcutsService _textshortcutsService;
		public AddTextShortcutWindow()
		{
			_textshortcutsService = new TextShortcutsService();
			InitializeComponent();
			CheckButtonState();
		}

		private void CheckButtonState()
		{
			if (IsModelStateValid())
			{
				buttonAdd.Enabled = true;
			}
			else
			{
				buttonAdd.Enabled = false;
			}
		}
		private bool IsKeyExists(string key)
		{
			return _textshortcutsService.IsKeyExists(key);
		}

		private void buttonAdd_Click(object sender, EventArgs e)
		{
			if (IsKeyExists(textBoxKey.Text))
			{
				MessageBox.Show("Shortcut key should be unique!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
				return;
			}

			var textShortcut = new TextShortcutModel() { Key = textBoxKey.Text, Name = textBoxName.Text, Value = textBoxValue.Text };
			_textshortcutsService.Add(textShortcut);
			MessageBox.Show("Shortcut added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
			ClearAllTextBoxes();
		}

		private void textBox_TextChanged(object sender, EventArgs e)
		{
			CheckButtonState();
		}

		private bool IsModelStateValid()
		{
			bool result = true;
			if (textBoxName.Text == string.Empty || string.IsNullOrWhiteSpace(textBoxName.Text))
			{
				//ShowErrorForTextBox(textBoxName);
				result = result && false;
			}
			else
			{
				//ShowSuccessForTextBox(textBoxName);
			}
			if (textBoxKey.Text == string.Empty || string.IsNullOrWhiteSpace(textBoxKey.Text))
			{
				//ShowErrorForTextBox(textBoxKey);
				result = result && false;

			}
			else
			{
				//ShowSuccessForTextBox(textBoxKey);
			}
			if (textBoxValue.Text == string.Empty || string.IsNullOrWhiteSpace(textBoxValue.Text))
			{
				//ShowErrorForTextBox(textBoxValue);
				result = result && false;
			}
			else
			{
				//ShowSuccessForTextBox(textBoxValue);
			}
			return result;

		}



		private void ClearAllTextBoxes()
		{
			textBoxKey.Text = string.Empty;
			textBoxName.Text = string.Empty;
			textBoxValue.Text = string.Empty;
		}
	}
}
