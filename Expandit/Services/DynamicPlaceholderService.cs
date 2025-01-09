using Expandit.Models;
using Newtonsoft.Json;
using static Expandit.Data.GlobalVariables;
namespace Expandit.Services;

public class DynamicPlaceholderService
{
    private readonly string filePath;
    private List<DynamicPlaceholder> placeholders;
    private readonly TextShortcutsService _textShortcutService;

    public DynamicPlaceholderService()
    {
        _textShortcutService = new();
        if (!Directory.Exists(APP_FOLDER_PATH))
        {
            Directory.CreateDirectory(APP_FOLDER_PATH);
        }

        filePath = Path.Combine(APP_FOLDER_PATH, DYNAMIC_PLACEHOLDERS_FILENAME);

        if (!File.Exists(filePath))
        {
            File.WriteAllText(filePath, "[]");
        }
        LoadAll();
    }

    public string GetValueAccordingToCommand(DynamicPlaceholder placeholder)
    {
        return placeholder.Command switch
        {
            DynamicPlaceholderEnum.DateTime => DateTime.Now.ToLongDateString(),
            _ => ""
        };
    }
    private void LoadAll()
    {
        var json = File.ReadAllText(filePath);
        placeholders = JsonConvert.DeserializeObject<List<DynamicPlaceholder>>(json);
    }

    private void SaveAll()
    {
        var json = JsonConvert.SerializeObject(placeholders, Formatting.Indented);
        File.WriteAllText(filePath, json);
    }



    public bool IsKeyExists(string key)
    {
        return placeholders.Exists(x => x.Key == key);
    }

    public bool Update(DynamicPlaceholder modelToUpdate)
    {
        var isShortcutExist = _textShortcutService.IsKeyExists(modelToUpdate.Key);
        if (isShortcutExist)
        {
            return false;
        }
        var index = placeholders.FindIndex(x => x.Command == modelToUpdate.Command);
        if (index != -1)
        {
            placeholders[index] = modelToUpdate;
            SaveAll();
        }
        return true;
    }

    public DynamicPlaceholder Get(string key)
    {
        return placeholders.Find(x => x.Key == key);
    }

    public List<DynamicPlaceholder> GetAll()
    {
        var json = File.ReadAllText(filePath);
        placeholders = JsonConvert.DeserializeObject<List<DynamicPlaceholder>>(json);
        return new List<DynamicPlaceholder>(placeholders);
    }

}
