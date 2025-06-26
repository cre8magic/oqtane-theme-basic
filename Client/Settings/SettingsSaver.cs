using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Oqtane.Services;

namespace ToSic.Cre8magic.Theme.Basic;

public class SettingsSaver(ISettingService settingService, string entityName, int entityId)
{
    public async Task Save(Dictionary<string, string> values)
    {
        var settings = (await settingService.GetReader(entityName, entityId)).Settings;

        // Check for empty first, because we compare with the existing settings
        // to see if there was a value to remove in the first place.
        var cleanUp = values
            .Where(kvp => string.IsNullOrEmpty(kvp.Value))
            .Select(kvp => Constants.KeyPrefix + kvp.Key)
            .Where(key => settings.ContainsKey(key))
            .ToList();

        // Clean list of things to update
        foreach (var kvp in values)
        {
            var key = Constants.KeyPrefix + kvp.Key;
            if (string.IsNullOrEmpty(kvp.Value))
                settings.Remove(key);
            else
                settings = settingService.SetSetting(settings, key, kvp.Value);
        }

        // If we have any updates left, then update them
        if (settings.Any())
            await settingService.UpdateSettingsAsync(settings, entityName, entityId);

        // Now delete the empty settings
        foreach (var settingName in cleanUp)
            await settingService.DeleteSettingAsync(entityName, entityId, settingName);
        
    }
}