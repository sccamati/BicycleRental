using BicycleRental.Server.Abstraction;

namespace BicycleRental.Server.Services
{

    public class UserService : Service<User>, IUserService
    {

        public UserService(IRepository<User> repository) : base(repository)
        {
        }
    }
}
