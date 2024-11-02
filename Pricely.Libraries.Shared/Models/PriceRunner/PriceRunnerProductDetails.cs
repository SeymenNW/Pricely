using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pricely.Libraries.Shared.Models
{
    public class PriceRunnerProductDetails
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? PriceRunnerUrl { get; set; }

        public List<string>? ImageUrls { get; set; }

        public string? Brand { get; set; }
        public string? MinPrice { get; set; }
        public string? MaxPrice { get; set; }

        //Dette er for butikkerne.
        public List<PriceRunnerMerchants>? Merchants { get; set; }

        //Kan tilføjes: Relaterede produkter (members)

    }
}
