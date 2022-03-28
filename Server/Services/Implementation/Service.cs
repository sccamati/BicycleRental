using BicycleRental.Server.Services.Interfaces;
using BicycleRental.Server.Repositories.Interfaces;

namespace BicycleRental.Server.Services.Implementation
{
    public class Service<T> : IService<T> where T : BaseEntity
    {
        protected readonly IRepository<T> _repository;

        public Service(IRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task<T> Add(T item)
        {
            var newItem = await _repository.Add(item);
            return newItem;
        }

        public async Task Delete(T item)
        {
            await _repository.Delete(item);
        }

        public async Task DeleteById(int id)
        {
            await _repository.DeleteById(id);
        }

        public async Task<List<T>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<T> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task Update(T item)
        {
            await _repository.Update(item);
        }
    }
}
