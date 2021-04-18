namespace ElasticsearchRepository.Entities
{
    public class CoordinateEs
    {
        public double? Lat { get; set; }
        public double? Lon { get; set; }

        public CoordinateEs(double? lat, double? lon)
        {
            Lat = lat;
            Lon = lon;
        }
    }
}