using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Pricely.Libraries.Services.Models;
using PricelyAPI.ServiceModels.Pricerunner;
using PricelyAPI.Services.PricerunnerService;

namespace PricelyAPI.Controllers
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("v1/pr")]
    public class PriceRunnerController : ControllerBase
    {
    

        private readonly ILogger<PriceRunnerController> _logger;
        private readonly IPricerunnerService _pricerunnerService;
        public PriceRunnerController(ILogger<PriceRunnerController> logger, IPricerunnerService pricerunnerService)
        {
            _logger = logger;
            _pricerunnerService = pricerunnerService;
            
        }


        //Eksempel: https://localhost:7036/v1/pr/search/{search}
        /// <summary>
        /// Henter prisdata for de produkter man søger på.
        /// </summary>
        [HttpGet("search/{search}", Name = "Search")]
       
        public async Task<PricerunnerSearchResults> GetSearch(string search)
        {

        return    await  _pricerunnerService.GetProductsFromSearch(search);


            //return Ok("Prisdata er hentet");
        }

        [HttpGet("details/{productId}", Name = "Details")]
        public async Task<PricerunnerProduct> GetProductDetails(string productId)
        {
            return await _pricerunnerService.GetProductDetailsFromId(productId);

        }
    }
}
