using Oqtane.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ToSic.Cre8magic.Theme.Basic;

internal class SettingsEditor(ISettingService settingService, string entityName, int entityId, Dictionary<string, string> settings)
    : SettingsReader(settingService, entityName, entityId, settings)
{
    public async Task Save()
    {
        if (SettingService == null)
            throw new("SettingService is null, cannot save settings. Did you forget to pass it in the constructor?");
        await new SettingsSaver(SettingService).Save(this, Settings);
    }
}