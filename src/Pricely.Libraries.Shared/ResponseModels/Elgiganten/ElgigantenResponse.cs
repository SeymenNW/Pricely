using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Pricely.Libraries.Shared.ResponseModels.Elgiganten
{
   
        public class ElgigantenResponse
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

