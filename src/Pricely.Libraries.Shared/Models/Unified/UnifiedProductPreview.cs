using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Pricely.Libraries.Shared.Enums;

namespace Pricely.Libraries.Shared.Models
{
    public class UnifiedProductPreview
    {
        public string? IdSku { get; set; }

        [JsonIgnore]
        public MerchantEnum? Merchant { get; set; }

        public string MerchantName
        {
            get
            {
                return Merchant?.ToString() ?? "Unknown";
            }
        }

        public string? Name { get; set; }
        public string? Image { get; set; }

        public string? Url { get; set; }
        public string? CurrentPrice { get; set; }
        public bool? Availability { get; set; }
    }
}
