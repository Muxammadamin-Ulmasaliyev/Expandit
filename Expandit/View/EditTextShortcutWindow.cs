using Expandit.Models;
using Expandit.Services;

namespace Expandit.View
{
	public partial class EditTextShortcutWindow : Form
	{
		private TextShortcutsService _textshortcutsService;

		private TextShortcutModel _textShortcutModel;


		public EditTextShortcutWindow(TextShortcutModel textShortcutModel)
		{
			_textshortcutsService = new TextShortcutsService();

			InitializeComponent();

			PopulateTextBoxes(textShortcutModel);

			CheckButtonState();
		}


		private void PopulateTextBoxes(TextShortcutModel textShortcutModel)
		{
			_textShortcutModel = textShortcutModel;
			textBoxName.Text = textShortcutModel.Name;
			textBoxKey.Text = textShortcutModel.Key;
			textBoxValue.Text = textShortcutModel.Value;
		}


		private void CheckButtonState()
		{
			if (IsModelStateValid())
			{
				buttonSave.Enabled = true;
			}
			else
			{
				buttonSave.Enabled = false;
			}
		}


		private void buttonSave_Click(object sender, EventArgs e)
		{


			if (!string.Equals(_textShortcutModel.Key, textBoxKey.Text))
			{
				if (IsKeyExists(textBoxKey.Text))
				{
					MessageBox.Show("Shortcut key should be unique!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
					return;
				}
			}

			_textshortcutsService.Update(new TextShortcutModel()
			{
				Id = _textShortcutModel.Id,
				Name = textBoxName.Text,
				Key = textBoxKey.Text,
				Value = textBoxValue.Text
			});
			MessageBox.Show("Shortcut updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
			this.Close();

		}

		private bool IsKeyExists(string key)
		{
			return _textshortcutsService.IsKeyExists(key);
		}




		private bool IsModelStateValid()
		{
			bool result = true;
			if (textBoxName.Text == string.Empty || string.IsNullOrWhiteSpace(textBoxName.Text))
			{
				//ShowErrorForTextBox(tbName);
				result = result && false;
			}
			else
			{
				//ShowSuccessForTextBox(tbName);
			}
			if (textBoxKey.Text == string.Empty || string.IsNullOrWhiteSpace(textBoxKey.Text))
			{
				//ShowErrorForTextBox(tbKey);
				result = result && false;

			}
			else
			{
				//ShowSuccessForTextBox(tbKey);
			}
			if (textBoxValue.Text == string.Empty || string.IsNullOrWhiteSpace(textBoxValue.Text))
			{
				//ShowErrorForTextBox(tbValue);
				result = result && false;
			}
			else
			{
				//ShowSuccessForTextBox(tbValue);
			}
			return result;

		}

		private void textBox_TextChanged(object sender, EventArgs e)
		{
			CheckButtonState();
		}
	}
}
