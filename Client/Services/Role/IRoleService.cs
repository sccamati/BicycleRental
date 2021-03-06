using BicycleRental.Shared.Dto;

namespace BicycleRental.Client.Services.Role
{
    public interface IRoleService : IService<RoleDto>
    {
        public List<RoleDto> Roles { get; set; }
    }
}
