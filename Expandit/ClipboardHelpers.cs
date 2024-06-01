using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Expandit
{
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
		const int WM_PASTE = 0x0302;
		private const int VK_V = 0x56;

		public static void PasteText()
		{
			IntPtr hWnd = GetForegroundWindow();

			// Set the foreground window to ensure pasting into the correct window
			SetForegroundWindow(hWnd);

			keybd_event(VK_CONTROL, 0, 0, IntPtr.Zero); // Press Ctrl
			keybd_event(VK_V, 0, 0, IntPtr.Zero); // Press V
			keybd_event(VK_V, 0, KEYEVENTF_KEYUP, IntPtr.Zero); // Release V
			keybd_event(VK_CONTROL, 0, KEYEVENTF_KEYUP, IntPtr.Zero); // Release Ctrl
		}

		//############################################################################################################################################################

	}
}
