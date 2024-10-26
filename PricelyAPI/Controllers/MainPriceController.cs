using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using PricelyAPI.ServiceModels.Pricerunner;
using PricelyAPI.Services.PricerunnerService;

namespace PricelyAPI.Controllers
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class MainPriceController : ControllerBase
    {
    

        private readonly ILogger<MainPriceController> _logger;
        private readonly IPricerunnerService _pricerunnerService;
        public MainPriceController(ILogger<MainPriceController> logger, IPricerunnerService pricerunnerService)
        {
            _logger = logger;
            _pricerunnerService = pricerunnerService;
            
        }



        [HttpGet("GetPrice", Name = "GetPrice")]
        /// <summary>
        /// Henter prisdata for de produkter man søger på.
        /// </summary>
        /// <returns>JSON-fil med produkt og søgnings data.</returns>
        public async Task<PricerunnerProductSearch> Get(string search)
        {

        return    await  _pricerunnerService.GetProductsFromSearch(search);


            //return Ok("Prisdata er hentet");
        }

        [HttpGet("GetPric2e", Name = "GetPrice2")]
        public IActionResult Get2()
        {
            return Ok("Prisdata er hentet");
        }
    }
}
