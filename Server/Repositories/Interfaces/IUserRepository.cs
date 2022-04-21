
using BicycleRental.Shared.Entities;

namespace BicycleRental.Server.Repositories.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<List<User>> GetAllWithRoles();
        Task<User> GetByIdWithRentals(int id);
        Task<User> GetByEmailWithRole(string email);
    }
}
