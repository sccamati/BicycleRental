using BicycleRental.Server.Repositories.Interfaces;
using BicycleRental.Server.Services.Interfaces;
using BicycleRental.Shared.Entities;

namespace BicycleRental.Server.Services.Implementation
{
    public class RoleService : Service<Role>, IRoleService
    {
        public RoleService(IRepository<Role> repository) : base(repository)
        {
        }
    }
}
