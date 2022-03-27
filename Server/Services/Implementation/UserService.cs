using AutoMapper;
using BicycleRental.Server.Services.Interfaces;
using BicycleRental.Server.Repositories.Interfaces;
using BicycleRental.Shared.Responses;

namespace BicycleRental.Server.Services.Implementation
{

    public class UserService : Service<User>, IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IRepository<User> repository, IUserRepository userRepository, IMapper mapper) : base(repository)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<List<GetUserResponse>> GetAllWithRoles()
        {
            var users = await _userRepository.GetAllWithRoles();
            var mappedUsers = _mapper.Map<List<User>, List<GetUserResponse>>(users);
            return mappedUsers;
        }
    }
}
