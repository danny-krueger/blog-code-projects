using OsmApi.Entities;

namespace RestService.Entities
{
    public class Place
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public Address Address { get; set; }
        public Coordinate Coordinate { get; set; }

        public Place(OsmPlace osmPlace)
        {
            Id = osmPlace.PlaceId;
            Name = osmPlace.Namedetails?.Name;
            DisplayName = osmPlace.DisplayName;
            Coordinate = osmPlace.Lat.HasValue && osmPlace.Lon.HasValue
                ? new Coordinate(osmPlace.Lat, osmPlace.Lon)
                : null;

            if (osmPlace.Address != null)
            {
                Address = new Address(osmPlace.Address);
            }
            
        }
    }
}