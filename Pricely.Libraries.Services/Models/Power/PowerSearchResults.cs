using Pricely.Libraries.Services.Models.Elgiganten;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pricely.Libraries.Shared.Models.Power
{
    public class PowerSearchResults
    {
        public string SearchQuery { get; set; }

        public List<PowerSearchResultProduct> ProductResults { get; set; } = new();
    }
}
