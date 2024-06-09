using Expandit.Models;
using Expandit.Services;

namespace Expandit.View
{
	public partial class EditTextShortcutWindow : Form
	{
		private TextShortcutsService _textshortcutsService;
		private CategoryService _categoriesService;

		private TextShortcutModel _textShortcutModel;


		public EditTextShortcutWindow(TextShortcutModel textShortcutModel)
		{
			_textshortcutsService = new TextShortcutsService();
			_categoriesService = new CategoryService();

			InitializeComponent();

			PopulateTextBoxes(textShortcutModel);
			PopulateCategoriesComboBox(textShortcutModel);
			CheckButtonState();
		}
		private void PopulateCategoriesComboBox(TextShortcutModel textShortcutModel)
		{
			var categories = _categoriesService.GetAll();

			var combinedCategories = new List<CategoryModel>();

			combinedCategories.AddRange(categories);

			if (textShortcutModel.CategoryId == null)
			{
				combinedCategories.Insert(0, new CategoryModel { Id = -1, Name = "Uncategorized" });
			}
			else
			{

				combinedCategories.Insert(0, categories.FirstOrDefault(c => c.Id == textShortcutModel.CategoryId));
			}


			comboBoxCategories.DataSource = combinedCategories;

			comboBoxCategories.DisplayMember = "Name"; // Property name to display
			comboBoxCategories.ValueMember = "Id";
			// Property name for valueperty name for value
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
				Value = textBoxValue.Text,
				CategoryId = (comboBoxCategories.SelectedItem as CategoryModel).Id
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

		private void buttonCreateCategory_Click(object sender, EventArgs e)
		{
			labelCategory.Visible = false;
			comboBoxCategories.Visible = false;
			buttonCreateCategory.Visible = false;

			buttonCancelNewCategory.Visible = true;
			textBoxNewCategory.Visible = true;
			buttonSaveCategory.Visible = true;

		}

		private void textBoxNewCategory_TextChanged(object sender, EventArgs e)
		{
			buttonSaveCategory.Enabled = IsCategoryNameValid();

		}
		private bool IsCategoryNameValid()
		{
			if (string.IsNullOrWhiteSpace(textBoxNewCategory.Text) || textBoxNewCategory.Text == string.Empty)
			{
				return false;
			}

			return true;
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

			PopulateCategoriesComboBox(_textShortcutModel);


			textBoxNewCategory.Text = string.Empty;


			labelCategory.Visible = true;
			comboBoxCategories.Visible = true;
			buttonCreateCategory.Visible = true;


			buttonCancelNewCategory.Visible = false;
			textBoxNewCategory.Visible = false;
			buttonSaveCategory.Visible = false;
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
