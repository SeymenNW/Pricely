using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Pricely.Libraries.Shared.ResponseModels.CompuMail
{
   

    public class CompuMailSearchResponse
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("html")]
        public SearchHtml? Html { get; set; }
    }

    public class SearchHtml
    {
        [JsonProperty("products")]
        public string? ProductsHtml { get; set; }
    }
}
