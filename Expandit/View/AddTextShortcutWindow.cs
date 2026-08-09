using Expandit.Helpers;
using Expandit.Models;
using Expandit.Services;

namespace Expandit.View;

public partial class AddTextShortcutWindow : Form
{
	private TextShortcutsService _textshortcutsService;
	public AddTextShortcutWindow(TextShortcutsService textShortcutsService)
	{
		_textshortcutsService = textShortcutsService;
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

		var textShortcut = new TextShortcut()
		{
			Key = textBoxKey.Text.Trim(),
			Name = textBoxName.Text.Trim(),
			Value = textBoxValue.Text.Trim(),
		};
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
		return TextShortcutValidator.IsValid(textBoxName.Text, textBoxKey.Text, textBoxValue.Text);
	}

	private void ClearAllTextBoxes()
	{
		textBoxKey.Text = string.Empty;
		textBoxName.Text = string.Empty;
		textBoxValue.Text = string.Empty;

	}

	private void buttonCancel_Click(object sender, EventArgs e)
	{
		this.Close();
	}
}
