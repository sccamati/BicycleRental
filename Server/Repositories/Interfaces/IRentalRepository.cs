using BicycleRental.Shared.Entities;

namespace BicycleRental.Server.Repositories.Interfaces
{
    public interface IRentalRepository : IRepository<Rental>
    {
        Task<List<Rental>> GetAllUsersRentals(int id);
        Task<Rental> GetByIdWithBike(int id);
    }
}
