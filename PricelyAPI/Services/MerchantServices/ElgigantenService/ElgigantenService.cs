using Newtonsoft.Json;

using Pricely.Libraries.Shared.Models;
using PricelyAPI.Helpers.Extensions;
using PricelyAPI.Helpers.Handlers;
using PricelyAPI.Services.MerchantServices.ElgigantenService.Elgiganten;
using PricelyAPI.Services.MerchantServices.ElgigantenService.ServiceModels;
using System;
using System.Text;

namespace PricelyAPI.Services.MerchantServices.ElgigantenService
{
    public class ElgigantenService : IElgigantenService
    {
        #region Produktsøgning funktion
        public async Task<ElgigantenSearchResults> GetProductsFromSearch(string search)
        {
            string elgiSearchUrl = "https://www.elgiganten.dk/api/search";

            EGProductSearch payload = new(search);
            string jsonPayload = JsonConvert.SerializeObject(payload).ToString();


            using (HttpClient client = new HttpClient(ProxyManager.AddRotatingProxy()))
            {

                var response = await client.PostAsync(elgiSearchUrl, new StringContent(jsonPayload, Encoding.UTF8, "application/json"));
                var jsonString = await response.Content.ReadAsStringAsync();

                var egSr = JsonConvert.DeserializeObject<EGProductSearchResponse>(jsonString);

                ElgigantenSearchResults elgiResults = new();
                elgiResults.SearchQuery = search;

                List<ElgigantenSearchResultProduct> elgiSearchProductsList = new();

                /*
                 * Lille problem med image Url: Det er ikke altid selve imageUrl som har linket, men nogen responser har yderligere 
                 * property members som skal hentes.
                 * 
                 * Skal undersøges hvordan man gør med dynamiske objekter.
                 */

                foreach (var product in egSr.Data.Records)
                {
                    ElgigantenSearchResultProduct elgiToPricely = new ElgigantenSearchResultProduct
                    {
                        Name = product.Name,
                        CurrentPrice = product.Price?.Current?[0],
                        Sku = product.Sku,
                        StoreUrl = $"https://www.elgiganten.dk{product.Href}",
                        ImageUrl = product.ImageUrl
                    };

                    elgiSearchProductsList.Add(elgiToPricely);
                }

                elgiResults.ProductResults = elgiSearchProductsList;

                return elgiResults;



            }
        }
        #endregion
    }
}
