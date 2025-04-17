using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Pricely.Libraries.Shared.ResponseModels.Power
{

    public class PowerSearchResponse
    {
        [JsonProperty("filters")]
        public List<Filter> Filters { get; set; } = new List<Filter>();

        [JsonProperty("products")]
        public List<Product> Products { get; set; } = new List<Product>();

        [JsonProperty("startIndex")]
        public int StartIndex { get; set; }

        [JsonProperty("totalProductCount")]
        public int TotalProductCount { get; set; }

        [JsonProperty("sortId")]
        public int SortId { get; set; }

        [JsonProperty("pageSize")]
        public int PageSize { get; set; }

        [JsonProperty("isLastPage")]
        public bool IsLastPage { get; set; }
    }


    public class Filter
    {
        [JsonProperty("attributeId")]
        public string AttributeId { get; set; }

        [JsonProperty("filterType")]
        public int FilterType { get; set; }

        [JsonProperty("selectedValues")]
        public List<object> SelectedValues { get; set; } = new List<object>();

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("sort")]
        public int Sort { get; set; }

        [JsonProperty("valueCountDictionary")]
        public Dictionary<string, int> ValueCountDictionary { get; set; } = new Dictionary<string, int>();

        [JsonProperty("min")]
        public double? Min { get; set; }

        [JsonProperty("max")]
        public double? Max { get; set; }
    }

    public class ProductReview
    {
        [JsonProperty("overallAverageRating")]
        public double OverallAverageRating { get; set; }

        [JsonProperty("overallTotalReviewCount")]
        public int OverallTotalReviewCount { get; set; }
    }

    public class Breadcrumb
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("nameSlug")]
        public string NameSlug { get; set; }

        [JsonProperty("sortValue")]
        public int SortValue { get; set; }
    }

    public class ImageVariant
    {
        [JsonProperty("filename")]
        public string Filename { get; set; }

        [JsonProperty("width")]
        public int Width { get; set; }

        [JsonProperty("height")]
        public int Height { get; set; }

        [JsonProperty("isTransparent")]
        public bool IsTransparent { get; set; }
    }

    public class ProductImage
    {
        [JsonProperty("basePath")]
        public string BasePath { get; set; }

        [JsonProperty("isPrimary")]
        public bool IsPrimary { get; set; }

        [JsonProperty("imageType")]
        public int ImageType { get; set; }

        [JsonProperty("variants")]
        public List<ImageVariant> Variants { get; set; } = new List<ImageVariant>();
    }

    public class TechLogo : ProductImage
    {
        [JsonProperty("imageAltText")]
        public string ImageAltText { get; set; }

        [JsonProperty("generativeContent")]
        public GenerativeContent GenerativeContent { get; set; }
    }

    public class GenerativeContent
    {
        [JsonProperty("imageSubType")]
        public string ImageSubType { get; set; }

        [JsonProperty("averageColorHex")]
        public string AverageColorHex { get; set; }
    }

    public class AdvertisingCampaign
    {
        [JsonProperty("campaignId")]
        public int CampaignId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("friendlyUrl")]
        public string FriendlyUrl { get; set; }

        [JsonProperty("hasBadgeLink")]
        public bool HasBadgeLink { get; set; }

        [JsonProperty("badgeStyle")]
        public string BadgeStyle { get; set; }

        [JsonProperty("boxText")]
        public string BoxText { get; set; }

        [JsonProperty("enhancedText")]
        public bool EnhancedText { get; set; }

        [JsonProperty("externalUrl")]
        public string ExternalUrl { get; set; }

        [JsonProperty("urlType")]
        public string UrlType { get; set; }

        [JsonProperty("hideProductPage")]
        public bool HideProductPage { get; set; }

        [JsonProperty("ctaButton")]
        public string CtaButton { get; set; }

        [JsonProperty("productPageHeader")]
        public string ProductPageHeader { get; set; }

        [JsonProperty("activeFrom")]
        public DateTime ActiveFrom { get; set; }

        [JsonProperty("activeTo")]
        public DateTime ActiveTo { get; set; }

        [JsonProperty("campaignMediaUrl")]
        public string CampaignMediaUrl { get; set; }

        [JsonProperty("shortDesription")]
        public string ShortDescription { get; set; }

        [JsonProperty("priority")]
        public int Priority { get; set; }

        [JsonProperty("campaignClass")]
        public string CampaignClass { get; set; }

        [JsonProperty("productPageBannerStyle")]
        public string ProductPageBannerStyle { get; set; }
    }

    public class Product
    {
        [JsonProperty("categoryId")]
        public int CategoryId { get; set; }

        [JsonProperty("categoryName")]
        public string CategoryName { get; set; }

        [JsonProperty("clickNCollectStoreCount")]
        public int ClickNCollectStoreCount { get; set; }

        [JsonProperty("energyTier")]
        public int EnergyTier { get; set; }

        [JsonProperty("isLimitedQuantity")]
        public bool IsLimitedQuantity { get; set; }

        [JsonProperty("manufacturerName")]
        public string ManufacturerName { get; set; }

        [JsonProperty("manufacturerId")]
        public int ManufacturerId { get; set; }

        [JsonProperty("price")]
        public double Price { get; set; }

        [JsonProperty("productId")]
        public int ProductId { get; set; }

        [JsonProperty("salesArguments")]
        public string SalesArguments { get; set; }

        [JsonProperty("shortDescription")]
        public string ShortDescription { get; set; }

        [JsonProperty("stockCount")]
        public int StockCount { get; set; }

        [JsonProperty("storesStockCount")]
        public int StoresStockCount { get; set; }

        [JsonProperty("stockDeliveryDate")]
        public DateTime? StockDeliveryDate { get; set; }

        [JsonProperty("stockDeliveryDateConfirmed")]
        public bool StockDeliveryDateConfirmed { get; set; }

        [JsonProperty("stockLimitedRemaining")]
        public int StockLimitedRemaining { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("advertisingCampaigns")]
        public List<AdvertisingCampaign> AdvertisingCampaigns { get; set; } = new List<AdvertisingCampaign>();

        [JsonProperty("breadcrumb")]
        public List<Breadcrumb> Breadcrumb { get; set; } = new List<Breadcrumb>();

        [JsonProperty("productReview")]
        public ProductReview ProductReview { get; set; }

        [JsonProperty("hasDescription")]
        public bool HasDescription { get; set; }

        [JsonProperty("serviceCategoryId")]
        public int ServiceCategoryId { get; set; }

        [JsonProperty("vatPercent")]
        public double VatPercent { get; set; }

        [JsonProperty("modelType")]
        public int ModelType { get; set; }

        [JsonProperty("priceType")]
        public int PriceType { get; set; }

        [JsonProperty("barcode")]
        public string Barcode { get; set; }

        [JsonProperty("eanGtin12")]
        public string EanGtin12 { get; set; }

        [JsonProperty("showSavingsAs")]
        public int ShowSavingsAs { get; set; }

        [JsonProperty("productImage")]
        public ProductImage ProductImage { get; set; }

        [JsonProperty("productManuals")]
        public List<object> ProductManuals { get; set; } = new List<object>();

        [JsonProperty("techLogo")]
        public TechLogo TechLogo { get; set; }

        [JsonProperty("campaignMediaUrl")]
        public string CampaignMediaUrl { get; set; }

        [JsonProperty("campaignMediaAltText")]
        public string CampaignMediaAltText { get; set; }

        [JsonProperty("webStatus")]
        public int WebStatus { get; set; }

        [JsonProperty("productManufactorIdentity")]
        public string ProductManufactorIdentity { get; set; }

        [JsonProperty("warranty")]
        public int Warranty { get; set; }

        [JsonProperty("webStockStatus")]
        public int WebStockStatus { get; set; }

        [JsonProperty("webStockText")]
        public string WebStockText { get; set; }

        [JsonProperty("webStockTextShort")]
        public string WebStockTextShort { get; set; }

        [JsonProperty("webStockMeta")]
        public string WebStockMeta { get; set; }

        [JsonProperty("cncStockStatus")]
        public int CncStockStatus { get; set; }

        [JsonProperty("cncStockText")]
        public string CncStockText { get; set; }

        [JsonProperty("canAddToCart")]
        public bool CanAddToCart { get; set; }

        [JsonProperty("isOnDemand")]
        public bool IsOnDemand { get; set; }

        [JsonProperty("elguideId")]
        public string ElguideId { get; set; }

        [JsonProperty("isRecurringPaymentProduct")]
        public bool IsRecurringPaymentProduct { get; set; }

        [JsonProperty("releaseDate")]
        public DateTime? ReleaseDate { get; set; }

        [JsonProperty("depositPriceIncluded")]
        public bool DepositPriceIncluded { get; set; }
    }

   
}
