using System.Runtime.InteropServices;

namespace Expandit;

public static class ClipboardHelpers
{
    [DllImport("user32.dll")]
    static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, IntPtr dwExtraInfo);
    [DllImport("user32.dll")]
    static extern bool SetForegroundWindow(IntPtr hWnd);

    [DllImport("user32.dll")]
    static extern IntPtr GetForegroundWindow();



    private const int VK_CONTROL = 0x11;
    private const uint KEYEVENTF_KEYUP = 0x0002;
    private const int VK_V = 0x56;

    private static IDataObject _lastClipboardData;

    public static void BackupClipboard()
    {
        _lastClipboardData = Clipboard.GetDataObject();
    }

    public static async void RestoreClipboard()
    {
        if (_lastClipboardData != null)
        {
            // Small delay to ensure the paste operation has completed in the target app
            await Task.Delay(100);
            Clipboard.SetDataObject(_lastClipboardData);
        }
    }

    public static void PasteText()
    {
        keybd_event(VK_CONTROL, 0, 0, IntPtr.Zero); // Press Ctrl
        keybd_event(VK_V, 0, 0, IntPtr.Zero); // Press V
        keybd_event(VK_V, 0, KEYEVENTF_KEYUP, IntPtr.Zero); // Release V
        keybd_event(VK_CONTROL, 0, KEYEVENTF_KEYUP, IntPtr.Zero); // Release Ctrl
    }
}
