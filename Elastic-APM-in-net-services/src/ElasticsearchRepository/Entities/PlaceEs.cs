using System;
using Nest;

namespace ElasticsearchRepository.Entities
{
    public class PlaceEs
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public AddressEs Address { get; set; }
        
        [GeoPoint]
        public CoordinateEs Coordinate { get; set; }
        
        public DateTime? UpdatedAt { get; set; } = DateTime.Now;
    }
}