using Circle.Data.Models;
using Circle.Data.Repositories;

namespace Circle.Service
{
    public interface IGenericService <T> 
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(Guid id);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<bool> DeleteAsync(Guid id);


    }
}