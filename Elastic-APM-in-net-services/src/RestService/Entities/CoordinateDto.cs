namespace RestService.Entities
{
    public class CoordinateDto
    {
        public double? Lat { get; set; }
        public double? Lon { get; set; }

        public CoordinateDto(double? lat, double? lon)
        {
            Lat = lat;
            Lon = lon;
        }
    }
}