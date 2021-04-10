using System.Linq;
using DatabaseRepository.EfCore;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace DatabaseRepositoy.Tests.EfCore
{
    public class PlaceContextTests
    {
        private PlaceContext placeContext;
        
        [SetUp]
        public void Setup()
        {
            DbContextOptions<PlaceContext> dbContextOptions = new DbContextOptionsBuilder<PlaceContext>()
                .UseInMemoryDatabase(databaseName: "places_tests")
                .Options;
            placeContext = new PlaceContext(dbContextOptions);
        }

        [Test]
        public void DatabaseTest()
        {
            placeContext.Places.Add(new Place
            {
                Name = "Bar"
            });
            placeContext.Places.Add(new Place
            {
                Name = "Restaurant"
            });

            placeContext.SaveChanges();

            var blogs = placeContext.Places.ToList();
            Assert.AreEqual(2, blogs.Count);
        }
    }
}