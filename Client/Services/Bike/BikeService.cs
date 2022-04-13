using BicycleRental.Shared.Dto;
using Blazored.LocalStorage;

namespace BicycleRental.Client.Services.Bike
{
    public class BikeService : Service<BikeDto>, IBikeService
    {
        public BikeService(HttpClient httpClient, ILocalStorageService localStorageService) : base(httpClient, localStorageService)
        {
        }
    }
}
