using BicycleRental.Shared.Dto;
using Blazored.LocalStorage;
using Newtonsoft.Json;
using System.Text;

namespace BicycleRental.Client.Services.Rental
{
    public class RentalService : Service<RentalDto>, IRentalService
    {
        private readonly ILocalStorageService _localStorageService;
        private readonly HttpClient _httpClient;
        public RentalService(HttpClient httpClient, ILocalStorageService localStorageService) : base(httpClient, localStorageService)
        {
            _localStorageService = localStorageService;
            _httpClient = httpClient;
        }

        public List<RentalDto> UsersRentals { get; set; }

        public async Task<RentalDto> RentBike(string requestUri, int bikeId)
        {
            RentalBikeDto rentalBike = new RentalBikeDto
            {
                Id = bikeId
            }; 

            var requestMessage = new HttpRequestMessage(HttpMethod.Post, requestUri);
            var token = await _localStorageService.GetItemAsync<string>("token");

            requestMessage.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            requestMessage.Content = new StringContent(JsonConvert.SerializeObject(rentalBike), Encoding.UTF8, "application/json");

            var response = await _httpClient.SendAsync(requestMessage);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                return await Task.FromResult(JsonConvert.DeserializeObject<RentalDto>(responseBody));
            }

            return null;
        }
    }
}
