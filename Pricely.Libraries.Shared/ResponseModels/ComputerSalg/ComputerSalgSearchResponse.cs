using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Newtonsoft.Json;

namespace Pricely.Libraries.Shared.ResponseModels.ComputerSalg
{

 

    public class ComputerSalgSearchResponse
    {
        [JsonProperty("v3SearchContainer")]
        public string? HtmlContent { get; set; }

        [JsonProperty("StartTimeUtc")]
        public long? StartTimeUtc { get; set; }

        [JsonIgnore]
        public DateTime? Timestamp =>
            StartTimeUtc.HasValue ? DateTime.FromFileTimeUtc(StartTimeUtc.Value) : null;
    }
}
