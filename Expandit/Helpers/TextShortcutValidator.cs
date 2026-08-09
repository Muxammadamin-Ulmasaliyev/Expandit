namespace Expandit.Helpers;

public static class TextShortcutValidator
{
    public static bool IsValid(string name, string key, string value)
    {
        return !string.IsNullOrWhiteSpace(name)
            && !string.IsNullOrWhiteSpace(key)
            && !string.IsNullOrWhiteSpace(value);
    }
}
