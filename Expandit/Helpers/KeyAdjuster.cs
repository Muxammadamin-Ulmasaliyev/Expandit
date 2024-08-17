namespace Expandit.Helpers;

public static class KeyAdjuster
{
	public static string AdjustPressedKey(Keys key, bool shiftPressed)
	{
		var res = string.Empty;

		switch (key)
		{

			case Keys.Oemtilde:
				res = shiftPressed ? "~" : "`";
				break;

			case Keys.Oemplus:
				res = shiftPressed ? "+" : "=";
				break;
			case Keys.Add:
				res = "+";
				break;
			case Keys.OemMinus:
				res = shiftPressed ? "_" : "-";
				break;
			case Keys.Subtract:
				res = "-";
				break;
			case Keys.Divide:
				res = "/";
				break;
			case Keys.Multiply:
				res = "*";
				break;



			case Keys.D1:
				res = shiftPressed ? "!" : "1";
				break;
			case Keys.D2:
				res = shiftPressed ? "@" : "2";

				break;
			case Keys.D3:
				res = shiftPressed ? "#" : "3";

				break;
			case Keys.D4:
				res = shiftPressed ? "$" : "4";


				break;
			case Keys.D5:
				res = shiftPressed ? "%" : "5";

				break;
			case Keys.D6:
				res = shiftPressed ? "^" : "6";

				break;
			case Keys.D7:
				res = shiftPressed ? "&" : "7";

				break;
			case Keys.D8:
				res = shiftPressed ? "*" : "8";

				break;
			case Keys.D9:
				res = shiftPressed ? "(" : "9";
				break;
			case Keys.D0:
				res = shiftPressed ? ")" : "0";

				break;

			case Keys.NumPad1:
				res = "1";
				break;
			case Keys.NumPad2:
				res = "2";
				break;
			case Keys.NumPad3:
				res = "3";
				break;
			case Keys.NumPad4:
				res = "4";
				break;
			case Keys.NumPad5:
				res = "5";
				break;
			case Keys.NumPad6:
				res = "6";
				break;
			case Keys.NumPad7:
				res = "7";
				break;
			case Keys.NumPad8:
				res = "8";
				break;
			case Keys.NumPad9:
				res = "9";
				break;
			case Keys.NumPad0:
				res = "0";
				break;
			case Keys.Decimal:
				res = ".";
				break;




			case Keys.OemOpenBrackets:
				res = shiftPressed ? "{" : "[";
				break;
			case Keys.Oem6:
				res = shiftPressed ? "}" : "]";
				break;
			case Keys.Oem5:
				res = shiftPressed ? "|" : "\\";
				break;
			case Keys.Oem1:
				res = shiftPressed ? ":" : ";";
				break;
			case Keys.Oem7:
				res = shiftPressed ? "\"" : "'";
				break;
			case Keys.OemQuestion:
				res = shiftPressed ? "?" : "/";
				break;
			case Keys.OemPeriod:
				res = shiftPressed ? ">" : ".";
				break;
			case Keys.Oemcomma:
				res = shiftPressed ? "<" : ",";
				break;

			case Keys.A:
				res = shiftPressed ? "A" : "a";
				break;
			case Keys.B:
				res = shiftPressed ? "B" : "b";
				break;
			case Keys.C:
				res = shiftPressed ? "C" : "c";
				break;
			case Keys.D:
				res = shiftPressed ? "D" : "d";
				break;
			case Keys.E:
				res = shiftPressed ? "E" : "e";
				break;
			case Keys.F:
				res = shiftPressed ? "F" : "f";
				break;
			case Keys.G:
				res = shiftPressed ? "G" : "g";
				break;
			case Keys.H:
				res = shiftPressed ? "H" : "h";
				break;
			case Keys.I:
				res = shiftPressed ? "I" : "i";
				break;
			case Keys.J:
				res = shiftPressed ? "J" : "j";
				break;
			case Keys.K:
				res = shiftPressed ? "K" : "k";
				break;
			case Keys.L:
				res = shiftPressed ? "L" : "l";
				break;
			case Keys.M:
				res = shiftPressed ? "M" : "m";
				break;
			case Keys.N:
				res = shiftPressed ? "N" : "n";
				break;
			case Keys.O:
				res = shiftPressed ? "O" : "o";
				break;
			case Keys.P:
				res = shiftPressed ? "P" : "p";
				break;
			case Keys.Q:
				res = shiftPressed ? "Q" : "q";
				break;
			case Keys.R:
				res = shiftPressed ? "R" : "r";
				break;
			case Keys.S:
				res = shiftPressed ? "S" : "s";
				break;
			case Keys.T:
				res = shiftPressed ? "T" : "t";
				break;
			case Keys.U:
				res = shiftPressed ? "U" : "u";
				break;
			case Keys.V:
				res = shiftPressed ? "V" : "v";
				break;
			case Keys.W:
				res = shiftPressed ? "W" : "w";
				break;
			case Keys.X:
				res = shiftPressed ? "X" : "x";
				break;
			case Keys.Y:
				res = shiftPressed ? "Y" : "y";
				break;
			case Keys.Z:
				res = shiftPressed ? "Z" : "z";
				break;



			default: break;


		}

		return res;

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
