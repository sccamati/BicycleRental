using BicycleRental.Shared.Entities;

namespace BicycleRental.Server.Repositories.Interfaces
{
    public interface IRoleRepository : IRepository<Role>
    {
        Task<Role> GetByName(string name);
    }
}
