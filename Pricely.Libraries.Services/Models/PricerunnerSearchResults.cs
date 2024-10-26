using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pricely.Libraries.Services.Models
{
    public class PricerunnerSearchResults
    {
        public string SearchQuery { get; set; }

        public List<PricerunnerSearchProduct> ProductResults { get; set; } = new();
    }
}
