using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace ToSic.Cre8magic.Theme.Basic.Settings;

internal class SettingsEditor
{
    public ConcurrentDictionary<string, SettingBinder> Binders { get; } = new();

    /// <summary>
    /// The reader/manager which manages all the settings.
    /// </summary>
    /// <remarks>
    /// Will be null at first, but once settings are loaded, will be filled by the <see cref="SettingsEditor"/> .
    /// </remarks>
    public SettingsReader? Main { get; set; }

    /// <summary> Indexer to access binders by setting name </summary>
    /// <param name="settingName"></param>
    /// <returns></returns>
    public SettingBinder this[string settingName]
        => Binders.GetOrAdd(settingName, newName => new(this, newName));

    /// <summary>
    /// Save the current settings to the database.
    /// </summary>
    /// <param name="prefix">Prefix to filter for, so we only save settings which belong to this control.</param>
    /// <returns></returns>
    public async Task Save(string prefix)
    {
        if (Main?.SettingService == null)
            throw new("SettingService is null, cannot save settings. Did you forget to pass it in the constructor?");
        await new SettingsSaver(Main.SettingService).Save(Main, prefix);
    }

}