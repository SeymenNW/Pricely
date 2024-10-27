using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Pricely.Libraries.Services.Models.PriceRunner;
using PricelyAPI.ServiceModels.Pricerunner;
using PricelyAPI.Services.PricerunnerService;

namespace PricelyAPI.Controllers
{
    [Route("v1/eg")]
    [ApiVersion("1.0")]
    [ApiController]
    public class ElgigantenController : ControllerBase
    {

        [HttpGet(Name = "GetInt")]
        public int Get()
        {
            return 100;
        }
    }
}
