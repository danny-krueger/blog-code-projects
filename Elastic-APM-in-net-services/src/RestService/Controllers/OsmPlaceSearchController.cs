﻿using System.Collections.Generic;
using System.Linq;
using DatabaseRepository.EfCore;
using DatabaseRepository.Repositories;
using ElasticsearchRepository.Entities;
using ElasticsearchRepository.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OsmApi.Api;
using RestService.Entities;

namespace RestService.Controllers
{
    [ApiController]
    [Route("places")]
    public class PlaceSearchController : ControllerBase
    {
        private readonly ILogger<PlaceSearchController> logger;
        private readonly INominatimOsmApi nominatimOsmApi;
        private readonly IPlaceRepository placeRepository;
        private readonly IPlaceEsRepository placeEsRepository;

        public PlaceSearchController(ILogger<PlaceSearchController> logger,
            INominatimOsmApi nominatimOsmApi, IPlaceRepository placeRepository, 
            IPlaceEsRepository placeEsRepository)
        {
            this.logger = logger;
            this.nominatimOsmApi = nominatimOsmApi;
            this.placeRepository = placeRepository;
            this.placeEsRepository = placeEsRepository;
        }

        [HttpGet("searchPlacesMariaDb")]
        public IList<PlaceDto> SearchPlacesMariaDb(string query, int limit = 10)
        {
            logger.LogInformation($"Search places with query '{query}'.");

            IList<Place> placesDb = placeRepository.SearchPlace(query, limit);
            if (placesDb.Any())
            {
                logger.LogInformation($"Found {placesDb.Count} places from database.");
                return placesDb.Select(s => new PlaceDto(s)).ToList();
            }

            IList<PlaceDto> places = nominatimOsmApi.SearchOsmPlaces(query, limit)?
                .Select(s => new PlaceDto(s))
                .ToList();
            logger.LogInformation($"Found {places?.Count} places from OSM.");

            AddPlacesToDatabase(places);

            return places;
        }

        private void AddPlacesToDatabase(IList<PlaceDto> places)
        {
            logger.LogInformation($"Store {places.Count} places to MariaDB.");
            
            foreach (PlaceDto placeDto in places)
            {
                placeRepository.AddPlace(new Place
                {
                    Id = placeDto.Id,
                    Name = placeDto.Name,
                    DisplayName = placeDto.DisplayName,
                    Lat = placeDto.Coordinate.Lat,
                    Lon = placeDto.Coordinate.Lon,
                    Address = new Address
                    {
                        City = placeDto.Address.City,
                        Street = placeDto.Address.Street,
                        HouseNumber = placeDto.Address.HouseNumber,
                        Zip = placeDto.Address.Zip,
                        Country = placeDto.Address.Country,
                    }
                });
            }
        }
        
        [HttpGet("searchPlacesElasticsearch")]
        public IList<PlaceDto> SearchPlacesElasticsearch(string query, int limit = 10)
        {
            logger.LogInformation($"Search places with query '{query}'.");

            IList<PlaceEs> placesEs = placeEsRepository.SearchPlaces(query, limit).ToList();
            if (placesEs.Any())
            {
                logger.LogInformation($"Found {placesEs.Count} places from Elasticsearch.");
                return placesEs.Select(s => new PlaceDto(s)).ToList();
            }

            IList<PlaceDto> places = nominatimOsmApi.SearchOsmPlaces(query, limit)?
                .Select(s => new PlaceDto(s))
                .ToList();
            logger.LogInformation($"Found {places?.Count} places from OSM.");

            AddPlacesElasticsearch(places);

            return places;
        }

        private void AddPlacesElasticsearch(IList<PlaceDto> places)
        {
            logger.LogInformation($"Store {places.Count} places to Elasticsearch.");
            
            foreach (PlaceDto placeDto in places)
            {
                placeEsRepository.AddPlace(new PlaceEs
                {
                    Id = placeDto.Id,
                    Name = placeDto.Name,
                    DisplayName = placeDto.DisplayName,
                    Coordinate = new CoordinateEs(placeDto.Coordinate.Lat, placeDto.Coordinate.Lon),
                    Address = new AddressEs
                    {
                        City = placeDto.Address.City,
                        Street = placeDto.Address.Street,
                        HouseNumber = placeDto.Address.HouseNumber,
                        Zip = placeDto.Address.Zip,
                        Country = placeDto.Address.Country,
                    }
                });
            }
        }
    }
}