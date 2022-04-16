namespace BicycleRental.Shared
{
    public class BikesType : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<Bike> Bikes { get; set; }
    }
}
