using BicycleRental.Shared.Dto;
using BicycleRental.Shared.Entities;

namespace BicycleRental.Server.Services.Interfaces
{
    public interface IUserService : IService<User>
    {
        Task<List<UserDto>> GetAllWithRoles();
        Task<UserDto> GetByIdWithRentals(int id);
    }
}
