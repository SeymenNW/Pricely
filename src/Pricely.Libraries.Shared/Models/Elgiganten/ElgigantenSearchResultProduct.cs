using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pricely.Libraries.Shared.Models
{
    public class ElgigantenSearchResultProduct
    {
        public string? Sku { get; set; }
        public string? Name { get; set; }
        public string? ImageUrl { get; set; }

        public string? StoreUrl { get; set; }
        public string? CurrentPrice { get; set; }
    }
}
