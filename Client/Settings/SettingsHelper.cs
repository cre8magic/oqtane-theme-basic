using Oqtane.Services;
using System.Threading.Tasks;

namespace ToSic.Cre8magic.Theme.Basic;

public class SettingsHelper(ISettingService settingService, int siteId, int pageId)
{
    internal async Task<SettingsReader> Page() => _pageReader ??= await settingService.GetReader("Page", pageId);
    private SettingsReader _pageReader;
    internal async Task<SettingsReader> Site() => _siteReader ??= await settingService.GetReader("Site", siteId);
    private SettingsReader _siteReader;

    internal async Task<SettingsReader> Merged()
    {
        if (_merged != null)
            return _merged;
        var pageSettings = (await Page()).Settings;
        var siteSettings = (await Site()).Settings;
        _merged = new(settingService, settingService.MergeSettings(siteSettings, pageSettings));
        return _merged;
    }
    private SettingsReader _merged;
}