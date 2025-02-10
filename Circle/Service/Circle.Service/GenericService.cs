using Circle.Data.Models;
using Circle.Data.Repositories;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Circle.Data.Repositories;

namespace Circle.Service
{
    public abstract class GenericService<TEntity, TModel> : IGenericService<TEntity, TModel> where TModel : BaseEntity
    {
        private readonly IGenericRepository<TModel> _repository;

        public GenericService(IGenericRepository<TModel> repository)
        {
            this._repository = repository;
        }

        public async Task<TModel> CreateAsync(TModel entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            await _repository.CreateAsync(entity);
            return entity;
        }

        public async Task<TModel> DeleteAsync(TModel entity)
        {
            await _repository.DeleteAsync(entity);
            return entity; //Where do it return?
        }

        public async Task<TModel> EditAsync(TModel entity)
        {
            await _repository.EditAsync(entity);
            return entity;
        }

        public IQueryable<TModel> GetAll()
        {
            return this._repository.GetAll(); 
        }

        public IQueryable<TModel> GetAllNoTracking()
        {
            return this._repository.GetAllNoTracking(); 
        }
    }
}
