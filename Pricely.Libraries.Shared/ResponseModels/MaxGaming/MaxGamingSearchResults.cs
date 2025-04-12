using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Pricely.Libraries.Shared.ResponseModels.MaxGaming
{
 
    public class MaxGamingSearchResults
    {
        [JsonProperty("item_list_id")]
        public string? ItemListId { get; set; }

        [JsonProperty("item_list_name")]
        public string? ItemListItemName { get; set; }

        [JsonProperty("items")]
        public List<Item>? Items { get; set; }
    }

    public class Item
    {
        [JsonProperty("item_id")]
        public string? ItemId { get; set; }

        [JsonProperty("item_name")]
        public string? ItemName { get; set; }

        [JsonProperty("affiliation")]
        public string? Affiliation { get; set; }

        [JsonProperty("coupon")]
        public string? Coupon { get; set; }

        [JsonProperty("currency")]
        public string? Currency { get; set; }

        [JsonProperty("discount")]
        public decimal Discount { get; set; }

        [JsonProperty("index")]
        public int Index { get; set; }

        [JsonProperty("item_brand")]
        public string? ItemBrand { get; set; }

        [JsonProperty("item_category")]
        public string? ItemCategory { get; set; }

        [JsonProperty("item_list_id")]
        public string? ItemListId { get; set; }

        [JsonProperty("item_list_name")]
        public string? ItemListName { get; set; }

        [JsonProperty("item_variant")]
        public string? ItemVariant { get; set; }

        [JsonProperty("location_id")]
        public string? LocationId { get; set; }

        [JsonProperty("price")]
        public decimal Price { get; set; }

        [JsonProperty("quantity")]
        public int Quantity { get; set; }
    }
}
