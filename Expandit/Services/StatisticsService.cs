using Newtonsoft.Json;
using static Expandit.Data.GlobalVariables;

namespace Expandit.Services;

public class StatisticsService
{
    private readonly string _filePath;
    public UserStatistics Stats { get; private set; }

    public StatisticsService()
    {
        if (!Directory.Exists(APP_FOLDER_PATH))
        {
            Directory.CreateDirectory(APP_FOLDER_PATH);
        }
        _filePath = Path.Combine(APP_FOLDER_PATH, STATS_FILENAME);
        Load();
    }

    private static readonly object _fileLock = new object();

    private void Load()
    {
        lock (_fileLock)
        {
            if (File.Exists(_filePath))
            {
                var json = File.ReadAllText(_filePath);
                Stats = JsonConvert.DeserializeObject<UserStatistics>(json) ?? new UserStatistics();
            }
            else
            {
                Stats = new UserStatistics();
            }
        }
    }

    public void Save()
    {
        lock (_fileLock)
        {
            var json = JsonConvert.SerializeObject(Stats, Formatting.Indented);
            File.WriteAllText(_filePath, json);
        }
    }

    public void RecordExpansion(int charactersSaved)
    {
        Stats.TotalExpansions++;
        Stats.TotalCharactersSaved += charactersSaved;
        Stats.TotalTimeSavedSeconds += charactersSaved * TIME_SAVED_PER_CHAR_SECONDS; 
        Save();
    }

    public void RecordKeypress(string appName)
    {
        lock (_fileLock)
        {
            string dateKey = DateTime.Now.ToString("yyyy-MM-dd");

            if (!Stats.DailyKeypresses.ContainsKey(dateKey))
            {
                Stats.DailyKeypresses[dateKey] = new Dictionary<string, int>();
            }

            if (!Stats.DailyKeypresses[dateKey].ContainsKey(appName))
            {
                Stats.DailyKeypresses[dateKey][appName] = 0;
            }

            Stats.DailyKeypresses[dateKey][appName]++;
            Save();
        }
    }
}

public class UserStatistics
{
    public int TotalExpansions { get; set; }
    public long TotalCharactersSaved { get; set; }
    public double TotalTimeSavedSeconds { get; set; }
    public Dictionary<string, Dictionary<string, int>> DailyKeypresses { get; set; } = new();
}
