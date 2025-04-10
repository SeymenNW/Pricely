using Newtonsoft.Json;
using System.Collections.Generic;

namespace PricelyAPI.Services.MerchantServices.ElgigantenService.ServiceModels
{
    public class EGProductSearchResponse
    {
        [JsonProperty("data")]
        public ElgigantenResponseData Data { get; set; }
    }

    public class ElgigantenResponseData
    {
        [JsonProperty("records")]
        public List<ElgigantenProductRecord> Records { get; set; }
    }

    public class ElgigantenProductRecord
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("price")]
        public ElgigantenProductPrice Price { get; set; }

        [JsonProperty("sku")]
        public string Sku { get; set; }

        [JsonProperty("href")]
        public string Href { get; set; }

        [JsonProperty("imageUrl")]
        public string ImageUrl { get; set; }
    }

    public class ElgigantenProductPrice
    {
        [JsonProperty("current")]
        public List<string> Current { get; set; }
    }
}