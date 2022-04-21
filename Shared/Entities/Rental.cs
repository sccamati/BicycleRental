namespace BicycleRental.Shared.Entities
{
    public class Rental : BaseEntity
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Price { get; set; }

        public User User { get; set; }
        public Bike Bike { get; set; }
    }
}
