using BicycleRental.Shared.Dto.UseCaseResponse.User;
using System.Net.Http.Json;

namespace BicycleRental.Client.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public List<GetUsersResponse> Users { get; set; } = new List<GetUsersResponse>();

        public Task<GetUsersResponse> GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task GetUsers()
        {
            var result = await _httpClient.GetFromJsonAsync<List<GetUsersResponse>>("api/user");
            if(result != null)
            {
                Users = result;
            }
        }
    }
}
