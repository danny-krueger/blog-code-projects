using DatabaseRepository.EfCore;
using ElasticsearchRepository.Entities;
using OsmApi.Entities;

namespace RestService.Entities
{
    public class PlaceDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public AddressDto Address { get; set; }
        public CoordinateDto Coordinate { get; set; }

        public PlaceDto(OsmPlace osmPlace)
        {
            Id = osmPlace.PlaceId;
            Name = osmPlace.Namedetails?.Name;
            DisplayName = osmPlace.DisplayName;
            Coordinate = osmPlace.Lat.HasValue && osmPlace.Lon.HasValue
                ? new CoordinateDto(osmPlace.Lat, osmPlace.Lon)
                : null;

            if (osmPlace.Address != null)
            {
                Address = new AddressDto(osmPlace.Address);
            }
        }
        
        public PlaceDto(Place place)
        {
            Id = place.Id;
            Name = place.Name;
            DisplayName = place.DisplayName;
            Coordinate = place.Lat.HasValue && place.Lon.HasValue
                ? new CoordinateDto(place.Lat, place.Lon)
                : null;

            if (place.Address != null)
            {
                Address = new AddressDto(place.Address);
            }
        }
        
        public PlaceDto(PlaceEs place)
        {
            Id = place.Id;
            Name = place.Name;
            DisplayName = place.DisplayName;
            Coordinate = place.Coordinate != null
                ? new CoordinateDto(place.Coordinate.Lat, place.Coordinate.Lon)
                : null;

            if (place.Address != null)
            {
                Address = new AddressDto(place.Address);
            }
        }
    }
}