using System.Runtime.InteropServices;
using System.Text;

namespace Expandit.Helpers;

public static class KeyAdjuster
{
    [DllImport("user32.dll")]
    private static extern int ToUnicode(uint virtualKey, uint scanCode, byte[] keyState, [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder receivingBuffer, int bufferSize, uint flags);

    [DllImport("user32.dll")]
    private static extern bool GetKeyboardState(byte[] lpKeyState);

    [DllImport("user32.dll")]
    private static extern uint MapVirtualKey(uint uCode, uint uMapType);

    public static string AdjustPressedKey(Keys key, bool shiftPressed)
    {
        byte[] keyState = new byte[256];
        if (!GetKeyboardState(keyState)) return string.Empty;

        if (shiftPressed)
        {
            keyState[(int)Keys.ShiftKey] = 0xff;
        }
        else
        {
            keyState[(int)Keys.ShiftKey] = 0x00;
        }

        // Handle Caps Lock
        if (Control.IsKeyLocked(Keys.CapsLock))
        {
            keyState[(int)Keys.CapsLock] = 0x01;
        }

        StringBuilder sb = new StringBuilder(10);
        uint scanCode = MapVirtualKey((uint)key, 0);
        int result = ToUnicode((uint)key, scanCode, keyState, sb, sb.Capacity, 0);

        if (result > 0)
        {
            return sb.ToString();
        }

        // Fallback for keys that don't produce characters
        return string.Empty;
    }

    public static bool IsSpecialKey(Keys key)
    {
        List<Keys> specialKeys = new List<Keys>
        {
            Keys.LWin, Keys.RWin,
            Keys.LControlKey, Keys.RControlKey,
            Keys.RMenu,Keys.LMenu,
            Keys.Tab,
            Keys.LShiftKey,Keys.RShiftKey,
            Keys.Escape,
            Keys.CapsLock, Keys.NumLock,
            Keys.LWin, Keys.RWin,
            Keys.Up, Keys.Down, Keys.Left , Keys.Right,
            Keys.Enter, Keys.Return,
            Keys.Back,Keys.Delete,
            Keys.F1, Keys.F2, Keys.F3, Keys.F4, Keys.F5, Keys.F6, Keys.F7, Keys.F8,  Keys.F9, Keys.F10,  Keys.F11, Keys.F12,
            Keys.Home, Keys.PageUp, Keys.PageDown, Keys.End,
            Keys.Clear, Keys.Insert,
            Keys.PrintScreen,
            Keys.None,
            Keys.VolumeDown, Keys.VolumeUp, Keys.VolumeMute,
            Keys.MediaNextTrack, Keys.MediaPreviousTrack, Keys.MediaPlayPause, Keys.MediaStop
        };

        return specialKeys.Contains(key);
    }

    public static bool IsTriggerKey(Keys e)
    {
        return Settings.Default.TriggerKeys.Contains(e.ToString());
    }
}
