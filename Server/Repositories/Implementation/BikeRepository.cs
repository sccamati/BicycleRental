using BicycleRental.Server.Repositories.Interfaces;

namespace BicycleRental.Server.Repositories.Implementation
{
    public class BikeRepository : Repository<Bike>, IBikeRepository
    {
        public BikeRepository(DataContext context) : base(context)
        {
        }
    }
}
