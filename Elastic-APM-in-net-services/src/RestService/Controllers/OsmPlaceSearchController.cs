using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OsmApi.Api;
using OsmApi.Entities;

namespace RestService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OsmPlaceSearchController : ControllerBase
    {
        private readonly ILogger<OsmPlaceSearchController> logger;
        private readonly INominatimOsmApi nominatimOsmApi;

        public OsmPlaceSearchController(ILogger<OsmPlaceSearchController> logger, 
            INominatimOsmApi nominatimOsmApi)
        {
            this.logger = logger;
            this.nominatimOsmApi = nominatimOsmApi;
        }

        [HttpGet]
        public IEnumerable<OsmPlace> SearchOsmPlaces(string query, int limit = 10)
        {
            return nominatimOsmApi.SearchOsmPlaces(query, limit);
        }
    }
}
