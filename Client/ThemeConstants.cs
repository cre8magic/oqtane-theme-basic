namespace ToSic.Cre8magic.Theme.Basic;

class ThemeConstants
{
    /// <summary>
    /// Prefix used for all keys/settings in this theme.
    /// </summary>
    internal static string KeyPrefix = typeof(ThemeConstants).Namespace!;

    internal static string KeyLogin = $"{KeyPrefix}:Login";
    internal static string KeyRegister = $"{KeyPrefix}:Register";
    internal static string KeyFooterHtml = $"{KeyPrefix}:FooterHtml";
    internal static string KeyThemeCss = $"{KeyPrefix}:ThemeCss";

    internal static string KeyShowTitle = $"{KeyPrefix}:ShowTitle";

    public const string DefaultFooterHtml = """
                                                <div class="container py-4 d-flex justify-content-md-between flex-column flex-md-row text-white">
                                                    <ul class="theme-footer-address d-flex flex-column flex-xl-row" itemscope itemtype="http://schema.org/LocalBusiness">
                                                        <li>
                                                            <strong itemprop="name">Cre8magic Oqtane Theme BS5 by 2sxc </strong>
                                                        </li>
                                                        <li>
                                                            <span itemprop="address" itemscope itemtype="http://schema.org/PostalAddress">
                                                                <span itemprop="streetAddress">Cre8magic Road 42</span>,
                                                                <span itemprop="postalCode">2742</span>
                                                                <span itemprop="addressLocality">Cre8magic City</span>,
                                                                <span itemprop="addressCountry">Cre8magic Country</span>
                                                            </span>
                                                        </li>
                                                        <li><a href="tel:+41 234 56 78">+41 234 56 78</a></li>
                                                        <li>
                                                            <span data-madr1="shine" data-madr2="example" data-madr3="com" data-linktext=""></span>
                                                        </li>
                                                    </ul>
                                                    <div class="theme-footer-imprint">
                                                        <a href="/"> Terms of Use </a> |
                                                        <a href="/"> Privacy </a>
                                                    </div>
                                                </div>
                                            """;
}