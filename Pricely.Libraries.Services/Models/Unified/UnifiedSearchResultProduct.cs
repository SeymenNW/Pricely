using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pricely.Libraries.Shared.Models.Unified
{
    public class UnifiedSearchResultProduct
    {
        public string? IdSku { get; set; }
        public string? Name { get; set; }
        public string? ImageUrl { get; set; }

        public string? StoreUrl { get; set; }
        public string? CurrentPrice { get; set; }
    }
}
