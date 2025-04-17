using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pricely.Libraries.Shared.ResponseModels.Komplett
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;

    public class KomplettProductResponse
    {
        [JsonProperty("products")]
        public List<Product>? Products { get; set; }

        [JsonProperty("banners")]
        public List<object>? Banners { get; set; }

        [JsonProperty("facets")]
        public List<Facet>? Facets { get; set; }

        [JsonProperty("rangeFacets")]
        public List<RangeFacet>? RangeFacets { get; set; }

        [JsonProperty("queryParameters")]
        public List<QueryParameter>? QueryParameters { get; set; }

        [JsonProperty("totalNumberOfResultsMatchingQuery")]
        public int? TotalNumberOfResultsMatchingQuery { get; set; }

        [JsonProperty("numberOfResults")]
        public int? NumberOfResults { get; set; }

        [JsonProperty("pageNumber")]
        public int? PageNumber { get; set; }

        [JsonProperty("maxPageCount")]
        public int? MaxPageCount { get; set; }

        [JsonProperty("pageSize")]
        public int? PageSize { get; set; }

        [JsonProperty("queryId")]
        public string? QueryId { get; set; }

        [JsonProperty("sort")]
        public string? Sort { get; set; }

        [JsonProperty("sortOptions")]
        public List<SortOption>? SortOptions { get; set; }
    }

    public class Product
    {
        [JsonProperty("storeId")]
        public string? StoreId { get; set; }

        [JsonProperty("materialNumber")]
        public string? MaterialNumber { get; set; }

        [JsonProperty("manufacturerPartNumber")]
        public string? ManufacturerPartNumber { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("description")]
        public string? Description { get; set; }

        [JsonProperty("sticker")]
        public Sticker? Sticker { get; set; }

        [JsonProperty("url")]
        public string? Url { get; set; }

        [JsonProperty("stock")]
        public Stock? Stock { get; set; }

        [JsonProperty("price")]
        public Price? Price { get; set; }

        [JsonProperty("variantGroups")]
        public List<object>? VariantGroups { get; set; }

        [JsonProperty("reviewRating")]
        public ReviewRating? ReviewRating { get; set; }

        [JsonProperty("energyLogo")]
        public EnergyLogo? EnergyLogo { get; set; }

        [JsonProperty("button")]
        public string? Button { get; set; }

        [JsonProperty("images")]
        public List<string>? Images { get; set; }
    }

    public class Sticker
    {
        [JsonProperty("openInNewWindow")]
        public bool? OpenInNewWindow { get; set; }
    }

    public class Stock
    {
        [JsonProperty("availabilityStatus")]
        public string? AvailabilityStatus { get; set; }

        [JsonProperty("availabilityQuantity")]
        public string? AvailabilityQuantity { get; set; }

        [JsonProperty("stockIconColor")]
        public string? StockIconColor { get; set; }

        [JsonProperty("availabilityText")]
        public string? AvailabilityText { get; set; }

        [JsonProperty("isPendingRelease")]
        public bool? IsPendingRelease { get; set; }
    }

    public class Price
    {
        [JsonProperty("listPrice")]
        public string? ListPrice { get; set; }

        [JsonProperty("listPriceNumber")]
        public double? ListPriceNumber { get; set; }

        [JsonProperty("discount")]
        public string? Discount { get; set; }

        [JsonProperty("discountNumber")]
        public double? DiscountNumber { get; set; }

        [JsonProperty("listPriceBeforeDiscount")]
        public string? ListPriceBeforeDiscount { get; set; }

        [JsonProperty("monthlyPrice")]
        public string? MonthlyPrice { get; set; }

        [JsonProperty("monthlyBeforePrice")]
        public string? MonthlyBeforePrice { get; set; }

        [JsonProperty("monthlyPriceDuration")]
        public int? MonthlyPriceDuration { get; set; }

        [JsonProperty("monthlyPriceTotal")]
        public string? MonthlyPriceTotal { get; set; }

        [JsonProperty("monthlyDiscountType")]
        public string? MonthlyDiscountType { get; set; }

        [JsonProperty("isApplicableForLeasing")]
        public bool? IsApplicableForLeasing { get; set; }

        [JsonProperty("priceIsExcludingVat")]
        public bool? PriceIsExcludingVat { get; set; }

        [JsonProperty("pointBenefit")]
        public bool? PointBenefit { get; set; }

        [JsonProperty("taxRate")]
        public double? TaxRate { get; set; }

        [JsonProperty("isLoyaltyPrice")]
        public bool? IsLoyaltyPrice { get; set; }

        [JsonProperty("hideFlexPrice")]
        public bool? HideFlexPrice { get; set; }

        [JsonProperty("listPriceExVat")]
        public double? ListPriceExVat { get; set; }

        [JsonProperty("discountExVat")]
        public double? DiscountExVat { get; set; }
    }

    public class ReviewRating
    {
        [JsonProperty("reviewCount")]
        public int? ReviewCount { get; set; }

        [JsonProperty("reviewRating")]
        public double? ReviewRatingValue { get; set; }
    }

    public class EnergyLogo
    {
        [JsonProperty("energyGradeLetter")]
        public string? EnergyGradeLetter { get; set; }

        [JsonProperty("legacyEnergyLogoIcon")]
        public string? LegacyEnergyLogoIcon { get; set; }

        [JsonProperty("isLegacyEnergyLogo")]
        public bool? IsLegacyEnergyLogo { get; set; }

        [JsonProperty("urlToTechnicalSpecification")]
        public string? UrlToTechnicalSpecification { get; set; }

        [JsonProperty("urlToDetails")]
        public string? UrlToDetails { get; set; }
    }

    public class Facet
    {
        [JsonProperty("facetType")]
        public string? FacetType { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("displayName")]
        public string? DisplayName { get; set; }

        [JsonProperty("id")]
        public string? Id { get; set; }

        [JsonProperty("facets")]
        public List<FacetItem>? Facets { get; set; }

        [JsonProperty("sortOrder")]
        public int? SortOrder { get; set; }
    }

    public class FacetItem
    {
        [JsonProperty("categoryId")]
        public string? CategoryId { get; set; }

        [JsonProperty("categoryName")]
        public string? CategoryName { get; set; }

        [JsonProperty("categoryLevel")]
        public int? CategoryLevel { get; set; }

        [JsonProperty("children")]
        public List<FacetItem>? Children { get; set; }

        [JsonProperty("parentCategoryId")]
        public string? ParentCategoryId { get; set; }

        [JsonProperty("parentCategoryName")]
        public string? ParentCategoryName { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("productCount")]
        public int? ProductCount { get; set; }

        [JsonProperty("collapsed")]
        public bool? Collapsed { get; set; }

        [JsonProperty("attribute")]
        public Attribute? Attribute { get; set; }

        [JsonProperty("sortOrder")]
        public int? SortOrder { get; set; }
    }

    public class Attribute
    {
        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("value")]
        public string? Value { get; set; }

        [JsonProperty("exclude")]
        public bool? Exclude { get; set; }
    }

    public class RangeFacet
    {
        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("minValue")]
        public double? MinValue { get; set; }

        [JsonProperty("maxValue")]
        public double? MaxValue { get; set; }

        [JsonProperty("totalMinValue")]
        public double? TotalMinValue { get; set; }

        [JsonProperty("totalMaxValue")]
        public double? TotalMaxValue { get; set; }
    }

    public class QueryParameter
    {
        [JsonProperty("key")]
        public string? Key { get; set; }

        [JsonProperty("value")]
        public string? Value { get; set; }
    }

    public class SortOption
    {
        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("mobileName")]
        public string? MobileName { get; set; }

        [JsonProperty("value")]
        public string? Value { get; set; }
    }
}
