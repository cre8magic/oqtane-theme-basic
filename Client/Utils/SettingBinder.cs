using System;
using System.Collections.Generic;

namespace ToSic.Cre8magic.Theme.Basic;

/// <summary>
/// Helper to bind a value from a settings dictionary to Razor code.
/// </summary>
/// <param name="editor"></param>
/// <param name="key"></param>
internal class SettingBinder(SettingsEditor editor, string key)
{
    public string? Value
    {
        get
        {
            var result = editor.Manager?.Settings.GetValueOrDefault(key);
            Console.WriteLine($@"Getting value for key: {key} = '{result}'");
            return result;
        }
        set
        {
            if (editor.Manager == null)
                return;

            editor.Manager.Settings[key] = value ?? "";
        }
    }
}