using DatabaseRepository.EfCore;
using ElasticsearchRepository.Entities;
using OsmApi.Entities;

namespace RestService.Entities
{
    public class AddressDto
    {
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string Zip { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public AddressDto(OsmAddress osmAddress)
        {
            Street = osmAddress.Road;
            HouseNumber = osmAddress.HouseNumber;
            Zip = osmAddress.Postcode;
            City = osmAddress.City;
            Country = osmAddress.Country;
        }
        
        public AddressDto(Address address)
        {
            Street = address.Street;
            HouseNumber = address.HouseNumber;
            Zip = address.Zip;
            City = address.City;
            Country = address.Country;
        }
        
        public AddressDto(AddressEs address)
        {
            Street = address.Street;
            HouseNumber = address.HouseNumber;
            Zip = address.Zip;
            City = address.City;
            Country = address.Country;
        }
    }
}