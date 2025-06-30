using System;
using System.Collections.Generic;

namespace ToSic.Cre8magic.Theme.Basic;

internal class SettingBinder(SettingsEditor? editor, string key)
{
    /// <summary>
    /// The editor which manages all the settings.
    /// </summary>
    /// <remarks>
    /// Will be null at first, but once settings are loaded, will be filled by the <see cref="SettingBinderManager"/> .
    /// </remarks>
    public SettingsEditor? Editor { get; internal set; } = editor;

    public string? Value
    {
        get
        {
            var result = Editor?.Settings.GetValueOrDefault(key);
            Console.WriteLine($@"Getting value for key: {key} = '{result}'");
            return result;
        }
        set
        {
            if (Editor == null)
                return;

            Editor.Settings[key] = value ?? "";
        }
    }
}