using BicycleRental.Server.Repositories.Interfaces;
using BicycleRental.Server.Services.Interfaces;
using BicycleRental.Shared.Entities;

namespace BicycleRental.Server.Services.Implementation
{
    public class BikesTypeService : Service<BikesType>, IBikesTypeService
    {
        public BikesTypeService(IRepository<BikesType> repository) : base(repository)
        {
        }
    }
}
