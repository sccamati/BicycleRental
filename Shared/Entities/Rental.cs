namespace BicycleRental.Shared
{
    public class Rental : BaseEntity
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Price { get; set; }

        public User User { get; set; }
        public Bike Bike { get; set; }
    }
}
