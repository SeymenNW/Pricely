using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Pricely.Libraries.Services.Models.Elgiganten;
using PricelyAPI.Services.ElgigantenService;

namespace PricelyAPI.Controllers
{
    [Route("v1/eg")]
    [ApiVersion("1.0")]
    [ApiController]
    public class ElgigantenController : ControllerBase
    {

        private readonly ILogger<ElgigantenController> _logger;
        private readonly IElgigantenService _elgigantenService;
        public ElgigantenController(ILogger<ElgigantenController> logger, IElgigantenService elgigantenService)
        {
            _logger = logger;
            _elgigantenService = elgigantenService;

        }


      
        [HttpGet("search/{search}", Name = "ElgiSearch")]

        public async Task<ElgigantenSearchResults> GetSearch(string search)
        {

            return await _elgigantenService.GetProductsFromSearch(search);

        }
    }
}
