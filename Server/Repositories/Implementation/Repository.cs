using BicycleRental.Server.Repositories.Interfaces;
using BicycleRental.Shared.Entities;

namespace BicycleRental.Server.Repositories.Implementation
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly DataContext _context;
        private readonly DbSet<T> _dbSet;
        public Repository(DataContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public async Task<T> Add(T item)
        {
            await _dbSet.AddAsync(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task Delete(T item)
        {
            _dbSet.Remove(item);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteById(int id)
        {
            var item = await _dbSet.SingleAsync(x => x.Id == id);
            _dbSet.Remove(item);
            await _context.SaveChangesAsync();
        }

        public async Task<List<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _dbSet.SingleAsync(x => x.Id == id);
        }

        public async Task Update(T item)
        {
            _dbSet.Update(item);
            await _context.SaveChangesAsync();
        }

    }
}
