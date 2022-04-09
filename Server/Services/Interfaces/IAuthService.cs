using BicycleRental.Shared.Dto.UseCaseRequest.User;

namespace BicycleRental.Server.Services.Interfaces
{
    public interface IAuthService
    {
        Task<User> Register(UserDto userDto);
        Task<string> Login(UserDto userDto);
    }
}
