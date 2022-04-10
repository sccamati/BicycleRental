using BicycleRental.Shared.Dto;
using Blazored.LocalStorage;
using Newtonsoft.Json;
using System.Text;

namespace BicycleRental.Client.Services.Auth
{
    public class AuthSerivce : IAuthService
    {
        private readonly HttpClient _httpClient;
        public AuthSerivce(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<AuthDto> Login(AuthDto user)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, "api/auth/login");

            requestMessage.Content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");

            var response = await _httpClient.SendAsync(requestMessage);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                return await Task.FromResult(JsonConvert.DeserializeObject<AuthDto>(responseBody));
            }

            return null;
        }

        public async Task<AuthDto> Register(AuthDto user)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, "api/auth/register");

            requestMessage.Content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");

            var response = await _httpClient.SendAsync(requestMessage);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                return await Task.FromResult(JsonConvert.DeserializeObject<AuthDto>(responseBody));
            }

            return null;
        }
    }
}
