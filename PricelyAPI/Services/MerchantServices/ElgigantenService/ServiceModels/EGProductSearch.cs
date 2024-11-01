using Newtonsoft.Json;

namespace PricelyAPI.Services.MerchantServices.ElgigantenService.Elgiganten
{

    //Endpoint: https://www.elgiganten.dk/api/search (POST Request). Disse klasser bliver dannet til JSON og sendt som Payload i POST requesten.
    public class EGProductSearch
    {
        public EGProductSearch(string query)
        {
            Query = query;
            ContentQuery = query;
        }

        [JsonProperty("siteContext")]
        public SiteContext SiteContext { get; set; } = new SiteContext();

        [JsonProperty("query")]
        public string Query { get; set; }

        [JsonProperty("contentQuery")]
        public string ContentQuery { get; set; }

        [JsonProperty("userQuery")]
        public UserQuery UserQuery { get; set; } = new UserQuery();

        [JsonProperty("pageSearch")]
        public PageSearch PageSearch { get; set; } = new PageSearch();

        [JsonProperty("path")]
        public string Path { get; set; } = "/search";
    }

    public class SiteContext
    {
        [JsonProperty("version")]
        public string Version { get; set; } = "1";

        [JsonProperty("loggedIn")]
        public bool LoggedIn { get; set; } = false;

        [JsonProperty("origin")]
        public string Origin { get; set; } = "https://www.elgiganten.dk";

        [JsonProperty("language")]
        public string Language { get; set; } = "dk";

        [JsonProperty("appMode")]
        public string AppMode { get; set; } = "b2c";

        [JsonProperty("overrideMetadata")]
        public bool OverrideMetadata { get; set; } = true;

        [JsonProperty("flags")]
        public Flags Flags { get; set; } = new Flags();

        [JsonProperty("clubMember")]
        public bool ClubMember { get; set; } = false;
    }

    public class Flags
    {
        [JsonProperty("admin")]
        public bool Admin { get; set; } = false;

        [JsonProperty("b2b-impersonation")]
        public bool B2bImpersonation { get; set; } = false;

        [JsonProperty("b2b-newsletter-signup")]
        public bool B2bNewsletterSignup { get; set; } = true;

        [JsonProperty("b2b-signup")]
        public bool B2bSignup { get; set; } = true;

        [JsonProperty("bazar-integration")]
        public bool BazarIntegration { get; set; } = true;

        [JsonProperty("cart-page")]
        public bool CartPage { get; set; } = false;

        [JsonProperty("collect-at-store")]
        public bool CollectAtStore { get; set; } = true;

        [JsonProperty("debug-mode")]
        public bool DebugMode { get; set; } = false;

        [JsonProperty("enable-add-b2b-user")]
        public bool EnableAddB2bUser { get; set; } = true;

        [JsonProperty("enable-address-lookup")]
        public bool EnableAddressLookup { get; set; } = true;

        [JsonProperty("enable-algolia")]
        public bool EnableAlgolia { get; set; } = false;

        [JsonProperty("enable-b2b-request-admin-flow")]
        public bool EnableB2bRequestAdminFlow { get; set; } = true;

        [JsonProperty("enable-checkout-v2")]
        public bool EnableCheckoutV2 { get; set; } = false;

        [JsonProperty("enable-client-side-navigation")]
        public bool EnableClientSideNavigation { get; set; } = false;

        [JsonProperty("enable-contentsquare")]
        public bool EnableContentsquare { get; set; } = true;

        [JsonProperty("enable-dynamic-yield")]
        public bool EnableDynamicYield { get; set; } = true;

        [JsonProperty("enable-gtm")]
        public bool EnableGtm { get; set; } = true;

        [JsonProperty("enable-qlc")]
        public bool EnableQlc { get; set; } = true;

        [JsonProperty("enable-robots")]
        public bool EnableRobots { get; set; } = true;

        [JsonProperty("enable-sponsored-products")]
        public bool EnableSponsoredProducts { get; set; } = false;

        [JsonProperty("enable-subscriptions")]
        public bool EnableSubscriptions { get; set; } = true;

        [JsonProperty("enable-text-chat")]
        public bool EnableTextChat { get; set; } = true;

        [JsonProperty("enable-third-party")]
        public bool EnableThirdParty { get; set; } = false;

        [JsonProperty("enable-tradein-calculator")]
        public bool EnableTradeinCalculator { get; set; } = true;

        [JsonProperty("enable-video-chat")]
        public bool EnableVideoChat { get; set; } = true;

        [JsonProperty("enable-wishlist")]
        public bool EnableWishlist { get; set; } = true;

        [JsonProperty("ff-prefetch")]
        public bool FfPrefetch { get; set; } = true;

        [JsonProperty("kitchen-claims")]
        public bool KitchenClaims { get; set; } = true;

        [JsonProperty("NEP-1933")]
        public bool Nep1933 { get; set; } = false;

        [JsonProperty("nep-2110")]
        public bool Nep2110 { get; set; } = true;

        [JsonProperty("reload-on-consent-change")]
        public bool ReloadOnConsentChange { get; set; } = true;

        [JsonProperty("ship-to-store")]
        public bool ShipToStore { get; set; } = true;

        [JsonProperty("show-admin-menu")]
        public bool ShowAdminMenu { get; set; } = false;

        [JsonProperty("show-checkout-feedback")]
        public bool ShowCheckoutFeedback { get; set; } = false;

        [JsonProperty("show-delete-my-data")]
        public bool ShowDeleteMyData { get; set; } = true;

        [JsonProperty("show-get-my-data")]
        public bool ShowGetMyData { get; set; } = false;

        [JsonProperty("show-translations-keys")]
        public bool ShowTranslationsKeys { get; set; } = false;

        [JsonProperty("vercel-toolbar")]
        public bool VercelToolbar { get; set; } = false;
    }

    public class UserQuery
    {
        public UserQuery()
        {
            Q = string.Empty;
        }

        [JsonProperty("q")]
        public string Q { get; set; }
    }

    public class PageSearch
    {
        [JsonProperty("page")]
        public int Page { get; set; } = 1;
    }

}
