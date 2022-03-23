namespace BicycleRental.Shared
{
    public class Bike : BaseEntity
    {
        public int Id { get; set; }
        public string SerialNumber { get; set; }
        public string Brand { get; set; }
        public bool IsBorrowed { get; set; }
        public int ProductionDate { get; set; }

        public BikesType BikesType { get; set; }
        public ICollection<Rental> Rentals { get; set; }

        public Bike()
        {
            IsBorrowed = false;
        }
    }
}
