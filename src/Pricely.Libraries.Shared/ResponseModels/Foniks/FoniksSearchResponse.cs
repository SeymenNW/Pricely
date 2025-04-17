using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Pricely.Libraries.Shared.ResponseModels.Foniks
{


    public class FoniksSearchResponse
    {
        [JsonProperty("status")]
        public int Status { get; set; }

        [JsonProperty("query")]
        public string Query { get; set; }

        [JsonProperty("content")]
        public Content Content { get; set; }
    }

    public class Content
    {
        [JsonProperty("results")]
        public Results Results { get; set; }

        [JsonProperty("prices")]
        public Dictionary<string, ProductPrice> Prices { get; set; }

        [JsonProperty("category")]
        public List<object> Category { get; set; } // Appears empty in JSON

        [JsonProperty("imageSizesList")]
        public ImageSizes ImageSizesList { get; set; }
    }

    public class Results
    {
        [JsonProperty("hits")]
        public int Hits { get; set; }

        [JsonProperty("categories")]
        public List<Category> Categories { get; set; }

        [JsonProperty("group_cats")]
        public List<Category> GroupCats { get; set; }
    }

    public class Category
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("max_score")]
        public double MaxScore { get; set; }

        [JsonProperty("hits")]
        public int Hits { get; set; }

        [JsonProperty("products")]
        public List<Product> Products { get; set; }
    }

    public class Product
    {
        [JsonProperty("exists")]
        public string Exists { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("uuid")]
        public string Uuid { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("popular")]
        public int Popular { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("photo")]
        public string Photo { get; set; }

        [JsonProperty("price")]
        public decimal? Price { get; set; }

        [JsonProperty("priceDiscount")]
        public decimal PriceDiscount { get; set; }

        [JsonProperty("beforePrice")]
        public decimal BeforePrice { get; set; }

        [JsonProperty("rawPrice")]
        public decimal RawPrice { get; set; }

        [JsonProperty("stock")]
        public StockInfo Stock { get; set; }

        [JsonProperty("category")]
        public ProductCategory Category { get; set; }

        [JsonProperty("specs")]
        public List<Specification> Specs { get; set; }

        [JsonProperty("is_demo")]
        public bool IsDemo { get; set; }

        [JsonProperty("is_discounted")]
        public bool IsDiscounted { get; set; }

        [JsonProperty("imageSizesView")]
        public ImageSizes ImageSizesView { get; set; }
    }

    public class StockInfo
    {
        [JsonProperty("store")]
        public List<StockItem> Store { get; set; }

        [JsonProperty("remote")]
        public StockItem Remote { get; set; }

        [JsonProperty("delivery")]
        public DeliveryInfo Delivery { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("allowPurchase")]
        public int AllowPurchase { get; set; }

        [JsonProperty("lok3")]
        public StockItem Lok3 { get; set; }

        [JsonProperty("total_stock_count")]
        public int TotalStockCount { get; set; }

        [JsonProperty("popup")]
        public PopupMessage Popup { get; set; }
    }

    public class StockItem
    {
        [JsonProperty("stock")]
        public string Stock { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("title_min")]
        public string TitleMin { get; set; }

        [JsonProperty("expected")]
        public string Expected { get; set; } // Could be DateTime but appears as "1000-01-04" in JSON
    }

    public class DeliveryInfo
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("inTransit")]
        public bool InTransit { get; set; }

        [JsonProperty("duration")]
        public int Duration { get; set; }
    }

    public class PopupMessage
    {
        [JsonProperty("message")]
        public string Message { get; set; }
    }

    public class ProductCategory
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }

    public class Specification
    {
        [JsonProperty("header")]
        public string Header { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }
    }

    public class ImageSizes
    {
        [JsonProperty("normal")]
        public string Normal { get; set; }

        [JsonProperty("responsive")]
        public Dictionary<string, string> Responsive { get; set; }
    }

    public class ProductPrice
    {
        [JsonProperty("price")]
        public PriceDetail Price { get; set; }

        [JsonProperty("settings")]
        public PriceSettings Settings { get; set; }

        [JsonProperty("currency-css")]
        public string CurrencyCss { get; set; }

        [JsonProperty("currency-without-css")]
        public string CurrencyWithoutCss { get; set; }

        [JsonProperty("extension")]
        public string Extension { get; set; }
    }

    public class PriceDetail
    {
        [JsonProperty("current")]
        public string Current { get; set; }

        [JsonProperty("before")]
        public string Before { get; set; }

        [JsonProperty("demo")]
        public string Demo { get; set; }

        [JsonProperty("saving")]
        public Savings Saving { get; set; }
    }

    public class Savings
    {
        [JsonProperty("demo")]
        public float Demo { get; set; }

        [JsonProperty("demo_percentage")]
        public float DemoPercentage { get; set; }

        [JsonProperty("discount")]
        public float Discount { get; set; }

        [JsonProperty("discount_percentage")]
        public float DiscountPercentage { get; set; }
    }

    public class PriceSettings
    {
        [JsonProperty("discount")]
        public bool Discount { get; set; }

        [JsonProperty("discount_percentage")]
        public int DiscountPercentage { get; set; }

        [JsonProperty("discount_value")]
        public int DiscountValue { get; set; }

        [JsonProperty("demo_percentage")]
        public float DemoPercentage { get; set; }

        [JsonProperty("demo_value")]
        public int DemoValue { get; set; }
    }
}
