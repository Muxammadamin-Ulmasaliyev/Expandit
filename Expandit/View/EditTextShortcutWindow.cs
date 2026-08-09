using Expandit.Helpers;
using Expandit.Models;
using Expandit.Services;

namespace Expandit.View;

public partial class EditTextShortcutWindow : Form
{
    private TextShortcutsService _textshortcutsService;

    private TextShortcut _textShortcutModel;

    public EditTextShortcutWindow(TextShortcutsService textShortcutsService, TextShortcut textShortcutModel)
    {
        _textshortcutsService = textShortcutsService;

        InitializeComponent();

        PopulateTextBoxes(textShortcutModel);
        CheckButtonState();
    }

    private void PopulateTextBoxes(TextShortcut textShortcutModel)
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

        _textshortcutsService.Update(new TextShortcut()
        {
            Id = _textShortcutModel.Id,
            Name = textBoxName.Text.Trim(),
            Key = textBoxKey.Text.Trim(),
            Value = textBoxValue.Text.Trim(),
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
        return TextShortcutValidator.IsValid(textBoxName.Text, textBoxKey.Text, textBoxValue.Text);
    }

    private void textBox_TextChanged(object sender, EventArgs e)
    {
        CheckButtonState();
    }

    private void buttonCancel_Click(object sender, EventArgs e)
    {
        this.Close();
    }
}
