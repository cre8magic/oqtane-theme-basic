using System.Collections.Generic;
using Oqtane.Models;
using Oqtane.Themes;
using Oqtane.Shared;

namespace ToSicCre8magic.Theme.Basic01
{
    public class ThemeInfo : ITheme
    {
        public Oqtane.Models.Theme Theme => new Oqtane.Models.Theme
        {
            Name = "ToSicCre8magic Basic01",
            Version = "1.0.0",
            PackageName = "ToSicCre8magic.Theme.Basic01",
            ThemeSettingsType = "ToSicCre8magic.Theme.Basic01.ThemeSettings, ToSicCre8magic.Theme.Basic01.Client.Oqtane",
            ContainerSettingsType = "ToSicCre8magic.Theme.Basic01.ContainerSettings, ToSicCre8magic.Theme.Basic01.Client.Oqtane",
            Resources = new List<Resource>()
            {
		        // obtained from https://cdnjs.com/libraries
                 new Resource { ResourceType = ResourceType.Stylesheet, Url = "~/Theme.css"},
                 new Resource { ResourceType = ResourceType.Stylesheet, Url = "~/Oqtane.css"},
                 new Resource { ResourceType = ResourceType.Stylesheet, Url = "~/styles.min.css"}, // Bootstrap generated with Sass/Webpack
                 new Resource { ResourceType = ResourceType.Script,Url = "~/bootstrap.bundle.min.js" } // Bootstrap JS
            }
        };

    }
}
