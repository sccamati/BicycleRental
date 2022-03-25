namespace BicycleRental.Server.Abstraction
{
    public interface IUserService : IService<User>
    {
        Task<List<User>> GetAllWithRoles();
    }
}
