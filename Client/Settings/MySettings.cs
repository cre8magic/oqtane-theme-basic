using Oqtane.Services;
using Oqtane.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ToSic.Cre8magic.Theme.Basic;

internal class MySettings(ISettingService settingService)
{
    internal async Task<SettingsReader> Get(string entityName, int entityId) => await GetReader(entityName, entityId);

    internal async Task<SettingsReader> GetModule(int moduleId) => _moduleReader ??= await Get(EntityNames.Module, moduleId);
    private SettingsReader _moduleReader;
    internal async Task<SettingsReader> GetPage(int pageId) => _pageReader ??= await Get(EntityNames.Page, pageId);
    private SettingsReader _pageReader;
    internal async Task<SettingsReader> GetSite(int siteId) => _siteReader ??= await Get(EntityNames.Site, siteId);
    private SettingsReader _siteReader;


    public async Task<SettingsReader> GetReader(string entityName, int entityId)
    {
        var settings = await settingService.GetSettingsAsync(entityName, entityId);
        return new(settingService, entityName, entityId, settings);
    }

    public async Task Save(string entityName, int entityId, Dictionary<string, string> values)
        => await new SettingsSaver(settingService).Save(entityName, entityId, values);
}
