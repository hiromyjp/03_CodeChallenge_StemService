using Microsoft.AspNetCore.Mvc;
using StemService.Interfaces;
using System.Collections.Generic;

namespace StemService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StemController : ControllerBase
    {
        private IWordsCatalog _catalog;

        public StemController(IWordsCatalog catalog)
        {
            _catalog = catalog;
        }

        [HttpGet]
        public IActionResult Get(string stem)
        {
            var response = new SearchResponse(_catalog.Find(stem));
            if (response.Data.Count > 0)
                return Ok(response);

            return NotFound(response);
        }


        public class SearchResponse
        {
            public SearchResponse(IList<string> data)
            {
                Data = data;
            }
            public IList<string> Data { get; }
        }
    }
}
