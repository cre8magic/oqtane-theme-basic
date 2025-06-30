using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace ToSic.Cre8magic.Theme.Basic;

internal class SettingsEditor
{
    public ConcurrentDictionary<string, SettingBinder> Binders { get; } = new();

    public SettingsReader? Manager { get; set; }

    // Create an indexer to access binders by setting name
    public SettingBinder this[string settingName]
        => GetOrCreateBinder(settingName);

    private SettingBinder GetOrCreateBinder(string settingName)
        => Binders.GetOrAdd(settingName, newName => new(this, newName));

    public async Task Save()
    {
        if (Manager?.SettingService == null)
            throw new("SettingService is null, cannot save settings. Did you forget to pass it in the constructor?");
        await new SettingsSaver(Manager.SettingService).Save(Manager, Manager.Settings);
    }

}