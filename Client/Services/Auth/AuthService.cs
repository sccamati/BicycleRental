using BicycleRental.Shared.Dto;
using Blazored.LocalStorage;
using Newtonsoft.Json;
using System.Text;

namespace BicycleRental.Client.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;
        public AuthService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> Login(AuthDto user)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, "api/Auth/login");

            requestMessage.Content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");

            var response = await _httpClient.SendAsync(requestMessage);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                return responseBody;
            }

            return null;
        }

        public async Task<bool> Register(AuthRegisterDto user)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, "api/auth/register");

            requestMessage.Content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");

            var response = await _httpClient.SendAsync(requestMessage);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return true;
            }

            return false;
        }
    }
}
