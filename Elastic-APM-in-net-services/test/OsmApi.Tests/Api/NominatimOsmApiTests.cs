using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using OsmApi.Api;
using SharedLib.Entities.OsmApi;

namespace OsmApi.Tests.Api
{
    public class NominatimOsmApiTests
    {
        private NominatimOsmApi nominatimOsmApi;

        [SetUp]
        public void Setup()
        {
            nominatimOsmApi = new NominatimOsmApi();
        }

        [Test]
        public void SearchOsmPlacesTest()
        {
            string query = "bakery in berlin wedding";
            int osmPlaceIdExpected = 1286434;

            IList<OsmPlace> osmPlaces = nominatimOsmApi.SearchOsmPlaces(query, 10);
            Assert.IsNotNull(osmPlaces);
            CollectionAssert.Contains(osmPlaces.Select(s => s.PlaceId), osmPlaceIdExpected);

            OsmPlace osmPlace = osmPlaces.FirstOrDefault(s => s.PlaceId == osmPlaceIdExpected);
            Assert.IsNotNull(osmPlace);
            Assert.AreEqual("Kamps", osmPlace.Namedetails.Name);
            Assert.AreEqual("Berlin", osmPlace.Address.City);
            Assert.AreEqual("Müllerstraße", osmPlace.Address.Road);
        }
    }
}