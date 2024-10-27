using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pricely.Libraries.Services.Models.PriceRunner
{
    public class PriceRunnerProductDetails
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Url { get; set; }

        public List<string>? ImageUrls { get; set; }

        public string? Brand { get; set; }

        //Dette er for butikkerne.
        public List<PriceRunnerMerchants>? Merchants { get; set; }

        //Kan tilføjes: Relaterede produkter (members)

    }
}
