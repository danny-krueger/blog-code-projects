using System.Linq;
using DatabaseRepository.EfCore;
using DatabaseRepository.Repositories;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace DatabaseRepositoy.Tests
{
    [TestFixture]
    public class PlaceRepositoryTests
    {
        private PlaceContext placeContext;
        private PlaceRepository placeRepository;
        
        [SetUp]
        public void Setup()
        {
            DbContextOptions<PlaceContext> dbContextOptions = new DbContextOptionsBuilder<PlaceContext>()
                .UseInMemoryDatabase(databaseName: "places_repo_tests")
                .Options;
            placeContext = new PlaceContext(dbContextOptions);
            placeRepository = new PlaceRepository(placeContext);
            
            SetupDefaultValuesInDb();
        }

        private void SetupDefaultValuesInDb()
        {
            placeContext.Places.Add(new Place
            {
                Name = "Bar",
                Address = new Address
                {
                    Country = "Germany",
                    City = "Berlin"
                }
            });
            
            placeContext.Places.Add(new Place
            {
                Name = "Restaurant",
                Address = new Address
                {
                    Country = "Germany",
                    City = "Berlin"
                }
            });

            placeContext.SaveChanges();
        }

        [Test]
        public void AddPlaceTest()
        {
            Assert.AreEqual(2, placeContext.Places.Count());
            
            placeRepository.AddPlace(new Place
            {
                Name = "ABC"
            });
            
            Assert.AreEqual(3, placeContext.Places.Count());
        }
        
        [Test]
        public void SearchPlaceTest()
        {
            var places = placeRepository.SearchPlace("bar");
            Assert.AreEqual(1, places.Count);
            Assert.AreEqual("Bar", places.First().Name);
            Assert.IsNotNull(places.First().Address);
            Assert.AreEqual("Germany", places.First().Address.Country);
        }
    }
}