namespace BicycleRental.Client.Services.UserService
{
    public interface IUserService
    {
        public List<User> Users { get; set; }

        Task GetUsers();
        Task<User> GetUserById(int id);
    }
}
