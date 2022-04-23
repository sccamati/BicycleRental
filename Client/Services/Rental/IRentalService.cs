using BicycleRental.Shared.Dto;

namespace BicycleRental.Client.Services.Rental
{
    public interface IRentalService : IService<RentalDto>
    {
        public List<RentalDto> UsersRentals { get; set; }
        Task<RentalDto> RentBike(string requestUri, int bikeId);
    }
}
