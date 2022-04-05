using AutoMapper;
using BicycleRental.Server.Repositories.Interfaces;
using BicycleRental.Server.Services.Interfaces;
using BicycleRental.Shared.Dto.UseCaseResponse.Bike.Bike.Bike;

namespace BicycleRental.Server.Services.Implementation
{
    public class BikeService : Service<Bike>, IBikeService
    {
        private readonly IMapper _mapper;
        public BikeService(IRepository<Bike> repository, IMapper mapper) : base(repository)
        {
            _mapper = mapper;
        }

        public async Task<List<GetBikeReponse>> GetAllBikes()
        {
            var bikes = await _repository.GetAll();
            return _mapper.Map<List<Bike>, List<GetBikeReponse>>(bikes);
        }
    }
}
