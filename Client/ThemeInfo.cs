using System.Collections.Generic;
using Oqtane.Models;
using Oqtane.Themes;
using Oqtane.Shared;

namespace ToSic.Cre8magic.Theme.Basic
{
    public class ThemeInfo : ITheme
    {
        public Oqtane.Models.Theme Theme => new Oqtane.Models.Theme
        {
            Name = "ToSic.Cre8magic Basic",
            Version = "1.0.0",
            PackageName = "ToSic.Cre8magic.Theme.Basic",
            ThemeSettingsType = "ToSic.Cre8magic.Theme.Basic.ThemeSettings, ToSic.Cre8magic.Theme.Basic.Client.Oqtane",
            ContainerSettingsType = "ToSic.Cre8magic.Theme.Basic.ContainerSettings, ToSic.Cre8magic.Theme.Basic.Client.Oqtane",
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
