using BicycleRental.Server.Repositories.Interfaces;
using BicycleRental.Shared.Entities;

namespace BicycleRental.Server.Repositories.Implementation
{
    public class RentalRepository : Repository<Rental>, IRentalRepository
    {
        public RentalRepository(DataContext context) : base(context)
        {
        }

        public List<Rental> GetAllUsersRentals(int id)
        {
            var rentals = _context.Rentals.Where(r => r.User.Id == id).Include(r => r.Bike).ToList();
            return rentals;
        }
    }
}
