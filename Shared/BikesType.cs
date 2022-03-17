namespace BicycleRental.Shared
{
    public class BikesType
    {
        public int Id { get; set; }
        public int Name { get; set; }

        public ICollection<Bike> Bikes { get; set; }
    }
}
