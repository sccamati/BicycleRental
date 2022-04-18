using BicycleRental.Server.Repositories.Interfaces;

namespace BicycleRental.Server.Repositories.Implementation
{
    public class BikeRepository : Repository<Bike>, IBikeRepository
    {
        public BikeRepository(DataContext context) : base(context)
        {
        }

        public new async Task<List<Bike>> GetAll()
        {
            return await _context.Bikes.Include(b => b.BikesType).ToListAsync();
        }

        public new async Task<Bike> GetById(int id)
        {
            return await _context.Bikes.Include(b => b.BikesType).SingleAsync(b => b.Id == id);
        }
    }
}
