namespace RestService.Entities
{
    public class Coordinate
    {
        public double? Lat { get; set; }
        public double? Lon { get; set; }

        public Coordinate(double? lat, double? lon)
        {
            Lat = lat;
            Lon = lon;
        }
    }
}