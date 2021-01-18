using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StemService.Controllers.Services;
using StemService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StemService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StemController : ControllerBase
    {
        private const string uri = "https://raw.githubusercontent.com/dwyl/english-words/master/words_alpha.txt";

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
