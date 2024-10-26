using Newtonsoft.Json;

//Klassenavne struktur: public/*det navn bruges til klassen*

//Klasser for deserializering af følgende Endpoint: Product Listing (Produkt Listning)
//https://www.pricerunner.dk/dk/api/search-compare-gateway/public/productlistings/pl/initial/52-{productId}/DK
namespace PricelyAPI.ServiceModels.Pricerunner
{
    //public class PricerunnerProductListing
    //{
    //}

    public class PricerunnerProductListing
    {
        [JsonProperty("product")]
        public ProductDetails ProductDetails { get; set; }

        [JsonProperty("productGroup")]
        public ProductGroup ProductGroup { get; set; }

        [JsonProperty("brand")]
        public Brand Brand { get; set; }

        [JsonProperty("specification")]
        public Specification Specification { get; set; }

        [JsonProperty("productReviewSummary")]
        public ProductReviewSummary ProductReviewSummary { get; set; }

        [JsonProperty("categoryBrandFilter")]
        public CategoryBrandFilter CategoryBrandFilter { get; set; }

        [JsonProperty("subcategoryBrandFilter")]
        public object SubcategoryBrandFilter { get; set; }

        [JsonProperty("category")]
        public Category Category { get; set; }

        [JsonProperty("breadcrumbs")]
        public List<Breadcrumb> Breadcrumbs { get; set; }

        [JsonProperty("sponsoredOffer")]
        public object SponsoredOffer { get; set; }

        [JsonProperty("commonData")]
        public CommonData CommonData { get; set; }

        [JsonProperty("testedProduct")]
        public object TestedProduct { get; set; }

        [JsonProperty("filters")]
        public Filters Filters { get; set; }

        [JsonProperty("productSeries")]
        public object ProductSeries { get; set; }

        [JsonProperty("nationalOfferCount")]
        public int NationalOfferCount { get; set; }

        [JsonProperty("internationalOfferCount")]
        public int InternationalOfferCount { get; set; }

        [JsonProperty("unverifiedOffers")]
        public bool UnverifiedOffers { get; set; }

        [JsonProperty("offersNotInStock")]
        public bool OffersNotInStock { get; set; }

        [JsonProperty("nationalOffersNotInStock")]
        public bool NationalOffersNotInStock { get; set; }

        [JsonProperty("internationalOffersNotInStock")]
        public bool InternationalOffersNotInStock { get; set; }

        [JsonProperty("merchantsCount")]
        public int MerchantsCount { get; set; }

        [JsonProperty("prioritizedMinPrice")]
        public Price PrioritizedMinPrice { get; set; }

        [JsonProperty("prioritizedMaxPrice")]
        public Price PrioritizedMaxPrice { get; set; }

        [JsonProperty("nationalOffersMinPrice")]
        public Price NationalOffersMinPrice { get; set; }

        [JsonProperty("internationalOffersMinPrice")]
        public object InternationalOffersMinPrice { get; set; }

        [JsonProperty("minPriceInStock")]
        public object MinPriceInStock { get; set; }

        [JsonProperty("plState")]
        public string PlState { get; set; }

        [JsonProperty("showInternationalOfferInfo")]
        public bool ShowInternationalOfferInfo { get; set; }

        [JsonProperty("redirect")]
        public object Redirect { get; set; }
    }

    public class ProductDetails
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("article")]
        public string Article { get; set; }

        [JsonProperty("images")]
        public List<Image> Images { get; set; }

        [JsonProperty("ribbon")]
        public object Ribbon { get; set; }
    }

    public class Image
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("path")]
        public string Path { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }

    public class ProductGroup
    {
        [JsonProperty("members")]
        public List<ProductGroupMember> Members { get; set; }

        [JsonProperty("displayMode")]
        public string DisplayMode { get; set; }

        [JsonProperty("attributeName")]
        public string AttributeName { get; set; }
    }

    public class ProductGroupMember
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("image")]
        public Image Image { get; set; }

        [JsonProperty("price")]
        public Price Price { get; set; }

        [JsonProperty("attributeValues")]
        public List<string> AttributeValues { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }

    public class Price
    {
        [JsonProperty("amount")]
        public string Amount { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }
    }

    public class Brand
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("logo")]
        public BrandLogo Logo { get; set; }

        [JsonProperty("image")]
        public BrandImage Image { get; set; }

        [JsonProperty("certifiedImage")]
        public object CertifiedImage { get; set; }

        [JsonProperty("certified")]
        public bool Certified { get; set; }

        [JsonProperty("brandOffer")]
        public object BrandOffer { get; set; }
    }

    public class BrandLogo
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("path")]
        public string Path { get; set; }
    }

    public class BrandImage
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("path")]
        public string Path { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }

    public class Specification
    {
        [JsonProperty("sections")]
        public List<SpecificationSection> Sections { get; set; }

        [JsonProperty("creationTime")]
        public string CreationTime { get; set; }
    }

    public class SpecificationSection
    {
        [JsonProperty("attributes")]
        public List<Attribute> Attributes { get; set; }

        [JsonProperty("sectionName")]
        public string SectionName { get; set; }
    }

    public class Attribute
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public object Description { get; set; }

        [JsonProperty("values")]
        public List<AttributeValue> Values { get; set; }

        [JsonProperty("volume")]
        public bool Volume { get; set; }

        [JsonProperty("unit")]
        public object Unit { get; set; }
    }

    public class AttributeValue
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("link")]
        public string Link { get; set; }
    }

    public class ProductReviewSummary
    {
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("average")]
        public string Average { get; set; }

        [JsonProperty("distribution")]
        public ReviewDistribution Distribution { get; set; }

        [JsonProperty("proReviewCount")]
        public int ProReviewCount { get; set; }

        [JsonProperty("userReviewCount")]
        public int UserReviewCount { get; set; }
    }

    public class ReviewDistribution
    {
        [JsonProperty("one")]
        public int One { get; set; }

        [JsonProperty("two")]
        public int Two { get; set; }

        [JsonProperty("three")]
        public int Three { get; set; }

        [JsonProperty("four")]
        public int Four { get; set; }

        [JsonProperty("five")]
        public int Five { get; set; }
    }

    public class CategoryBrandFilter
    {
        [JsonProperty("brandName")]
        public string BrandName { get; set; }

        [JsonProperty("optionName")]
        public string OptionName { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }

    public class Category
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }

    public class Breadcrumb
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }

    public class CommonData
    {
        [JsonProperty("head")]
        public Head Head { get; set; }

        //[JsonProperty("analytics")]
        //public Analytics Analytics { get; set; }
    }

    public class Head
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("contentLanguage")]
        public object ContentLanguage { get; set; }

        [JsonProperty("robots")]
        public string Robots { get; set; }

        [JsonProperty("canonicalUrl")]
        public object CanonicalUrl { get; set; }

        [JsonProperty("hrefLangTags")]
        public object HrefLangTags { get; set; }

        [JsonProperty("ogTitle")]
        public string OgTitle { get; set; }

        [JsonProperty("ogDescription")]
        public string OgDescription { get; set; }

        [JsonProperty("ogImage")]
        public string OgImage { get; set; }

        [JsonProperty("ogType")]
        public string OgType { get; set; }

        [JsonProperty("twitterTitle")]
        public string TwitterTitle { get; set; }

        [JsonProperty("twitterDescription")]
        public string TwitterDescription { get; set; }

        [JsonProperty("twitterImage")]
        public string TwitterImage { get; set; }

        [JsonProperty("twitterType")]
        public string TwitterType { get; set; }

        [JsonProperty("structuredData")]
        public List<StructuredData> StructuredData { get; set; }
    }

    public class StructuredData
    {
        [JsonProperty("@type")]
        public string Type { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("offers")]
        public Offer Offers { get; set; }

        [JsonProperty("aggregateRating")]
        public AggregateRating AggregateRating { get; set; }

        [JsonProperty("sku")]
        public string Sku { get; set; }

        [JsonProperty("brand")]
        public Brand Brand { get; set; }

        [JsonProperty("mainEntityOfPage")]
        public string MainEntityOfPage { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }
    }

    public class Offer
    {
        [JsonProperty("@type")]
        public string Type { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("priceCurrency")]
        public string PriceCurrency { get; set; }

        [JsonProperty("price")]
        public string Price { get; set; }

        [JsonProperty("itemCondition")]
        public string ItemCondition { get; set; }

        [JsonProperty("availability")]
        public string Availability { get; set; }

        [JsonProperty("seller")]
        public Seller Seller { get; set; }
    }

    public class Seller
    {
        [JsonProperty("@type")]
        public string Type { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class AggregateRating
    {
        [JsonProperty("@type")]
        public string Type { get; set; }

        [JsonProperty("ratingValue")]
        public string RatingValue { get; set; }

        [JsonProperty("bestRating")]
        public string BestRating { get; set; }

        [JsonProperty("ratingCount")]
        public int RatingCount { get; set; }
    }

    public class Filters
    {
        [JsonProperty("attributeFilters")]
        public List<AttributeFilter> AttributeFilters { get; set; }

        [JsonProperty("priceFilter")]
        public PriceFilter PriceFilter { get; set; }

        [JsonProperty("sortOptions")]
        public List<SortOption> SortOptions { get; set; }
    }

    public class AttributeFilter
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("values")]
        public List<FilterValue> Values { get; set; }
    }

    public class FilterValue
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("active")]
        public bool Active { get; set; }

        [JsonProperty("link")]
        public string Link { get; set; }
    }

    public class PriceFilter
    {
        [JsonProperty("min")]
        public object Min { get; set; }

        [JsonProperty("max")]
        public object Max { get; set; }
    }

    public class SortOption
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("active")]
        public bool Active { get; set; }

        [JsonProperty("link")]
        public string Link { get; set; }
    }

}