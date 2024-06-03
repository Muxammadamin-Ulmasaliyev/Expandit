using Expandit.Data;
using Expandit.Models;
using Expandit.Services;

namespace Expandit.View
{
	public partial class AddTextShortcutWindow : Form
	{
		private TextShortcutsService _textshortcutsService;
		private CategoryService _categoriesService;
		public AddTextShortcutWindow()
		{
			_textshortcutsService = new TextShortcutsService();
			_categoriesService = new CategoryService();
			InitializeComponent();

			PopulateCategoriesComboBox();
			CheckButtonState();
		}

		private void PopulateCategoriesComboBox()
		{
			var categories = _categoriesService.GetAll();
			comboBoxCategories.DataSource = categories;
			comboBoxCategories.DisplayMember = "Name"; // Property name to display
			comboBoxCategories.ValueMember = "Id"; // Property name for value
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

		private void buttonCreateCategory_Click(object sender, EventArgs e)
		{
			labelCategory.Visible = false;
			comboBoxCategories.Visible = false;
			buttonCreateCategory.Visible = false;

			buttonCancelNewCategory.Visible = true;
			textBoxNewCategory.Visible = true;
			buttonSaveCategory.Visible = true;

		}

		private void buttonSaveCategory_Click(object sender, EventArgs e)
		{
			if (_categoriesService.IsNameExists(textBoxNewCategory.Text))
			{
				MessageBox.Show("Category name should be unique!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
				return;
			}

			_categoriesService.Add(new CategoryModel() { Name = textBoxNewCategory.Text });
			MessageBox.Show("Category added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

			PopulateCategoriesComboBox();


			textBoxNewCategory.Text = string.Empty;


			labelCategory.Visible = true;
			comboBoxCategories.Visible = true;
			buttonCreateCategory.Visible = true;


			buttonCancelNewCategory.Visible = false;
			textBoxNewCategory.Visible = false;
			buttonSaveCategory.Visible = false;
		}

		private bool IsCategoryNameValid()
		{
			if (string.IsNullOrWhiteSpace(textBoxNewCategory.Text) || textBoxNewCategory.Text == string.Empty)
			{
				return false;
			}

			return true;
		}

		private void textBoxNewCategory_TextChanged(object sender, EventArgs e)
		{
			buttonSaveCategory.Enabled = IsCategoryNameValid();
		}

		private void buttonCancelNewCategory_Click(object sender, EventArgs e)
		{
			textBoxNewCategory.Text = string.Empty;

			labelCategory.Visible = true;
			comboBoxCategories.Visible = true;
			buttonCreateCategory.Visible = true;


			buttonCancelNewCategory.Visible = false;
			textBoxNewCategory.Visible = false;
			buttonSaveCategory.Visible = false;
		}

		private void buttonCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
