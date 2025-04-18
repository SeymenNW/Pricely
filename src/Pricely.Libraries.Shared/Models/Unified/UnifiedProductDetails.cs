using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pricely.Libraries.Shared.Enums;

namespace Pricely.Libraries.Shared.Models
{
    public class UnifiedProductDetails
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Gtin { get; set; } 

        public List<string>? Images { get; set; }

        public string? Brand { get; set; }
        public string? Price { get; set; }
        public MerchantEnum? Merchant { get; set; }


    }
}
