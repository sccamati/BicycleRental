using BicycleRental.Server.Abstraction;

namespace BicycleRental.Server.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DataContext context) : base(context)
        {
        }
    }
}
