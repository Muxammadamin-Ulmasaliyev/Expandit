﻿using Newtonsoft.Json;
using Expandit.Models;
using Formatting = Newtonsoft.Json.Formatting;

namespace Expandit.Services
{
	public class TextShortcutsService
	{
<<<<<<< HEAD
		private readonly string filePath;
=======
		private readonly string filePath = "TextShortcuts.json";
>>>>>>> cd28171602855217b51fa7555c05c2674e89de02
		private List<TextShortcutModel> shortcuts;

		public TextShortcutsService()
		{
<<<<<<< HEAD
			string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
			string appFolderPath = Path.Combine(documentsPath, "Expandit");
			if (!Directory.Exists(appFolderPath))
			{
				Directory.CreateDirectory(appFolderPath);
			}

			filePath = Path.Combine(appFolderPath, "TextShortcuts.json");

=======
>>>>>>> cd28171602855217b51fa7555c05c2674e89de02
			if (!File.Exists(filePath))
			{
				File.WriteAllText(filePath, "[]");
			}
<<<<<<< HEAD


=======
>>>>>>> cd28171602855217b51fa7555c05c2674e89de02
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
			shortcuts.Add(textShortcutModel);
			SaveAll();
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
			var shortcut = shortcuts.Find(x => x.Id == id);
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
<<<<<<< HEAD
			return new List<TextShortcutModel>(shortcuts);
=======
			return new (shortcuts);
>>>>>>> cd28171602855217b51fa7555c05c2674e89de02
		}
	}
}
