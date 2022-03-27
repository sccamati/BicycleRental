using BicycleRental.Shared.Responses;
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
        public List<GetUserResponse> Users { get; set; } = new List<GetUserResponse>();

        public Task<GetUserResponse> GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task GetUsers()
        {
            var result = await _httpClient.GetFromJsonAsync<List<GetUserResponse>>("api/user");
            if(result != null)
            {
                Users = result;
            }
        }
    }
}
