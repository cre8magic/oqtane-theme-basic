using Oqtane.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ToSic.Cre8magic.Theme.Basic;

internal class SettingsReader(ISettingService settingService, Dictionary<string, string> settings)
{
    public Dictionary<string, string> Settings => settings;

    public string Get(string key, string defaultValue = "")
        => settingService.GetSetting(settings, Constants.KeyPrefix + key, defaultValue);
}

internal static class SettingsExtensions
{
    public static async Task<SettingsReader> GetReader(this ISettingService settingService, string entityName, int entityId)
    {
        var settings = await settingService.GetSettingsAsync(entityName, entityId);
        return new(settingService, settings);
    }
}