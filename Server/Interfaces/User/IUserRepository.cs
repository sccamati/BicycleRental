namespace BicycleRental.Server.Abstraction
{
    public interface IUserRepository : IRepository<User>
    {
        Task<List<User>> GetAllWithRoles();
    }
}
