﻿using BicycleRental.Shared.Dto.UseCaseResponse.User;

namespace BicycleRental.Client.Services.UserService
{
    public interface IUserService
    {
        public List<GetUsersResponse> Users { get; set; }

        Task GetUsers();
        Task<GetUsersResponse> GetUserById(int id);
    }
}
