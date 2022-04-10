namespace BicycleRental.Shared.Dto
{
    public class RentalDto
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Price { get; set; }
        public BikeDto Bike { get; set; }
    }
}
