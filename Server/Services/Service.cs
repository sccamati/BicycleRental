using BicycleRental.Server.Abstraction;

namespace BicycleRental.Server.Services
{
    public class Service<T> : IService<T> where T : BaseEntity
    {
        protected readonly IRepository<T> _repository;

        public Service(IRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task Add(T item)
        {
            await _repository.Add(item);
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
