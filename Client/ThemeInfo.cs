using Oqtane.Models;
using Oqtane.Themes;

namespace ToSic.Cre8magic.Theme.Basic;

public class ThemeInfo : ITheme
{
    public Oqtane.Models.Theme Theme => Static;

    public static Oqtane.Models.Theme Static => new()
    {
        Name = "Cre8magic Basic",
        Version = "1.0.0",
        PackageName = "ToSic.Cre8magic.Theme.Basic",
        ThemeSettingsType = "ToSic.Cre8magic.Theme.Basic.ThemeSettings, ToSic.Cre8magic.Theme.Basic.Client.Oqtane",
        ContainerSettingsType = "ToSic.Cre8magic.Theme.Basic.ContainerSettings, ToSic.Cre8magic.Theme.Basic.Client.Oqtane",
        Resources =
        [
            new Stylesheet("~/Theme.css"),
            new Stylesheet("~/Oqtane.css"),
            new Stylesheet ("~/styles.min.css"), // Bootstrap generated with Sass/Webpack
            new Script("~/bootstrap.bundle.min.js"),
        ]
    };

}