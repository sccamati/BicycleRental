namespace BicycleRental.Shared.Dto.UseCaseResponse.User
{
    public class GetUsersResponse
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; }
    }
}
