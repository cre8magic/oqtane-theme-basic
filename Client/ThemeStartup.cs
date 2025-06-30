using Microsoft.Extensions.DependencyInjection;

namespace ToSic.Cre8magic.Theme.Basic;

// TODO: @2dg
// - document how the DI works
//   - Document how general DI works in themes
//   - Document in the docs of this theme, that it uses DI

public class ThemeStartup : Oqtane.Services.IClientStartup
{
    /// <summary>
    /// Register Services which this theme needs.
    /// </summary>
    public void ConfigureServices(IServiceCollection services)
    {
        // Register the MySettings helper
        services.AddTransient<MySettings>();
    }
}
