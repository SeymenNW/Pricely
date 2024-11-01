using Newtonsoft.Json;
using Pricely.Libraries.Services.Models.Elgiganten;
using Pricely.Libraries.Services.Models.PriceRunner;
using PricelyAPI.Helpers.Extensions;
using PricelyAPI.Helpers.Handlers;
using PricelyAPI.Services.MerchantServices.ElgigantenService.Elgiganten;
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

                dynamic egSr = JsonConvert.DeserializeObject<dynamic>(jsonString);

                ElgigantenSearchResults elgiResults = new();
                elgiResults.SearchQuery = search;

                List<ElgigantenSearchResultProduct> elgiSearchProductsList = new();

                /*
                 * Lille problem med image Url: Det er ikke altid selve imageUrl som har linket, men nogen responser har yderligere 
                 * property members som skal hentes.
                 * 
                 * Skal undersøges hvordan man gør med dynamiske objekter.
                 */

                foreach (var product in egSr.data.records)
                {
                    ElgigantenSearchResultProduct elgiToPricely = new ElgigantenSearchResultProduct
                    {
                        Name = (string)product?.name,
                        CurrentPrice = (string)product?.price?.current[0],
                        Sku = (string)product?.sku,
                        StoreUrl = $"https://www.elgiganten.dk{(string)product?.href}",
                        ImageUrl = (string)product?.imageUrl.ToString(),

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
