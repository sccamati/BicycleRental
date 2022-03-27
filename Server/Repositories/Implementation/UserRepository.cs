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
    }
}
