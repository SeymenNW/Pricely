using Newtonsoft.Json;
using Pricely.Libraries.Shared.Models;
using Pricely.Libraries.Shared.ResponseModels.ComputerSalg;

namespace Pricely.Core.Services.Merchants.ComputerSalg
{
    public class ComputerSalgService : IMerchant, IComputerSalgService
    {
        private readonly HttpClient _httpClient;
        public ComputerSalgService(HttpClient httpClient)
        {
            _httpClient = httpClient;

           
        }

        public Task<UnifiedProductDetails?> GetProductDetailsAsync(string sku)
        {
            throw new NotImplementedException();
        }

        public async IAsyncEnumerable<UnifiedProductPreview> GetProductsFromSearchAsync(string query)
        {
            string url = $"https://www.computersalg.dk/api/Search?count=10&queryText={Uri.EscapeDataString(query)}";
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                throw new Exception("Could not load search results");

            string json = await response.Content.ReadAsStringAsync();
            ComputerSalgSearchResponse searchResponse = JsonConvert.DeserializeObject<ComputerSalgSearchResponse>(json);

            

            foreach (var product in this.ParseProductsFromHtml(searchResponse.HtmlContent))
            {
               
                    yield return product;
                
            }
        }

       
    }
}
