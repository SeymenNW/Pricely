using Newtonsoft.Json;
using System.Collections.Generic;

namespace Pricely.Libraries.Shared.ResponseModels.ComparisonSites.PriceRunner
{


   
    //https://www.pricerunner.dk/dk/api/search-compare-gateway/public/search/suggest/DK?q={søgning}
    public class PRProductSearch
    {
        [JsonProperty("searchQuery")]
        public string? SearchQuery { get; set; }

        [JsonProperty("products")]
        public List<Product>? Products { get; set; }

        [JsonProperty("categoryOffers")]
        public List<object>? CategoryOffers { get; set; }

        [JsonProperty("pages")]
        public List<object>? Pages { get; set; }

        [JsonProperty("boards")]
        public List<object>? Boards { get; set; }

        [JsonProperty("numberOfHits")]
        public NumberOfHits? NumberOfHits { get; set; }

        [JsonProperty("categories")]
        public List<SearchCategory>? Categories { get; set; }

        [JsonProperty("brands")]
        public List<object>? Brands { get; set; }

        [JsonProperty("merchants")]
        public List<object>? Merchants { get; set; }

        [JsonProperty("featureSuggestions")]
        public List<object>? FeatureSuggestions { get; set; }

        [JsonProperty("productseries")]
        public List<object>? ProductSeries { get; set; }

        [JsonProperty("spellingSuggestion")]
        public object? SpellingSuggestion { get; set; }

        [JsonProperty("adsCategoryId")]
        public int? AdsCategoryId { get; set; }

        [JsonProperty("order")]
        public List<string>? Order { get; set; }

        [JsonProperty("head")]
        public SearchHead? Head { get; set; }

        [JsonProperty("klarnaMerchants")]
        public List<object>? KlarnaMerchants { get; set; }

        [JsonProperty("source")]
        public string? Source { get; set; }
    }

    public class Product
    {
        [JsonProperty("id")]
        public string? Id { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("url")]
        public string? Url { get; set; }

        [JsonProperty("description")]
        public string? Description { get; set; }

        [JsonProperty("lowestPrice")]
        public SearchPrice? LowestPrice { get; set; }

        [JsonProperty("category")]
        public SearchCategory? Category { get; set; }

        [JsonProperty("image")]
        public ProductImage? Image { get; set; }

        [JsonProperty("rank")]
        public Rank? Rank { get; set; }

        [JsonProperty("rating")]
        public Rating? Rating { get; set; }

        [JsonProperty("priceDrop")]
        public object? PriceDrop { get; set; }

        [JsonProperty("brand")]
        public object? Brand { get; set; }

        [JsonProperty("ribbon")]
        public Ribbon? Ribbon { get; set; }

        [JsonProperty("classification")]
        public string? Classification { get; set; }

        [JsonProperty("previewMerchants")]
        public PreviewMerchants? PreviewMerchants { get; set; }

        [JsonProperty("installmentPrice")]
        public object? InstallmentPrice { get; set; }
    }

    public class SearchPrice
    {
        [JsonProperty("amount")]
        public string? Amount { get; set; }

        [JsonProperty("currency")]
        public string? Currency { get; set; }
    }

    public class SearchCategory
    {
        [JsonProperty("id")]
        public string? Id { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("parentName")]
        public object? ParentName { get; set; }

        [JsonProperty("url")]
        public string? Url { get; set; }

        [JsonProperty("products")]
        public List<object>? Products { get; set; }

        [JsonProperty("image")]
        public CategoryImage? Image { get; set; }

        [JsonProperty("title")]
        public string? Title { get; set; }
    }

    public class ProductImage
    {
        [JsonProperty("id")]
        public string? Id { get; set; }

        [JsonProperty("url")]
        public object? Url { get; set; }

        [JsonProperty("path")]
        public string? Path { get; set; }

        [JsonProperty("description")]
        public string? Description { get; set; }
    }

    public class Rank
    {
        [JsonProperty("rank")]
        public int? RankValue { get; set; }

        [JsonProperty("trend")]
        public string? Trend { get; set; }
    }

    public class Rating
    {
        [JsonProperty("numberOfRatings")]
        public int? NumberOfRatings { get; set; }

        [JsonProperty("averageRating")]
        public string? AverageRating { get; set; }

        [JsonProperty("count")]
        public int? Count { get; set; }

        [JsonProperty("average")]
        public string? Average { get; set; }
    }

    public class Ribbon
    {
        [JsonProperty("type")]
        public string? Type { get; set; }

        [JsonProperty("value")]
        public object? Value { get; set; }

        [JsonProperty("description")]
        public object? Description { get; set; }
    }

    public class PreviewMerchants
    {
        [JsonProperty("count")]
        public int? Count { get; set; }

        [JsonProperty("merchants")]
        public List<SearchMerchant>? Merchants { get; set; }
    }

    public class SearchMerchant
    {
        [JsonProperty("id")]
        public string? Id { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("image")]
        public MerchantImage? Image { get; set; }

        [JsonProperty("clickable")]
        public bool? Clickable { get; set; }
    }

    public class MerchantImage
    {
        [JsonProperty("id")]
        public object? Id { get; set; }

        [JsonProperty("url")]
        public object? Url { get; set; }

        [JsonProperty("path")]
        public string? Path { get; set; }

        [JsonProperty("description")]
        public string? Description { get; set; }
    }

    public class CategoryImage
    {
        [JsonProperty("id")]
        public object? Id { get; set; }

        [JsonProperty("url")]
        public object? Url { get; set; }

        [JsonProperty("path")]
        public string? Path { get; set; }

        [JsonProperty("description")]
        public string? Description { get; set; }
    }

    public class NumberOfHits
    {
        [JsonProperty("total")]
        public int? Total { get; set; }

        [JsonProperty("product")]
        public int? Product { get; set; }

        [JsonProperty("categoryOffer")]
        public int? CategoryOffer { get; set; }
    }

    public class SearchHead
    {
        [JsonProperty("title")]
        public string? Title { get; set; }

        [JsonProperty("description")]
        public object? Description { get; set; }

        [JsonProperty("contentLanguage")]
        public string? ContentLanguage { get; set; }

        [JsonProperty("robots")]
        public string? Robots { get; set; }

        [JsonProperty("canonicalUrl")]
        public string? CanonicalUrl { get; set; }

        [JsonProperty("og")]
        public Og? Og { get; set; }
    }

    public class Og
    {
        [JsonProperty("ogTitle")]
        public string? OgTitle { get; set; }

        [JsonProperty("ogDescription")]
        public string? OgDescription { get; set; }

        [JsonProperty("ogSiteName")]
        public string? OgSiteName { get; set; }

        [JsonProperty("ogUrl")]
        public string? OgUrl { get; set; }

        [JsonProperty("ogImage")]
        public string? OgImage { get; set; }
    }
}
