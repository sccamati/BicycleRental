namespace BicycleRental.Shared
{
    public class BikesType : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Bike> Bikes { get; set; }
    }
}
