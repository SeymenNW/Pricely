using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pricely.Libraries.Services.Models.PriceRunner
{
    public class PriceRunnerSearchResults
    {
        public string SearchQuery { get; set; }

        public List<PriceRunnerSearchResultProduct> ProductResults { get; set; } = new();
    }
}
