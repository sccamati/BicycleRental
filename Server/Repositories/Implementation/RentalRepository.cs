using BicycleRental.Server.Repositories.Interfaces;
using BicycleRental.Shared.Entities;

namespace BicycleRental.Server.Repositories.Implementation
{
    public class RentalRepository : Repository<Rental>, IRentalRepository
    {
        public RentalRepository(DataContext context) : base(context)
        {
        }

        public async Task<List<Rental>> GetAllUsersRentals(int id)
        {
            var rentals = await _context.Rentals.Where(r => r.User.Id == id).Include(r => r.Bike).ThenInclude(r => r.BikesType).ToListAsync();
            return rentals;
        }

        public async Task<Rental> GetByIdWithBike(int id)
        {
            var rental = await _context.Rentals.Include(r => r.Bike).SingleAsync(r => r.Id == id);
            return rental;
        }
    }
}
