using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Pricely.Libraries.Shared.ResponseModels.Power
{


    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;

    public class ResponseAdvertisingCampaign
    {
        public int CampaignId { get; set; }
        public string Name { get; set; }
        public string FriendlyUrl { get; set; }
        public bool HasBadgeLink { get; set; }
        public string BadgeStyle { get; set; }
        public string BoxText { get; set; }
        public bool EnhancedText { get; set; }
        public string ExternalUrl { get; set; }
        public string UrlType { get; set; }
        public bool HideProductPage { get; set; }
        public string CtaButton { get; set; }
        public string ProductPageHeader { get; set; }
        public DateTime ActiveFrom { get; set; }
        public DateTime ActiveTo { get; set; }
        public int Priority { get; set; }
        public string CampaignMediaUrl { get; set; }
        public string ShortDesription { get; set; }
    }

    public class BreadcrumbItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameSlug { get; set; }
        public int SortValue { get; set; }
    }

    public class ResponseProductReview
    {
        public double OverallAverageRating { get; set; }
        public int OverallTotalReviewCount { get; set; }
    }

    public class ResponseImageVariant
    {
        public string Filename { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public bool IsTransparent { get; set; }
    }

    public class ResponseProductImage
    {
        public string BasePath { get; set; }
        public bool IsPrimary { get; set; }
        public int ImageType { get; set; }
        public List<ImageVariant> Variants { get; set; }
    }

    public class PowerProductResponse
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int ClickNCollectStoreCount { get; set; }
        public int EnergyTier { get; set; }
        public bool IsLimitedQuantity { get; set; }
        public string ManufacturerName { get; set; }
        public int ManufacturerId { get; set; }
        public double Price { get; set; }
        public int ProductId { get; set; }
        public string SalesArguments { get; set; }
        public string ShortDescription { get; set; }
        public int StockCount { get; set; }
        public int StoresStockCount { get; set; }
        public DateTime? StockDeliveryDate { get; set; }
        public bool StockDeliveryDateConfirmed { get; set; }
        public int StockLimitedRemaining { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public List<ResponseAdvertisingCampaign> AdvertisingCampaigns { get; set; }
        public List<BreadcrumbItem> Breadcrumb { get; set; }
        public ResponseProductReview ProductReview { get; set; }
        public bool HasDescription { get; set; }
        public int ServiceCategoryId { get; set; }
        public double VatPercent { get; set; }
        public int ModelType { get; set; }
        public int PriceType { get; set; }
        public string Barcode { get; set; }
        public string EanGtin12 { get; set; }
        public int ShowSavingsAs { get; set; }
        public ResponseProductImage ProductImage { get; set; }
        public List<object> ProductManuals { get; set; }
        public string CampaignMediaUrl { get; set; }
        public int WebStatus { get; set; }
        public string ProductManufactorIdentity { get; set; }
        public int Warranty { get; set; }
        public int WebStockStatus { get; set; }
        public string WebStockText { get; set; }
        public string WebStockTextShort { get; set; }
        public string WebStockMeta { get; set; }
        public int CncStockStatus { get; set; }
        public string CncStockText { get; set; }
        public bool CanAddToCart { get; set; }
        public bool IsOnDemand { get; set; }
        public string ElguideId { get; set; }
        public bool IsRecurringPaymentProduct { get; set; }
        public bool DepositPriceIncluded { get; set; }
    }

}
