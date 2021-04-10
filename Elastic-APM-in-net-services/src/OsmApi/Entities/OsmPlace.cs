namespace OsmApi.Entities
{
    public class OsmPlace
    {
        public int PlaceId { get; set; }
        public double? Lat { get; set; }
        public double? Lon { get; set; }
        public string DisplayName { get; set; }
        public OsmAddress Address { get; set; }
        public OsmNameDetails Namedetails { get; set; }
    }
}