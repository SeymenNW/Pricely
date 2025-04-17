using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pricely.Core.Services.ComparisonSites.National.PriceRunner;

namespace Pricely.Con.PR
{
    public class PriceRun
    {

        public async Task GetPrices()
        {
            HttpClient client = new();
            PriceRunnerService runner = new(client);


            var prods = await runner.GetProductsFromSearch("PS5");

            foreach (var p in prods.ProductResults)
            {
                Console.WriteLine(p.Name);
            }
        }

    }
}
