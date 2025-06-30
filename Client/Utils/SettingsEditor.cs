using Oqtane.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ToSic.Cre8magic.Theme.Basic;

internal class SettingsEditor(ISettingService settingService, string entityName, int entityId, Dictionary<string, string> settings)
    : SettingsReader(settingService, entityName, entityId, settings)
{
    public async Task Save()
        => await new SettingsSaver(SettingService).Save(this, Settings);
}