# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project overview

Expandit is a Windows text-expansion utility (WinForms, .NET 8, `net8.0-windows`). It runs in the
background/system tray, listens to a global low-level keyboard hook, and replaces typed shortcut
keys (e.g. `btw`) with expanded text (e.g. `by the way`) via simulated clipboard paste.

## Build & run

There is no test project, lint config, or CI pipeline in this repo — only build/publish commands apply.

- Build: `dotnet build Expandit.sln` (or open `Expandit.sln` in Visual Studio 2022)
- Run: `dotnet run --project Expandit/Expandit.csproj`
- Publish (matches the checked-in profile at `Expandit/Properties/PublishProfiles/FolderProfile.pubxml`):
  `dotnet publish Expandit/Expandit.csproj -c Release -r win-x86 --self-contained true -p:PublishSingleFile=true`

The app enforces single-instance execution via a named Mutex (`Program.cs`) — a second `dotnet run`/launch
while one instance is running will just show a MessageBox and exit.

## Architecture

**Global keyboard hook via `Helper.dll`**: The low-level keyboard hook itself is NOT in this repo's
source — it's a prebuilt binary referenced by `HintPath` in `Expandit.csproj` (`Expandit/Helper.dll`,
also copied into `bin/`). `MainWindow` consumes it as `Helper.KeyHelper` (`kh`), wiring `kh.KeyDown` /
`kh.KeyUp` to its own handlers. Any change to hook behavior (which keys are captured system-wide, etc.)
requires rebuilding/replacing that external DLL, not editing files under `Expandit/`.

**Typing pipeline (`View/MainWindow.cs`, `#region KeyboardListeners`)**: Keystrokes arrive one at a time
from the global hook and are accumulated into `currentText`:
1. `Kh_KeyDown` records a keypress stat (`StatisticsService.RecordKeypress`), tracks modifier state
   (ctrl/shift/alt), and handles Backspace by trimming `currentText`.
2. If the key is a configured trigger key (`KeyAdjuster.IsTriggerKey`, backed by
   `Settings.Default.TriggerKeys` — Space/Enter/Tab), it looks up `currentText` in the shortcut trie.
   On a match, `ReplaceKeyWithValue` fires and `currentText` resets; on no match, it just resets.
3. If the key is a non-printing "special" key (`KeyAdjuster.IsSpecialKey`), it's ignored (buffer untouched).
4. Otherwise `KeyAdjuster.AdjustPressedKey` converts the virtual key to the actual typed character
   (respecting Shift/CapsLock via `ToUnicode`/`GetKeyboardState` Win32 calls) and appends it to `currentText`.

**Expansion mechanism (`ReplaceKeyWithValue` + `ClipboardHelpers`)**: Expansion is done via simulated
paste, not direct text insertion: back up the real clipboard → send N Backspace keystrokes (via
`InputSimulator`) to erase the typed shortcut key → put the expansion value on the clipboard → simulate
Ctrl+V (`ClipboardHelpers.PasteText`, raw `keybd_event`) → restore the original clipboard content after a
short delay. The `_isExpanding` flag guards against the hook re-triggering on the keystrokes this
generates. Because this whole flow depends on `GetForegroundWindow`, it targets whatever window has
focus — there's no per-app allow/deny list beyond the global Enable/Disable toggle in the tray menu.

**Shortcut lookup — `Helpers/Trie.cs`**: Shortcuts are indexed in a generic `Trie<TextShortcut>` keyed by
`Key.ToLower()` for O(key length) lookup instead of scanning the list. `MainWindow.UpdateInMemoryTextShortcuts`
rebuilds the trie from the on-disk store any time shortcuts change (add/edit/delete/import). Case
sensitivity (`Settings.Default.IsMatchingCaseSensitive`) is applied as a secondary exact-match check
after the case-insensitive trie lookup, in `GetTextShortcutModel`.

**Persistence — `Services/TextShortcutsService.cs` and `Services/StatisticsService.cs`**: Both services
store plain JSON (Newtonsoft.Json) under `%USERPROFILE%\Documents\Expandit\` (`GlobalVariables.APP_FOLDER_PATH`),
not a database:
- `TextShortcuts.json` — full read/rewrite on every mutation (`Add`/`Remove`/`Update`/`Import`); IDs are
  `max(existing) + 1`. `GetAll()` re-reads the file from disk rather than trusting the in-memory list.
- `Stats.json` — buffered writes: `RecordKeypress`/`RecordExpansion` only mark state dirty in memory
  (`_isDirty`, guarded by `_stateLock`); an internal `System.Timers.Timer` flushes to disk every 30
  minutes, plus an explicit `Flush()` on `Dispose()` (called from `MainWindow.ExitApplication`). Don't
  assume stats are on disk immediately after recording them.
- Both services resolve `APP_FOLDER_PATH`/filenames from `Data/GlobalVariables.cs` — add new persisted
  files/constants there, not as string literals.

**Settings**: User preferences (trigger keys, case-sensitivity, run-on-startup) are stored via the
generated `Settings` class (`Settings.settings` / `Settings.Designer.cs`, .NET user-scoped settings),
separate from the JSON stores above. `MainWindow`'s Preferences tab reads/writes these directly
(`PopulateTriggerKeysCheckBoxes`, `SaveTriggerKeysSettings`, etc.) and calls `Settings.Default.Save()`
explicitly — nothing autosaves.

**Windows integration details**: Run-on-startup is implemented by writing the exe path into
`HKCU\SOFTWARE\Microsoft\Windows\CurrentVersion\Run` (`MainWindow.AddApplicationToStartup`), not the
Startup folder. The main window hides to tray on close (`FormClosing` cancels `UserClosing`) rather than
exiting; real exit only happens via the tray menu's Exit item, which disposes `StatisticsService` (flushing
stats) before `Application.Exit()`.

**UI structure (`View/`)**: `MainWindow` is a tabbed WinForms app (shortcuts grid / preferences /
statistics) plus a tray icon; `AddTextShortcutWindow` and `EditTextShortcutWindow` are modal dialogs
opened from it, each owning their own `TextShortcutsService` instance rather than sharing the parent's.
Each `.cs` file has a paired `.Designer.cs` (generated layout — edit via the WinForms designer, not by
hand) and `.resx`.
