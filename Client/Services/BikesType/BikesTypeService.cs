using BicycleRental.Shared.Dto;
using Blazored.LocalStorage;

namespace BicycleRental.Client.Services.BikesType
{
    public class BikesTypeService : Service<BikesTypeDto>, IBikesTypeService
    {
        public BikesTypeService(HttpClient httpClient, ILocalStorageService localStorageService) : base(httpClient, localStorageService)
        {
        }

        public List<BikesTypeDto> Types { get; set; }
    }

}
