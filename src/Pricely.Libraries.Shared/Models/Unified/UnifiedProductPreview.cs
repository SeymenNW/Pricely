using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pricely.Libraries.Shared.Enums;

namespace Pricely.Libraries.Shared.Models
{
    public class UnifiedProductPreview
    {
        public string? IdSku { get; set; }
        public MerchantEnum? Merchant { get; set; }
        public string? Name { get; set; }
        public string? Image { get; set; }

        public string? Url { get; set; }
        public string? CurrentPrice { get; set; }
        public bool? Availability { get; set; }
    }
}
