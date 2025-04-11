using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Pricely.Libraries.Shared.ResponseModels.Elgiganten
{
 
    public class ElgigantenProductDetails
    {
        [JsonProperty("type")]
        public string? Type { get; set; }

        [JsonProperty("isOutletProduct")]
        public bool? IsOutletProduct { get; set; }

        [JsonProperty("isDetailed")]
        public bool? IsDetailed { get; set; }

        [JsonProperty("advertisingText")]
        public string? AdvertisingText { get; set; }

        [JsonProperty("bulletPoints")]
        public List<string>? BulletPoints { get; set; }

        [JsonProperty("href")]
        public string? Href { get; set; }

        [JsonProperty("imageUrl")]
        public string? ImageUrl { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("price")]
        public Price? Price { get; set; }

        [JsonProperty("promotionText")]
        public List<string>? PromotionText { get; set; }

        [JsonProperty("sku")]
        public string? Sku { get; set; }

        [JsonProperty("taxonomy")]
        public List<string>? Taxonomy { get; set; }

        [JsonProperty("badge")]
        public string? Badge { get; set; }

        [JsonProperty("brand")]
        public string? Brand { get; set; }

        [JsonProperty("hasVariants")]
        public bool? HasVariants { get; set; }

        [JsonProperty("cgm")]
        public string? Cgm { get; set; }

        [JsonProperty("pt")]
        public string? Pt { get; set; }

        [JsonProperty("rating")]
        public List<double>? Rating { get; set; }

        [JsonProperty("sellability")]
        public Sellability? Sellability { get; set; }
    }

    public class Price
    {
        [JsonProperty("currency")]
        public string? Currency { get; set; }

        [JsonProperty("recurring")]
        public bool? Recurring { get; set; }

        [JsonProperty("isClubPrice")]
        public bool? IsClubPrice { get; set; }

        [JsonProperty("current")]
        public List<double>? Current { get; set; }

        [JsonProperty("original")]
        public List<double>? Original { get; set; }

        [JsonProperty("showDiscount")]
        public bool? ShowDiscount { get; set; }

        [JsonProperty("disclaimer")]
        public string? Disclaimer { get; set; }

        [JsonProperty("isDiscounted")]
        public bool? IsDiscounted { get; set; }

        [JsonProperty("isCustom")]
        public bool? IsCustom { get; set; }

        [JsonProperty("discount")]
        public List<double>? Discount { get; set; }
    }

    public class Sellability
    {
        [JsonProperty("isDisabled")]
        public bool? IsDisabled { get; set; }

        [JsonProperty("isAvailableOnline")]
        public bool? IsAvailableOnline { get; set; }

        [JsonProperty("isBuyableOnline")]
        public bool? IsBuyableOnline { get; set; }

        [JsonProperty("isBuyableInStore")]
        public bool? IsBuyableInStore { get; set; }

        [JsonProperty("isBuyableCollectAtStore")]
        public bool? IsBuyableCollectAtStore { get; set; }

        [JsonProperty("isShipFromStoreOnly")]
        public bool? IsShipFromStoreOnly { get; set; }

        [JsonProperty("isOnlyBuyableInOtherContext")]
        public bool? IsOnlyBuyableInOtherContext { get; set; }

        [JsonProperty("isDiscontinued")]
        public bool? IsDiscontinued { get; set; }

        [JsonProperty("onlineSalesStatus")]
        public string? OnlineSalesStatus { get; set; }

        [JsonProperty("onlineStock")]
        public OnlineStock? OnlineStock { get; set; }

        [JsonProperty("storesWithStockCount")]
        public int? StoresWithStockCount { get; set; }

        [JsonProperty("itemAvailability")]
        public string? ItemAvailability { get; set; }

        [JsonProperty("qlc")]
        public Qlc? Qlc { get; set; }

        [JsonProperty("isMarketplaceProduct")]
        public bool? IsMarketplaceProduct { get; set; }
    }

    public class OnlineStock
    {
        [JsonProperty("inStock")]
        public bool? InStock { get; set; }

        [JsonProperty("level")]
        public string? Level { get; set; }
    }

    public class Qlc
    {
        [JsonProperty("active")]
        public bool? Active { get; set; }

        [JsonProperty("recaptchaRequired")]
        public bool? RecaptchaRequired { get; set; }

        [JsonProperty("soldOut")]
        public bool? SoldOut { get; set; }
    }
}
