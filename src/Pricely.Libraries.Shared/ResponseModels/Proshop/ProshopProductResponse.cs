using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pricely.Libraries.Shared.ResponseModels.Proshop
{
    using Newtonsoft.Json;
    using System;

    public class ProshopProductResponse
    {
        [JsonProperty("@context")]
        public string Context { get; set; } = "http://schema.org/";

        [JsonProperty("@type")]
        public string Type { get; set; } = "Product";

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("image")]
        public string? Image { get; set; }

        [JsonProperty("description")]
        public string? Description { get; set; }

        [JsonProperty("mpn")]
        public string? Mpn { get; set; }

        [JsonProperty("sku")]
        public string? Sku { get; set; }

        [JsonProperty("category")]
        public string? Category { get; set; }

        [JsonProperty("gtin13")]
        public string? Gtin13 { get; set; }

        [JsonProperty("brand")]
        public Brand? Brand { get; set; }

        [JsonProperty("hasMerchantReturnPolicy")]
        public MerchantReturnPolicy? MerchantReturnPolicy { get; set; }

        [JsonProperty("offers")]
        public Offer? Offer { get; set; }
    }

    public class Brand
    {
        [JsonProperty("@type")]
        public string Type { get; set; } = "Brand";

        [JsonProperty("name")]
        public string? Name { get; set; }
    }

    public class MerchantReturnPolicy
    {
        [JsonProperty("@type")]
        public string Type { get; set; } = "MerchantReturnPolicy";

        [JsonProperty("applicableCountry")]
        public string? ApplicableCountry { get; set; }

        [JsonProperty("merchantReturnDays")]
        public string? MerchantReturnDays { get; set; }
    }

    public class Offer
    {
        [JsonProperty("@type")]
        public string Type { get; set; } = "Offer";

        [JsonProperty("url")]
        public string? Url { get; set; }

        [JsonProperty("priceCurrency")]
        public string? PriceCurrency { get; set; }

        [JsonProperty("price")]
        public decimal? Price { get; set; }

        [JsonProperty("itemCondition")]
        public string? ItemCondition { get; set; }

        [JsonProperty("availability")]
        public string? Availability { get; set; }

        [JsonProperty("seller")]
        public Organization? Seller { get; set; }

        [JsonProperty("shippingDetails")]
        public ShippingDetails? ShippingDetails { get; set; }
    }

    public class Organization
    {
        [JsonProperty("@type")]
        public string Type { get; set; } = "Organization";

        [JsonProperty("name")]
        public string? Name { get; set; }
    }

    public class ShippingDetails
    {
        [JsonProperty("@type")]
        public string Type { get; set; } = "OfferShippingDetails";

        [JsonProperty("shippingRate")]
        public MonetaryAmount? ShippingRate { get; set; }

        [JsonProperty("shippingDestination")]
        public DefinedRegion? ShippingDestination { get; set; }

        [JsonProperty("deliveryTime")]
        public ShippingDeliveryTime? DeliveryTime { get; set; }
    }

    public class MonetaryAmount
    {
        [JsonProperty("@type")]
        public string Type { get; set; } = "MonetaryAmount";

        [JsonProperty("value")]
        public decimal? Value { get; set; }

        [JsonProperty("currency")]
        public string? Currency { get; set; }
    }

    public class DefinedRegion
    {
        [JsonProperty("@type")]
        public string Type { get; set; } = "DefinedRegion";

        [JsonProperty("addressCountry")]
        public string? AddressCountry { get; set; }
    }

    public class ShippingDeliveryTime
    {
        [JsonProperty("@type")]
        public string Type { get; set; } = "ShippingDeliveryTime";

        [JsonProperty("handlingTime")]
        public QuantitativeValue? HandlingTime { get; set; }

        [JsonProperty("transitTime")]
        public QuantitativeValue? TransitTime { get; set; }
    }

    public class QuantitativeValue
    {
        [JsonProperty("@type")]
        public string Type { get; set; } = "QuantitativeValue";

        [JsonProperty("minValue")]
        public int? MinValue { get; set; }

        [JsonProperty("maxValue")]
        public int? MaxValue { get; set; }

        [JsonProperty("unitCode")]
        public string? UnitCode { get; set; }
    }
}
