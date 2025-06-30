using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Oqtane.Services;

namespace ToSic.Cre8magic.Theme.Basic;

// TODO: @2dg
// - change where it's used to use DI
// - document how the DI works
//   - Document how general DI works in themes
//   - Document in the docs of this theme, that it uses DI

/// <summary>
/// Tool to help save settings for anything.
/// </summary>
/// <remarks>
/// It must be internal, to ensure that it will not conflict with other themes which may have the same class.
/// </remarks>
/// <param name="settingService">The settings service, should use dependency injection</param>
internal class SettingsSaver(ISettingService settingService)
{
    public async Task Save(string entityName, int entityId, Dictionary<string, string> values)
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