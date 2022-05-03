using BicycleRental.Shared.Dto;

namespace BicycleRental.Client.Services.Rental
{
    public interface IRentalService : IService<RentalDto>
    {
        public List<RentalDto> UsersRentals { get; set; }
        public int TotalPageQuantity { get; set; }
        public int CurrentPage { get; set; }
        Task<RentalDto> RentBike(string requestUri, int bikeId);
        Task<List<RentalDto>> GetAllUsersRentals(string requestUri);
    }
}
