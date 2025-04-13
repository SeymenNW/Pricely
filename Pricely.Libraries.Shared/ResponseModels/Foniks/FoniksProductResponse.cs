using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Pricely.Libraries.Shared.ResponseModels.Foniks
{
   
    public class FoniksProductResponse
    {
        [JsonProperty("@context")]
        public string? Context { get; set; }

        [JsonProperty("@type")]
        public string? Type { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("image")]
        public List<string>? Images { get; set; }

        [JsonProperty("description")]
        public string? Description { get; set; }

        [JsonProperty("mpn")]
        public string? Mpn { get; set; }

        [JsonProperty("sku")]
        public string? Sku { get; set; }

        [JsonProperty("gtin14")]
        public string? Gtin14 { get; set; }

        [JsonProperty("offers")]
        public Offer? Offers { get; set; }
    }

    public class Offer
    {
        [JsonProperty("type")]
        public string? Type { get; set; }

        [JsonProperty("priceCurrency")]
        public string? PriceCurrency { get; set; }

        [JsonProperty("price")]
        public string? Price { get; set; }

        [JsonProperty("availability")]
        public string? Availability { get; set; }
    }
}
