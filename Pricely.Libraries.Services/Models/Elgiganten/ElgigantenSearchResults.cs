using Pricely.Libraries.Services.Models.PriceRunner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pricely.Libraries.Services.Models.Elgiganten
{
    public class ElgigantenSearchResults
    {
        public string SearchQuery { get; set; }

        public List<ElgigantenSearchResultProduct> ProductResults { get; set; } = new();
    }
}
