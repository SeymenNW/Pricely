using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pricely.Libraries.Shared.ResponseModels.MaxGaming
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class MaxGamingProductDetails
    {
        [JsonProperty("@context")]
        public string? Context { get; set; }

        [JsonProperty("@type")]
        public string? Type { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("description")]
        public string? Description { get; set; }

        [JsonProperty("image")]
        public string? Image { get; set; }

        [JsonProperty("brand")]
        public Brand? Brand { get; set; }

        [JsonProperty("gtin8")]
        public string? Gtin8 { get; set; }

        [JsonProperty("mpn")]
        public string? Mpn { get; set; }

        [JsonProperty("sku")]
        public string? Sku { get; set; }

        [JsonProperty("offers")]
        public Offer? Offers { get; set; }
    }

    public class Brand
    {
        [JsonProperty("@type")]
        public string? Type { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }
    }

    public class Offer
    {
        [JsonProperty("@type")]
        public string? Type { get; set; }

        [JsonProperty("priceCurrency")]
        public string? PriceCurrency { get; set; }

        [JsonProperty("price")]
        public string? Price { get; set; }

        [JsonProperty("itemCondition")]
        public string? ItemCondition { get; set; }

        [JsonProperty("availability")]
        public string? Availability { get; set; }
    }
}
