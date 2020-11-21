using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flight_Project.Models.Amadeus.Search;
using Flight_Project.Repository.Search.Amadeus;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Flight_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchServiceController : ControllerBase
    {
        private readonly ILogger<SearchServiceController> _logger;
        private readonly IAmadeus_SearchRepository _Amadeus_SearchRepositoryCaller;

        public SearchServiceController(ILogger<SearchServiceController> logger, IAmadeus_SearchRepository Amadeus_SearchRepositoryCaller)
        {
            _logger = logger;
            _Amadeus_SearchRepositoryCaller = Amadeus_SearchRepositoryCaller;
        }

        [HttpGet]
        public IActionResult Ping()
        {
            return Ok("Testing Ping Search Service");
        }

        [HttpPost]
        public IActionResult FlightOffersSearch(string SearchString)
        {
            FlightOffersSearchRS FlightOffersSearchRSObj = _Amadeus_SearchRepositoryCaller.FlightOffersSearch(SearchString);
            return Ok(FlightOffersSearchRSObj);
        }
    }
}
