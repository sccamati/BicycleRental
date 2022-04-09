namespace BicycleRental.Shared
{
    public class User : BaseEntity
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public Role Role { get; set; }
        public ICollection<Rental> Rentals { get; set; }
    }
}
 