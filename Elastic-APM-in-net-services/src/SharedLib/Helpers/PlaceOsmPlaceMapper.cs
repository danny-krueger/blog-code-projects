using SharedLib.Entities;
using SharedLib.Entities.OsmApi;

namespace SharedLib.Helpers
{
    public static class PlaceOsmPlaceMapper
    {
        public static Place Map(OsmPlace osmPlace)
        {
            if (osmPlace == null)
            {
                return null;
            }

            Address address = null;
            if (osmPlace.Address != null)
            {
                address = new Address
                {
                    Street = osmPlace.Address.Road,
                    HouseNumber = osmPlace.Address.HouseNumber,
                    Zip = osmPlace.Address.Postcode,
                    City = osmPlace.Address.City,
                    Country = osmPlace.Address.Country
                };
            }
            
            return new Place
            {
                Id = osmPlace.PlaceId,
                Name = osmPlace.Namedetails?.Name,
                DisplayName = osmPlace.DisplayName,
                Coordinate = osmPlace.Lat.HasValue && osmPlace.Lon.HasValue 
                    ? new Coordinate(osmPlace.Lat, osmPlace.Lon) 
                    : null,
                Address = address
            };
        }
    }
}