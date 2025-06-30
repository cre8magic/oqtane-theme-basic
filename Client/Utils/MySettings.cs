using Oqtane.Services;
using Oqtane.Shared;
using System.Threading.Tasks;
using Oqtane.UI;

namespace ToSic.Cre8magic.Theme.Basic;

internal class MySettings(ISettingService settingService)
{
    internal async Task<SettingsReader> GetModule(int moduleId)
        => await GetReader(EntityNames.Module, moduleId);
    internal async Task<SettingsReader> GetPage(int pageId)
        => await GetReader(EntityNames.Page, pageId);
    internal async Task<SettingsReader> GetSite(int siteId)
        => await GetReader(EntityNames.Site, siteId);

    public async Task<SettingsReader> GetReader(string entityName, int entityId)
    {
        var settings = await settingService.GetSettingsAsync(entityName, entityId);
        return new(settingService, entityName, entityId, settings);
    }

    public SettingsReader GetPage(PageState pageState)
    {
        var ofPage = pageState.Page.Settings ?? throw new("Page Settings cannot be null");
        var ofSite = pageState.Site.Settings ?? throw new("Site Settings cannot be null");

        var pageReader = new SettingsReader(settingService, EntityNames.Page, pageState.Page.PageId, ofPage);
        var siteReader = new SettingsReader(settingService, EntityNames.Site, pageState.Site.SiteId, ofSite);
        var merged = pageReader.MergeWith(siteReader);
        return merged;
    }
}
