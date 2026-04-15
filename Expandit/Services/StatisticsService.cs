using Newtonsoft.Json;
using System.Timers;
using static Expandit.Data.GlobalVariables;

namespace Expandit.Services;

public class StatisticsService : IDisposable
{
    private readonly string _filePath;
    private readonly System.Timers.Timer _saveTimer;
    private bool _isDirty = false;
    public UserStatistics Stats { get; private set; }

    public StatisticsService()
    {
        if (!Directory.Exists(APP_FOLDER_PATH))
        {
            Directory.CreateDirectory(APP_FOLDER_PATH);
        }
        _filePath = Path.Combine(APP_FOLDER_PATH, STATS_FILENAME);
        Load();

        // Initialize timer to save every 30 minutes
        _saveTimer = new System.Timers.Timer(1800000);
        _saveTimer.Elapsed += (s, e) => Flush();
        _saveTimer.AutoReset = true;
        _saveTimer.Start();
    }

    private static readonly object _stateLock = new object();
    private static readonly object _fileLock = new object();

    private void Load()
    {
        lock (_fileLock)
        {
            if (File.Exists(_filePath))
            {
                try
                {
                    var json = File.ReadAllText(_filePath);
                    Stats = JsonConvert.DeserializeObject<UserStatistics>(json) ?? new UserStatistics();
                }
                catch
                {
                    Stats = new UserStatistics();
                }
            }
            else
            {
                Stats = new UserStatistics();
            }
        }
    }

    /// <summary>
    /// Persists in-memory statistics to file if there are unsaved changes.
    /// </summary>
    public void Flush()
    {
        if (!_isDirty) return;

        lock (_fileLock)
        {
            string json;
            lock (_stateLock)
            {
                if (!_isDirty) return;
                json = JsonConvert.SerializeObject(Stats, Formatting.Indented);
                _isDirty = false;
            }

            try
            {
                File.WriteAllText(_filePath, json);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Failed to save stats: {ex.Message}");
                // If save fails, we might want to set dirty back to true, 
                // but for simplicity we'll just log it.
            }
        }
    }

    public void RecordExpansion(int charactersSaved)
    {
        lock (_stateLock)
        {
            Stats.TotalExpansions++;
            Stats.TotalCharactersSaved += charactersSaved;
            Stats.TotalTimeSavedSeconds += charactersSaved * TIME_SAVED_PER_CHAR_SECONDS;
            _isDirty = true;
        }
    }

    public void RecordKeypress(string appName)
    {
        lock (_stateLock)
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
            _isDirty = true;
        }
    }

    public void Dispose()
    {
        _saveTimer?.Stop();
        _saveTimer?.Dispose();
        Flush();
    }
}

public class UserStatistics
{
    public int TotalExpansions { get; set; }
    public long TotalCharactersSaved { get; set; }
    public double TotalTimeSavedSeconds { get; set; }
    public Dictionary<string, Dictionary<string, int>> DailyKeypresses { get; set; } = new();
}
