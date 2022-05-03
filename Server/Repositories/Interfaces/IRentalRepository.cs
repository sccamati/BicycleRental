using BicycleRental.Shared.Dto;
using BicycleRental.Shared.Entities;

namespace BicycleRental.Server.Repositories.Interfaces
{
    public interface IRentalRepository : IRepository<Rental>
    {
        IQueryable<Rental> GetAllUsersRentals(int id, PaginationDto pagination);
        Task<Rental> GetByIdWithBike(int id);
    }
}
