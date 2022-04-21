using BicycleRental.Server.Repositories.Interfaces;
using BicycleRental.Shared.Entities;

namespace BicycleRental.Server.Repositories.Implementation
{
    public class BikesTypeRepository : Repository<BikesType>, IBikesTypeRepository
    {
        public BikesTypeRepository(DataContext context) : base(context)
        {
        }
    }
}
