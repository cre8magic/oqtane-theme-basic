using Oqtane.Services;
using System.Collections.Generic;

namespace ToSic.Cre8magic.Theme.Basic;

internal class SettingsReader(ISettingService settingService, string entityName, int entityId, Dictionary<string, string> settings)
{
    public string EntityName => entityName;

    public int EntityId => entityId;

    public Dictionary<string, string> Settings => settings;

    public bool IsMerged { get; init; }

    protected ISettingService SettingService = settingService;

    public string Get(string key, string defaultValue = "")
        => SettingService.GetSetting(settings, Constants.KeyPrefix + key, defaultValue);

    public SettingsReader MergeWith(SettingsReader lowerPriorityReader)
    {
        // Clone the dictionaries, to not modify the original ones
        var primary = new Dictionary<string, string>(Settings);
        var secondary = new Dictionary<string, string>(lowerPriorityReader.Settings);
        var mergedDic = SettingService.MergeSettings(primary, secondary);

        return new(SettingService, entityName, entityId, mergedDic)
        {
            IsMerged = true,
        };
    }
}