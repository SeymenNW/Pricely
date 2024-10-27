using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pricely.Libraries.Services.Models.Elgiganten
{
    public class ElgigantenSearchResultProduct
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? ImageUrl { get; set; }

        public string? Description { get; set; }
        public string? CurrentPrice { get; set; }
    }
}
