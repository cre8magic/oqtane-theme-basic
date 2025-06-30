using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace ToSic.Cre8magic.Theme.Basic;

internal class SettingsEditor
{
    public ConcurrentDictionary<string, SettingBinder> Binders { get; } = new();

    /// <summary>
    /// The reader/manager which manages all the settings.
    /// </summary>
    /// <remarks>
    /// Will be null at first, but once settings are loaded, will be filled by the <see cref="SettingsEditor"/> .
    /// </remarks>
    public SettingsReader? Manager { get; set; }

    /// <summary> Indexer to access binders by setting name </summary>
    /// <param name="settingName"></param>
    /// <returns></returns>
    public SettingBinder this[string settingName]
        => GetOrCreateBinder(settingName);

    private SettingBinder GetOrCreateBinder(string settingName)
        => Binders.GetOrAdd(settingName, newName => new(this, newName));

    public async Task Save(string prefix)
    {
        if (Manager?.SettingService == null)
            throw new("SettingService is null, cannot save settings. Did you forget to pass it in the constructor?");
        await new SettingsSaver(Manager.SettingService).Save(Manager, prefix);
    }

}