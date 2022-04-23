using BicycleRental.Shared.Entities;

namespace BicycleRental.Server.Services.Interfaces
{
    public interface IRentalService : IService<Rental>
    {
        Task<List<Rental>> GetAllUsersRentals(int id);
        Task<Rental> GetByIdWithBike(int id);
        Task ReturnBike(int id);
    }
}
