using Microsoft.EntityFrameworkCore;

namespace DatabaseRepository.EfCore
{
    public class PlaceContext : DbContext
    {
        public DbSet<Place> Places { get; set; }
        public DbSet<Address> Addresses { get; set; }

        public PlaceContext(DbContextOptions<PlaceContext> options) : base(options)
        {
        }
    }
}