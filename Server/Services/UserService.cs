using BicycleRental.Server.Abstraction;

namespace BicycleRental.Server.Services
{

    public class UserService : Service<User>, IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IRepository<User> repository, IUserRepository userRepository) : base(repository)
        {
            _userRepository = userRepository;
        }

        public Task<List<User>> GetAllWithRoles()
        {
            return _userRepository.GetAllWithRoles();
        }
    }
}
