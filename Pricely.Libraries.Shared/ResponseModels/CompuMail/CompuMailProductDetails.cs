using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pricely.Libraries.Shared.ResponseModels.CompuMail
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class CompuMailProductDetails
    {
        [JsonProperty("@context")]
        public string Context { get; set; } = "https://schema.org/";

        [JsonProperty("@type")]
        public string Type { get; set; } = "Product";

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("image")]
        public List<string>? Images { get; set; }

        [JsonProperty("description")]
        public string? Description { get; set; }

        [JsonProperty("sku")]
        public string? Sku { get; set; }

        [JsonProperty("model")]
        public string? Model { get; set; }

        [JsonProperty("mpn")]
        public string? Mpn { get; set; }

        [JsonProperty("weight")]
        public QuantitativeValue? Weight { get; set; }

        [JsonProperty("brand")]
        public Brand? Brand { get; set; }

        [JsonProperty("offers")]
        public Offer? Offer { get; set; }
    }

    public class QuantitativeValue
    {
        [JsonProperty("@type")]
        public string Type { get; set; } = "QuantitativeValue";

        [JsonProperty("value")]
        public string? Value { get; set; }

        [JsonProperty("unitCode")]
        public string? UnitCode { get; set; }
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

        [JsonProperty("availability")]
        public string? Availability { get; set; }

        [JsonProperty("seller")]
        public Organization? Seller { get; set; }
    }

    public class Organization
    {
        [JsonProperty("@type")]
        public string Type { get; set; } = "Organization";

        [JsonProperty("name")]
        public string? Name { get; set; }
    }
}
