using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pricely.Libraries.Shared.Models
{
    public class PriceRunnerSearchResultProduct
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }


        public string Description { get; set; }
        public string LowestPrice { get; set; }

        
        public string ProductCategoryNum { get; set; }

        //Denne bruges kun i Frontend delen.

        public string DetailsUrl => $"/pr/details/{ProductCategoryNum}/{Id}";

    }
}
