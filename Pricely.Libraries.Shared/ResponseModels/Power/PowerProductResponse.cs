using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Pricely.Libraries.Shared.ResponseModels.Power
{
   

    public class PowerProductResponse
    {
        [JsonProperty("categoryId")]
        public int CategoryId { get; set; }

        [JsonProperty("categoryName")]
        public string? CategoryName { get; set; }

        [JsonProperty("clickNCollectStoreCount")]
        public int? ClickNCollectStoreCount { get; set; }

        [JsonProperty("energyTier")]
        public int? EnergyTier { get; set; }

        [JsonProperty("isLimitedQuantity")]
        public bool? IsLimitedQuantity { get; set; }

        [JsonProperty("manufacturerName")]
        public string? ManufacturerName { get; set; }

        [JsonProperty("manufacturerId")]
        public int? ManufacturerId { get; set; }

        [JsonProperty("price")]
        public double? Price { get; set; }

        [JsonProperty("productId")]
        public int ProductId { get; set; }

        [JsonProperty("salesArguments")]
        public string? SalesArguments { get; set; }

        [JsonProperty("shortDescription")]
        public string? ShortDescription { get; set; }

        [JsonProperty("stockCount")]
        public int? StockCount { get; set; }

        [JsonProperty("storesStockCount")]
        public int? StoresStockCount { get; set; }

        [JsonProperty("stockDeliveryDateConfirmed")]
        public bool? StockDeliveryDateConfirmed { get; set; }

        [JsonProperty("stockLimitedRemaining")]
        public int? StockLimitedRemaining { get; set; }

        [JsonProperty("title")]
        public string? Title { get; set; }

        [JsonProperty("url")]
        public string? Url { get; set; }

        [JsonProperty("advertisingCampaigns")]
        public List<AdvertisingCampaign>? AdvertisingCampaigns { get; set; }

        [JsonProperty("breadcrumb")]
        public List<Breadcrumb>? Breadcrumb { get; set; }

        [JsonProperty("productReview")]
        public ProductReview? ProductReview { get; set; }

        [JsonProperty("hasDescription")]
        public bool? HasDescription { get; set; }

        [JsonProperty("serviceCategoryId")]
        public int? ServiceCategoryId { get; set; }

        [JsonProperty("vatPercent")]
        public double? VatPercent { get; set; }

        [JsonProperty("modelType")]
        public int? ModelType { get; set; }

        [JsonProperty("priceType")]
        public int? PriceType { get; set; }

        [JsonProperty("barcode")]
        public string? Barcode { get; set; }

        [JsonProperty("eanGtin12")]
        public string? EanGtin12 { get; set; }

        [JsonProperty("showSavingsAs")]
        public int? ShowSavingsAs { get; set; }

        [JsonProperty("productImage")]
        public ProductImage? ProductImage { get; set; }

        [JsonProperty("productManuals")]
        public List<object>? ProductManuals { get; set; }

        [JsonProperty("campaignMediaUrl")]
        public string? CampaignMediaUrl { get; set; }

        [JsonProperty("webStatus")]
        public int? WebStatus { get; set; }

        [JsonProperty("productManufactorIdentity")]
        public string? ProductManufactorIdentity { get; set; }

        [JsonProperty("webStockStatus")]
        public int? WebStockStatus { get; set; }

        [JsonProperty("webStockText")]
        public string? WebStockText { get; set; }

        [JsonProperty("webStockTextShort")]
        public string? WebStockTextShort { get; set; }

        [JsonProperty("webStockMeta")]
        public string? WebStockMeta { get; set; }

        [JsonProperty("cncStockStatus")]
        public int? CncStockStatus { get; set; }

        [JsonProperty("cncStockText")]
        public string? CncStockText { get; set; }

        [JsonProperty("canAddToCart")]
        public bool? CanAddToCart { get; set; }

        [JsonProperty("isOnDemand")]
        public bool? IsOnDemand { get; set; }

        [JsonProperty("elguideId")]
        public string? ElguideId { get; set; }

        [JsonProperty("isRecurringPaymentProduct")]
        public bool? IsRecurringPaymentProduct { get; set; }

        [JsonProperty("releaseDate")]
        public DateTime? ReleaseDate { get; set; }

        [JsonProperty("depositPriceIncluded")]
        public bool? DepositPriceIncluded { get; set; }
    }

  
}
