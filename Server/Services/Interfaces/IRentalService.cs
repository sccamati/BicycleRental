using BicycleRental.Shared.Dto;
using BicycleRental.Shared.Entities;

namespace BicycleRental.Server.Services.Interfaces
{
    public interface IRentalService : IService<Rental>
    {
        IQueryable<Rental> GetAllUsersRentals(int id, PaginationDto pagination);
        Task<Rental> GetByIdWithBike(int id);
        Task ReturnBike(int id);
    }
}
