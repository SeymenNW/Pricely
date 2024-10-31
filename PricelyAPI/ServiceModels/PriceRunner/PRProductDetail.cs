using Newtonsoft.Json;
using System.Collections.Generic;

namespace PricelyAPI.ServiceModels.Pricerunner
{
    public class PRProductDetail
    {
        [JsonProperty("filters")]
        public List<PDFilter> Filters { get; set; }

        [JsonProperty("images")]
        public List<PDImage> Images { get; set; }

        [JsonProperty("merchants")]
        public Dictionary<string, PDMerchant> Merchants { get; set; }

        [JsonProperty("offers")]
        public List<PDOffer> Offers { get; set; }

        [JsonProperty("excludedOffers")]
        public List<object> ExcludedOffers { get; set; }

        [JsonProperty("staticOffers")]
        public List<object> StaticOffers { get; set; }

    }

    public class PDFilter
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("filterOptions")]
        public List<PDFilterOption> FilterOptions { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }

    public class PDFilterOption
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("lowestPrice")]
        public PDPrice LowestPrice { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }
    }

    public class PDPrice
    {
        [JsonProperty("amount")]
        public string Amount { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }
    }

    public class PDImage
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("path")]
        public string Path { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }

    public class PDMerchant
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("logo")]
        public PDLogo Logo { get; set; }

        [JsonProperty("countryCode")]
        public string CountryCode { get; set; }

        [JsonProperty("internationalCountryCode")]
        public string InternationalCountryCode { get; set; }

        [JsonProperty("rating")]
        public PDRating Rating { get; set; }

        [JsonProperty("urlHandling")]
        public string UrlHandling { get; set; }

        [JsonProperty("lastOrderBeforeHolidayDelivery")]
        public object LastOrderBeforeHolidayDelivery { get; set; }

        [JsonProperty("labels")]
        public List<string> Labels { get; set; }

        [JsonProperty("certificates")]
        public List<PDCertificate> Certificates { get; set; }

        [JsonProperty("paymentMethods")]
        public List<PDPaymentMethod> PaymentMethods { get; set; }
    }

    public class PDLogo
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("path")]
        public string Path { get; set; }
    }

    public class PDRating
    {
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("average")]
        public string Average { get; set; }
    }

    public class PDCertificate
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("logo")]
        public string Logo { get; set; }
    }

    public class PDPaymentMethod
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("logo")]
        public string Logo { get; set; }

        [JsonProperty("order")]
        public int Order { get; set; }
    }

    public class PDOffer
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("stockStatus")]
        public string StockStatus { get; set; }

        [JsonProperty("availability")]
        public string Availability { get; set; }

        [JsonProperty("deliveryTime")]
        public object DeliveryTime { get; set; }

        [JsonProperty("shippingCost")]
        public PDShippingCost ShippingCost { get; set; }

        [JsonProperty("price")]
        public PDPrice Price { get; set; }

        [JsonProperty("merchantId")]
        public string MerchantId { get; set; }

        [JsonProperty("labels")]
        public PDLabels Labels { get; set; }

        [JsonProperty("pricePerUnit")]
        public object PricePerUnit { get; set; }

        [JsonProperty("installmentPrice")]
        public object InstallmentPrice { get; set; }
    }

    public class PDShippingCost
    {
        [JsonProperty("amount")]
        public string Amount { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }
    }

    public class PDLabels
    {
        [JsonProperty("propertyLabels")]
        public List<object> PropertyLabels { get; set; }

        [JsonProperty("attributeLabels")]
        public List<object> AttributeLabels { get; set; }
    }
}