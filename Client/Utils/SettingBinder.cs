using System;
using System.Collections.Generic;

namespace ToSic.Cre8magic.Theme.Basic;

internal class SettingBinder(SettingsEditor editor, string key)
{
    /// <summary>
    /// The reader/manager which manages all the settings.
    /// </summary>
    /// <remarks>
    /// Will be null at first, but once settings are loaded, will be filled by the <see cref="SettingsEditor"/> .
    /// </remarks>
    public SettingsReader? Manager => editor.Manager;

    public string? Value
    {
        get
        {
            var result = Manager?.Settings.GetValueOrDefault(key);
            Console.WriteLine($@"Getting value for key: {key} = '{result}'");
            return result;
        }
        set
        {
            if (Manager == null)
                return;

            Manager.Settings[key] = value ?? "";
        }
    }
}