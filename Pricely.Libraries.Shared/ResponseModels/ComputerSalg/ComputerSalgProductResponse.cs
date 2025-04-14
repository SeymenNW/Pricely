using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Pricely.Libraries.Shared.ResponseModels.ComputerSalg
{




    public class ComputerSalgProductResponse
    {
        [JsonProperty("CsPerformanceSimpleMeasure")]
        public CsPerformanceSimpleMeasure? CsPerformanceSimpleMeasure { get; set; }

        [JsonProperty("RawReturnHtml")]
        public string? RawReturnHtml { get; set; }

        [JsonProperty("ExecuteTimeMs")]
        public int? ExecuteTimeMs { get; set; }
    }
    public class CsPerformanceSimpleMeasure
    {
        [JsonProperty("PerformancePoints")]
        public Dictionary<string, int>? PerformancePoints { get; set; }
    }

}
