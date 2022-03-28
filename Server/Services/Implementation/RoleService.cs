using BicycleRental.Server.Repositories.Interfaces;
using BicycleRental.Server.Services.Interfaces;

namespace BicycleRental.Server.Services.Implementation
{
    public class RoleService : Service<Role>, IRoleService
    {
        public RoleService(IRepository<Role> repository) : base(repository)
        {
        }
    }
}
