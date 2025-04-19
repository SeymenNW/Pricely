using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pricely.Libraries.Shared.Models;
using Pricely.Server.Services.MultiSearch;

namespace Pricely.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly IMultiSearchService _multiSearchService;

        // Inject MultiSearchService via constructor
        public SearchController(IMultiSearchService multiSearchService)
        {
            _multiSearchService = multiSearchService;
        }

        // GET: api/<SearchController>?query=example
        [HttpGet]
        public IAsyncEnumerable<UnifiedProductPreview> Get([FromQuery] string query)
        {
            // Call MultiSearchService to search across all merchants
            return _multiSearchService.SearchProductsFromAllMerchantsAsync(query);
        }
    }
}
