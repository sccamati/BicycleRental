using BicycleRental.Shared.Entities;

namespace BicycleRental.Server.Repositories.Interfaces
{
    public interface IRentalRepository : IRepository<Rental>
    {
        List<Rental> GetAllUsersRentals(int id);
    }
}
