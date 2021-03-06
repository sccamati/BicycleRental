using BicycleRental.Shared.Dto;
using Blazored.LocalStorage;
using System.Net.Http.Json;

namespace BicycleRental.Client.Services.User
{
    public class UserService : Service<UserDto>, IUserService
    {

        public UserService(HttpClient httpClient, ILocalStorageService localStorageService) : base(httpClient, localStorageService)
        {
        }

        public List<UserDto> Users { get; set; } = new List<UserDto>();
        public UserDto User { get; set; }
    }
}
