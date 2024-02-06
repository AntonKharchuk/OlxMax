
using OlxMax.Dal.Entity;
using OlxMax.Dal.Repositories;

namespace OlxMax.Business.Services
{
    public class CRUDService<T> : ICRUDService<T> where T : BaseEntity
    {
        protected readonly IGenericRepository<T> _repository;

        public CRUDService(IGenericRepository<T> repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public virtual async Task<IEnumerable<T>> GetAllItemsAsync(string include = "")
        {
            return await _repository.GetAllAsync(include);
        }

        public virtual async Task<T> GetItemByIdAsync(int id, string include = "")
        {
            return await _repository.GetByIdAsync(id, include);
        }

        public virtual async Task CreateItemAsync(T entity)
        {
            await _repository.AddAsync(entity);
            await _repository.SaveAsync();
        }

        public virtual async Task UpdateItemAsync(T entity, int id)
        {
            await _repository.UpdateAsync(entity, id);
            await _repository.SaveAsync();
        }

        public virtual async Task DeleteItemAsync(int id)
        {
            await _repository.DeleteAsync(id);
            await _repository.SaveAsync();
        }
    }
}
