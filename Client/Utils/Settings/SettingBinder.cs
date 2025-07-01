using System.Collections.Generic;

namespace ToSic.Cre8magic.Theme.Basic.Utils.Settings;

/// <summary>
/// Helper to bind a value from a settings dictionary to Razor code.
/// </summary>
/// <param name="editor"></param>
/// <param name="key"></param>
internal class SettingBinder(SettingsEditor editor, string key)
{
    public string? Value
    {
        get => editor.Main?.Settings.GetValueOrDefault(key);
        set
        {
            if (editor.Main == null)
                return;

            editor.Main.Settings[key] = value ?? "";
        }
    }
}