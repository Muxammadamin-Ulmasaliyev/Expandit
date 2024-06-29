using Newtonsoft.Json;
using Expandit.Models;
using Formatting = Newtonsoft.Json.Formatting;

namespace Expandit.Services
{
	public class TextShortcutsService
	{
		private readonly string filePath;
		private List<TextShortcutModel> shortcuts;

		public TextShortcutsService()
		{
			string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
			string appFolderPath = Path.Combine(documentsPath, "Expandit");
			if (!Directory.Exists(appFolderPath))
			{
				Directory.CreateDirectory(appFolderPath);
			}

			filePath = Path.Combine(appFolderPath, "TextShortcuts.json");

			if (!File.Exists(filePath))
			{
				File.WriteAllText(filePath, "[]");
			}
			LoadAll();
		}

		private void LoadAll()
		{
			var json = File.ReadAllText(filePath);
			shortcuts = JsonConvert.DeserializeObject<List<TextShortcutModel>>(json);
		}

		private void SaveAll()
		{
			var json = JsonConvert.SerializeObject(shortcuts, Formatting.Indented);
			File.WriteAllText(filePath, json);
		}

		public void Add(TextShortcutModel textShortcutModel)
		{
			textShortcutModel.Id = GenerateUniqueID();
			shortcuts.Add(textShortcutModel);
			SaveAll();
		}
		private int GenerateUniqueID()
		{
			int newId = shortcuts.Count > 0 ? shortcuts.Max(s => s.Id) + 1 : 1;
			return newId;
		}
		public bool IsKeyExists(string key)
		{
			return shortcuts.Exists(x => x.Key == key);
		}

		public int GetCountShortcutModelsByKey(string key)
		{
			return shortcuts.FindAll(x => x.Key == key).Count;
		}

		public void Remove(int id)
		{
			var shortcut = shortcuts.Find(sh => sh.Id == id);
			shortcuts.Remove(shortcut);
			SaveAll();
		}

		public void Update(TextShortcutModel modelToUpdate)
		{
			var index = shortcuts.FindIndex(x => x.Id == modelToUpdate.Id);
			if (index != -1)
			{
				shortcuts[index] = modelToUpdate;
				SaveAll();
			}
		}

		public TextShortcutModel Get(int id)
		{
			return shortcuts.Find(x => x.Id == id);
		}

		public List<TextShortcutModel> GetAll()
		{
			var json = File.ReadAllText(filePath);
			shortcuts = JsonConvert.DeserializeObject<List<TextShortcutModel>>(json);
			return new List<TextShortcutModel>(shortcuts);
			return new (shortcuts);
		}
	}
}
