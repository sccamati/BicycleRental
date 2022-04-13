using BicycleRental.Shared.Dto;
using Blazored.LocalStorage;

namespace BicycleRental.Client.Services.Rental
{
    public class RentalService : Service<RentalDto>, IRentalService
    {
        public RentalService(HttpClient httpClient, ILocalStorageService localStorageService) : base(httpClient, localStorageService)
        {
        }
    }
}
