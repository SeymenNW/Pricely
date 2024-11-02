using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pricely.Libraries.Shared.Models
{
    public class PriceRunnerMerchants
    {
        public string? Name { get; set; }
        public string? MerchantProductName { get; set; }
        public string? Price { get; set; } //Skal nok ændres til et nummer baseret variabel på et tidspunkt.
        public string? Id { get; set; }
        public string? ProductUrl { get; set; }
        public bool? StockStatus { get; set; }
        public bool? Availability { get; set; }
        public string? ShippingCost { get; set; }
        public string? MerchantRating { get; set; }
        public string? MerchantLogoUrl { get; set; }
    }
}
