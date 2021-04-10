using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OsmApi.Api;
using RestService.Entities;

namespace RestService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlaceSearchController : ControllerBase
    {
        private readonly ILogger<PlaceSearchController> logger;
        private readonly INominatimOsmApi nominatimOsmApi;

        public PlaceSearchController(ILogger<PlaceSearchController> logger, 
            INominatimOsmApi nominatimOsmApi)
        {
            this.logger = logger;
            this.nominatimOsmApi = nominatimOsmApi;
        }

        [HttpGet]
        public IList<Place> SearchPlaces(string query, int limit = 10)
        {
            logger.LogInformation($"Search places with query '{query}'.");

            IList<Place> places = nominatimOsmApi.SearchOsmPlaces(query, limit)?
                .Select(s => new Place(s))
                .ToList();
            logger.LogInformation($"Found {places?.Count} places.");
            
            return places;
        }
    }
}
