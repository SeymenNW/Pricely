using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Pricely.Libraries.Services.Models.PriceRunner;
using PricelyAPI.Services.MerchantServices.PriceRunnerService;

namespace PricelyAPI.Controllers
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("v1/pr")]
    public class PriceRunnerController : ControllerBase
    {
    

        private readonly ILogger<PriceRunnerController> _logger;
        private readonly IPriceRunnerService _pricerunnerService;
        public PriceRunnerController(ILogger<PriceRunnerController> logger, IPriceRunnerService pricerunnerService)
        {
            _logger = logger;
            _pricerunnerService = pricerunnerService;
            
        }


        //Eksempel: https://localhost:7036/v1/pr/search/{search}
        /// <summary>
        /// Henter prisdata for de produkter man søger på.
        /// </summary>
        [HttpGet("search/{search}", Name = "Search")]
       
        public async Task<PriceRunnerSearchResults> GetSearch(string search)
        {

        return    await  _pricerunnerService.GetProductsFromSearch(search);


            //return Ok("Prisdata er hentet");
        }

        [HttpGet("details/{productCategoryNum}/{productId}", Name = "Details")]
        public async Task<PriceRunnerProductDetails> GetProductDetails(string productId, string productCategoryNum)
        {
            return await _pricerunnerService.GetProductDetailsFromId(productId, productCategoryNum);

        }
    }
}
