﻿using BicycleRental.Shared.Dto.UseCaseResponse.Bike;

namespace BicycleRental.Server.Services.Interfaces
{
    public interface IBikeService : IService<Bike>
    {
        Task<List<GetBikesReponse>> GetAllBikes();
    }
}