using Expandit.Models;

namespace Expandit.Models;

public class DynamicPlaceholder
{
    public bool IsActive { get; set; }
    public string Key { get; set; }
    public DynamicPlaceholderEnum Command { get; set; }
}
public enum DynamicPlaceholderEnum
{
    DateTime = 10,
    Date = 11,
    Time = 12,

    Username = 20,
    MachineName = 21,
    OSVersion = 22,
    ClipboardTop = 30,

    Calculate = 40,
    GUID = 42,

}
