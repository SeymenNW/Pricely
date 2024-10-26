namespace PricelyAPI.ServiceModels.Pricerunner
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    //Klasser for deserializering af følgende Endpoint: Product Detail (Produkt Detaljer)
    //https://www.pricerunner.dk/dk/api/search-compare-gateway/public/product-detail/v0/offers/DK/{productId}

    public class PricerunnerProductDetail
    {
        [JsonProperty("filters")]
        public List<Filter> Filters { get; set; }

        [JsonProperty("images")]
        public List<ProductDetailImage> Images { get; set; }

        [JsonProperty("merchants")]
        public Dictionary<string, Merchant> Merchants { get; set; }

        [JsonProperty("offers")]
        public List<ProductDetailOffer> Offers { get; set; }

        [JsonProperty("excludedOffers")]
        public List<object> ExcludedOffers { get; set; }

        [JsonProperty("staticOffers")]
        public List<object> StaticOffers { get; set; }
    }

    public class Filter
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("filterOptions")]
        public List<FilterOption> FilterOptions { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }

    public class FilterOption
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("lowestPrice")]
        public Price LowestPrice { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }
    }

    public class ProductDetailImage
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("path")]
        public string Path { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }

    public class Merchant
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("logo")]
        public MerchantLogo Logo { get; set; }

        [JsonProperty("countryCode")]
        public string CountryCode { get; set; }

        [JsonProperty("internationalCountryCode")]
        public string InternationalCountryCode { get; set; }

        [JsonProperty("rating")]
        public MerchantRating Rating { get; set; }

        [JsonProperty("urlHandling")]
        public string UrlHandling { get; set; }

        [JsonProperty("lastOrderBeforeHolidayDelivery")]
        public object LastOrderBeforeHolidayDelivery { get; set; }

        [JsonProperty("labels")]
        public List<string> Labels { get; set; }

        [JsonProperty("certificates")]
        public List<Certificate> Certificates { get; set; }

        [JsonProperty("paymentMethods")]
        public List<PaymentMethod> PaymentMethods { get; set; }
    }

    public class MerchantLogo
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("path")]
        public string Path { get; set; }
    }

    public class MerchantRating
    {
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("average")]
        public string Average { get; set; }
    }

    public class Certificate
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("logo")]
        public string Logo { get; set; }
    }

    public class PaymentMethod
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

    public class ProductDetailOffer
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
        public object ShippingCost { get; set; }

        [JsonProperty("price")]
        public string Price { get; set; }

        [JsonProperty("merchantId")]
        public string MerchantId { get; set; }

        [JsonProperty("labels")]
        public OfferLabels Labels { get; set; }

        [JsonProperty("pricePerUnit")]
        public object PricePerUnit { get; set; }

        [JsonProperty("installmentPrice")]
        public object InstallmentPrice { get; set; }
    }

    public class OfferLabels
    {
        [JsonProperty("propertyLabels")]
        public List<object> PropertyLabels { get; set; }

        [JsonProperty("attributeLabels")]
        public List<object> AttributeLabels { get; set; }
    }

}
