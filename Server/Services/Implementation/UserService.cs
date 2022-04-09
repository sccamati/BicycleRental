using AutoMapper;
using BicycleRental.Server.Services.Interfaces;
using BicycleRental.Server.Repositories.Interfaces;
using BicycleRental.Shared.Dto.UseCaseResponse.User;

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

        public async Task<List<GetUsersResponse>> GetAllWithRoles()
        {
            var users = await _userRepository.GetAllWithRoles();
            return _mapper.Map<List<User>, List<GetUsersResponse>>(users);
        }

        public async Task<GetUserResponse> GetByIdWithRentals(int id)
        {
            var user = await _userRepository.GetById(id);
            return _mapper.Map<GetUserResponse>(user);
        }
    }
}
