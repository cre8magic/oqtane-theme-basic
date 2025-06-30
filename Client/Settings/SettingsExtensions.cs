using System.Threading.Tasks;
using Oqtane.Services;

namespace ToSic.Cre8magic.Theme.Basic;

internal static class SettingsExtensions
{
    public static async Task<SettingsReader> GetReader(this ISettingService settingService, string entityName, int entityId)
    {
        var settings = await settingService.GetSettingsAsync(entityName, entityId);
        return new(settingService, entityName, entityId, settings);
    }
}