using BicycleRental.Server.Repositories.Interfaces;
using BicycleRental.Shared.Dto;
using BicycleRental.Shared.Entities;

namespace BicycleRental.Server.Repositories.Implementation
{
    public class RentalRepository : Repository<Rental>, IRentalRepository
    {
        public RentalRepository(DataContext context) : base(context)
        {
        }

        public IQueryable<Rental> GetAllUsersRentals(int id, PaginationDto pagination)
        {
            var rentals = _context.Rentals.Where(r => r.User.Id == id).Include(r => r.Bike)
                .ThenInclude(r => r.BikesType).OrderByDescending(r => r.StartDate);
            return rentals;
        }

        public async Task<Rental> GetByIdWithBike(int id)
        {
            var rental = await _context.Rentals.Include(r => r.Bike).SingleAsync(r => r.Id == id);
            return rental;
        }
    }
}
