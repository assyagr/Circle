using Circle.Data.Models;
using Circle.Data.Repositories;

namespace Circle.Service
{
    public interface IGenericService <T> 
    {
    
        Task<T> CreateAsync(T entity);

        IQueryable<T> GetAll();

        IQueryable<T> GetAllNoTracking();

        Task<T> EditAsync(T entity);

        Task<T> DeleteAsync(T entity);

        //matching with BaseGenericRepository

    }
}