namespace DesignPatternsDemo
{
    public class Vehicle
    {
        public string Id { get; }

        public Location Location { get; set; }

        public Vehicle(string id)
        {
            Id = id;
        }
    }
}
