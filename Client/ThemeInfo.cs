using Oqtane.Models;
using Oqtane.Themes;

namespace ToSic.Cre8magic.Theme.Basic;

public class ThemeInfo : ITheme
{
    /// <summary>
    /// The Theme Settings Type will let Oqtane know what control to show in the page settings, and it will also be used to load language resources.
    /// </summary>
    public const string ThemeSettingsType =
        "ToSic.Cre8magic.Theme.Basic.ThemeSettings, ToSic.Cre8magic.Theme.Basic.Client.Oqtane";

    /// <summary>
    /// The Container Settings Type will let Oqtane know what control to show in the module settings, and it will also be used to load language resources.
    /// </summary>
    public const string ContainerSettingsType =
        "ToSic.Cre8magic.Theme.Basic.ContainerSettings, ToSic.Cre8magic.Theme.Basic.Client.Oqtane";

    /// <summary>
    /// The Theme will let Oqtane know what theme this is, and how it should be loaded / rendered etc.
    /// </summary>
    public Oqtane.Models.Theme Theme => new()
    {
        Name = "Cre8magic Basic",
        Version = "1.0.0",
        PackageName = "ToSic.Cre8magic.Theme.Basic",
        ThemeSettingsType = ThemeSettingsType,
        ContainerSettingsType = ContainerSettingsType,
        Resources =
        [
            new Stylesheet("~/Theme.css"),
            new Stylesheet("~/Oqtane.css"),
            new Stylesheet ("~/styles.min.css"), // Bootstrap generated with Sass/Webpack
            new Script("~/bootstrap.bundle.min.js"),
        ]
    };

}