namespace ToSic.Cre8magic.Theme.Basic;
internal class MyContainerSettings(SettingsReader settings)
{
    internal static string KeyShowTitle = $"{KeyPrefix}:ShowTitle";

    public bool ShowTitle => settings.Bool(KeyShowTitle, false);
}
