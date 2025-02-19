using Circle.Data.Models;
using Circle.Data.Repositories;

namespace Circle.Service
{
    public interface IGenericService <TEntity, TModel> 
    {
    
        Task<TModel> CreateAsync(TModel model);

        IQueryable<TModel> GetAll();

        //IQueryable<TModel> GetAllNoTracking();

        Task<TModel> EditAsync(TModel model);

        Task<TModel> DeleteAsync(string id);

        //matching with BaseGenericRepository

    }
}