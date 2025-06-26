using System.Collections.Generic;
using Oqtane.Models;
using Oqtane.Themes;
using Oqtane.Shared;

namespace ToSicCre8magic.Theme.Basic
{
    public class ThemeInfo : ITheme
    {
        public Oqtane.Models.Theme Theme => new Oqtane.Models.Theme
        {
            Name = "ToSicCre8magic Basic",
            Version = "1.0.0",
            PackageName = "ToSicCre8magic.Theme.Basic",
            ThemeSettingsType = "ToSicCre8magic.Theme.Basic.ThemeSettings, ToSicCre8magic.Theme.Basic.Client.Oqtane",
            ContainerSettingsType = "ToSicCre8magic.Theme.Basic.ContainerSettings, ToSicCre8magic.Theme.Basic.Client.Oqtane",
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
