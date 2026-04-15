namespace Expandit.Data;

public static class GlobalVariables
{
    public const string ICON_NAME = "icon.ico";
    public const string LOGO_NAME = "Assets/expandit_logo.png";
    public const string APP_NAME = "Expandit";
    public const string SHORTCUTS_FILENAME = "TextShortcuts.json";
    public const string STATS_FILENAME = "Stats.json";
    public const double TIME_SAVED_PER_CHAR_SECONDS = 0.2;
    public static string DOCUMENTS_FOLDER_PATH = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
    public static string APP_FOLDER_PATH = Path.Combine(DOCUMENTS_FOLDER_PATH, "Expandit");

}
