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
        public List<User> Users { get; set; } = new List<User>();

        public Task<User> GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task GetUsers()
        {
            var result = await _httpClient.GetFromJsonAsync<List<User>>("api/user");
            if(result != null)
            {
                Users = result;
            }
        }
    }
}
