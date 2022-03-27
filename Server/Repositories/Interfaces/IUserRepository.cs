
namespace BicycleRental.Server.Repositories.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<List<User>> GetAllWithRoles();
    }
}
