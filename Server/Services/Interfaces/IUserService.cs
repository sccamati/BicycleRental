using BicycleRental.Shared.Dto;

namespace BicycleRental.Server.Services.Interfaces
{
    public interface IUserService : IService<User>
    {
        Task<List<UserDto>> GetAllWithRoles();
        Task<UserDto> GetByIdWithRentals(int id);
    }
}
