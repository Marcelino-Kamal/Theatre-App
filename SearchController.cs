using Microsoft.AspNetCore.Mvc;
using Theatre_App.DTO.SearchDtos;
using Theatre_App.Service.SearchServices;
namespace Theatre_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly ISearchService _searchService;

        public SearchController(ISearchService searchService)
        {
            _searchService = searchService;
        }

        [HttpPost]
        public ActionResult<List<SearchResultDto>> Post([FromBody] SearchRequestDto request)
        {
            var results = _searchService.Search(request.Query);
            return Ok(results);
        }
    }
}
