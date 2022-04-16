using Blazored.LocalStorage;
using Newtonsoft.Json;
using System.Text;

namespace BicycleRental.Client.Services
{
    public class Service<T> : IService<T> where T : BaseEntity
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorageService;

        public Service(HttpClient httpClient, ILocalStorageService localStorageService)
        {
            _httpClient = httpClient;
            _localStorageService = localStorageService;
        }

        public async Task<T> CreateAsync(string requestUri, T entity)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, requestUri);
            var token = await _localStorageService.GetItemAsStringAsync("token");

            requestMessage.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            requestMessage.Content = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");

            var response = await _httpClient.SendAsync(requestMessage);

            if(response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var responseBody =  await response.Content.ReadAsStringAsync();
                return await Task.FromResult(JsonConvert.DeserializeObject<T>(responseBody));
            }

            return null;
        }

        public async Task<bool> DeleteByIdAsync(string requestUri, int id)
        {
            string uri = Path.Combine(requestUri, id.ToString());

            var requestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);
            var token = await _localStorageService.GetItemAsync<string>("token");

            requestMessage.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            
            var response = await _httpClient.SendAsync(requestMessage);

            if(response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return true;
            }

            return false;
        }

        public async Task<List<T>> GetAllAsync(string requestUri)
        {

            var requestMessage = new HttpRequestMessage(HttpMethod.Get, requestUri);
            var token = await _localStorageService.GetItemAsync<string>("token");

            requestMessage.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.SendAsync(requestMessage);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                return await Task.FromResult(JsonConvert.DeserializeObject<List<T>>(responseBody));
            }

            return null;
        }

        public async Task<T> GetByIdAync(string requestUri, int id)
        {
            string uri = Path.Combine(requestUri, id.ToString());

            var requestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
            var token = await _localStorageService.GetItemAsync<string>("token");

            requestMessage.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.SendAsync(requestMessage);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                return await Task.FromResult(JsonConvert.DeserializeObject<T>(responseBody));
            }

            return null;
        }

        public async Task<bool> UpdateAsync(string requestUri, T entity)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Put, requestUri);
            var token = await _localStorageService.GetItemAsync<string>("token");

            requestMessage.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            requestMessage.Content = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");

            var response = await _httpClient.SendAsync(requestMessage);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return true;
            }

            return false;
        }
    }
}
