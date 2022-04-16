using AutoMapper;
using BicycleRental.Server.Repositories.Interfaces;
using BicycleRental.Server.Services.Interfaces;
using BicycleRental.Shared.Dto;

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

        public async Task<List<UserDto>> GetAllWithRoles()
        {
            var users = await _userRepository.GetAllWithRoles();
            return _mapper.Map<List<User>, List<UserDto>>(users);
        }

        public async Task<UserDto> GetByIdWithRentals(int id)
        {
            var user = await _userRepository.GetByIdWithRentals(id);
            return _mapper.Map<UserDto>(user);
        }
    }
}
