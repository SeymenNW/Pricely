using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Pricely.Libraries.Shared.ResponseModels.Alternate
{
    public class AlternateProductSchema
    {
        [JsonProperty("@context")]
        public string Context { get; set; } = "https://www.schema.org";

        [JsonProperty("@type")]
        public string Type { get; set; } = "Product";

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("description")]
        public string? Description { get; set; }

        [JsonProperty("brand")]
        public Brand? Brand { get; set; }

        [JsonProperty("image")]
        public string? Image { get; set; }

        [JsonProperty("sku")]
        public long? Sku { get; set; }

        [JsonProperty("gtin8")]
        public string? Gtin8 { get; set; }

        [JsonProperty("offers")]
        public Offer? Offers { get; set; }

        [JsonProperty("hasEnergyConsumptionDetails")]
        public EnergyConsumptionDetails? HasEnergyConsumptionDetails { get; set; }

        [JsonProperty("logo")]
        public string? Logo { get; set; }

        [JsonProperty("mpn")]
        public string? Mpn { get; set; }
    }

    public class Brand
    {
        [JsonProperty("@type")]
        public string Type { get; set; } = "Brand";

        [JsonProperty("name")]
        public string? Name { get; set; }
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
        public string? Price { get; set; }

        [JsonProperty("itemCondition")]
        public string? ItemCondition { get; set; }

        [JsonProperty("availability")]
        public string? Availability { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("seller")]
        public Organization? Seller { get; set; }

        [JsonProperty("hasMerchantReturnPolicy")]
        public MerchantReturnPolicy? HasMerchantReturnPolicy { get; set; }

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

    public class MerchantReturnPolicy
    {
        [JsonProperty("@type")]
        public string Type { get; set; } = "MerchantReturnPolicy";

        [JsonProperty("applicableCountry")]
        public string? ApplicableCountry { get; set; }

        [JsonProperty("returnPolicyCategory")]
        public string? ReturnPolicyCategory { get; set; }

        [JsonProperty("merchantReturnDays")]
        public int? MerchantReturnDays { get; set; }

        [JsonProperty("returnMethod")]
        public string? ReturnMethod { get; set; }
    }

    public class ShippingDetails
    {
        [JsonProperty("@type")]
        public string Type { get; set; } = "OfferShippingDetails";

        [JsonProperty("deliveryTime")]
        public DeliveryTime? DeliveryTime { get; set; }

        [JsonProperty("shippingDestination")]
        public DefinedRegion? ShippingDestination { get; set; }

        [JsonProperty("shippingRate")]
        public MonetaryAmount? ShippingRate { get; set; }
    }

    public class DeliveryTime
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
        [JsonProperty("@Type")]
        public string? Type { get; set; }

        [JsonProperty("minValue")]
        public int? MinValue { get; set; }

        [JsonProperty("maxValue")]
        public int? MaxValue { get; set; }

        [JsonProperty("unitCode")]
        public string? UnitCode { get; set; }
    }

    public class DefinedRegion
    {
        [JsonProperty("@type")]
        public string Type { get; set; } = "DefinedRegion";

        [JsonProperty("addressCountry")]
        public string? AddressCountry { get; set; }
    }

    public class MonetaryAmount
    {
        [JsonProperty("@type")]
        public string Type { get; set; } = "MonetaryAmount";

        [JsonProperty("currency")]
        public string? Currency { get; set; }

        [JsonProperty("value")]
        public decimal? Value { get; set; }
    }

    public class EnergyConsumptionDetails
    {
        [JsonProperty("@type")]
        public string Type { get; set; } = "EnergyConsumptionDetails";
    }

    public class BreadcrumbList
    {
        [JsonProperty("@context")]
        public string Context { get; set; } = "https://www.schema.org";

        [JsonProperty("@type")]
        public string Type { get; set; } = "BreadcrumbList";

        [JsonProperty("itemListElement")]
        public List<ListItem>? ItemListElement { get; set; }
    }

    public class ListItem
    {
        [JsonProperty("@type")]
        public string Type { get; set; } = "ListItem";

        [JsonProperty("position")]
        public int? Position { get; set; }

        [JsonProperty("item")]
        public ListItemDetails? Item { get; set; }
    }

    public class ListItemDetails
    {
        [JsonProperty("@id")]
        public string? Id { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }
    }
}
