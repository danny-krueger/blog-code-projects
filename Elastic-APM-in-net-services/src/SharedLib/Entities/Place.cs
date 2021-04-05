namespace SharedLib.Entities
{
    public class Place
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public Address Address { get; set; }
        public Coordinate Coordinate { get; set; }
    }
}