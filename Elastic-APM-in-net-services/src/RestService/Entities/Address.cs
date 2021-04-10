using OsmApi.Entities;

namespace RestService.Entities
{
    public class Address
    {
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string Zip { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public Address(OsmAddress osmAddress)
        {
            Street = osmAddress.Road;
            HouseNumber = osmAddress.HouseNumber;
            Zip = osmAddress.Postcode;
            City = osmAddress.City;
            Country = osmAddress.Country;
        }
    }
}