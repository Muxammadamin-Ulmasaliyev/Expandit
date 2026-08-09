using Newtonsoft.Json;
using Expandit.Models;
using Formatting = Newtonsoft.Json.Formatting;
using static Expandit.Data.GlobalVariables;
namespace Expandit.Services;

public class TextShortcutsService
{
    private readonly string filePath;
    private List<TextShortcut> shortcuts;

    public TextShortcutsService()
    {
        if (!Directory.Exists(APP_FOLDER_PATH))
        {
            Directory.CreateDirectory(APP_FOLDER_PATH);
        }

        filePath = Path.Combine(APP_FOLDER_PATH, SHORTCUTS_FILENAME);

        if (!File.Exists(filePath))
        {
            File.WriteAllText(filePath, "[]");
        }
        LoadAll();
    }

    private void LoadAll()
    {
        var json = File.ReadAllText(filePath);
        shortcuts = JsonConvert.DeserializeObject<List<TextShortcut>>(json);
    }

    private void SaveAll()
    {
        var json = JsonConvert.SerializeObject(shortcuts, Formatting.Indented);
        File.WriteAllText(filePath, json);
    }

    public void Add(TextShortcut textShortcutModel)
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

    public void Update(TextShortcut modelToUpdate)
    {
        var index = shortcuts.FindIndex(x => x.Id == modelToUpdate.Id);
        if (index != -1)
        {
            shortcuts[index] = modelToUpdate;
            SaveAll();
        }
    }

    public TextShortcut Get(int id)
    {
        return shortcuts.Find(x => x.Id == id);
    }

    public List<TextShortcut> GetAll()
    {
        var json = File.ReadAllText(filePath);
        shortcuts = JsonConvert.DeserializeObject<List<TextShortcut>>(json);
        return new List<TextShortcut>(shortcuts);
    }

    // Export shortcuts to a specified file
    public void Export(string exportFilePath)
    {
        var data = GetAll();
        var json = JsonConvert.SerializeObject(data, Formatting.Indented);
        File.WriteAllText(exportFilePath, json);
    }

    // Import shortcuts from a specified file
    public void Import(string filePathToImport)
    {
        if (File.Exists(filePathToImport))
        {
            var json = File.ReadAllText(filePathToImport);
            var importedShortcuts = JsonConvert.DeserializeObject<List<TextShortcut>>(json);

            if (importedShortcuts == null)
            {
                MessageBox.Show($"Failed to import shortcuts, {filePathToImport} does not contain a valid shortcut list", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (var importedShortcut in importedShortcuts)
            {
                // Check if a shortcut with the same key exists
                if (!shortcuts.Any(existing => existing.Key == importedShortcut.Key))
                {
                    // If the imported shortcut ID exists, generate a new unique ID
                    if (shortcuts.Any(existing => existing.Id == importedShortcut.Id))
                    {
                        importedShortcut.Id = GenerateUniqueID();
                    }

                    // Add the imported shortcut
                    shortcuts.Add(importedShortcut);
                }
            }
            SaveAll();
            LoadAll();
        }
        else
        {
            MessageBox.Show($"Failed to import shortcuts,{filePathToImport} file not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
    }
}
