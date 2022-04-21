using BicycleRental.Shared.Entities;

namespace BicycleRental.Server.Services.Interfaces
{
    public interface IRentalService : IService<Rental>
    {
        List<Rental> GetAllUsersRentals(int id);
    }
}
