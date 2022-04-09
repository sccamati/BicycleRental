using BicycleRental.Server.Repositories.Interfaces;

namespace BicycleRental.Server.Repositories.Implementation
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DataContext context) : base(context)
        {
        }

        public async Task<List<User>> GetAllWithRoles()
        {
            return await _context.Users.Include(u => u.Role).ToListAsync();
        }

        public async Task<User> GetByEmailWithRole(string email)
        {
            return await _context.Users.Include(u => u.Role).SingleAsync(u => u.Email == email);
        }

        public async Task<User> GetByIdWithRentals(int id)
        {
            return await _context.Users.Include(u => u.Role).Include(u => u.Rentals).SingleAsync(u => u.Id == id);
        }
    }
}
