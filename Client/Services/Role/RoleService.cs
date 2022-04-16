using BicycleRental.Shared.Dto;
using Blazored.LocalStorage;

namespace BicycleRental.Client.Services.Role
{
    public class RoleService : Service<RoleDto>, IRoleService
    {
        public RoleService(HttpClient httpClient, ILocalStorageService localStorageService) : base(httpClient, localStorageService)
        {
        }

        public List<RoleDto> Roles { get; set; }
    }
}
