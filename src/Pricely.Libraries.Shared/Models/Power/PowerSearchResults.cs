using Pricely.Libraries.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pricely.Libraries.Shared.Models
{
    public class PowerSearchResults
    {
        public string SearchQuery { get; set; }

        public List<PowerSearchResultProduct> ProductResults { get; set; } = new();
    }
}
