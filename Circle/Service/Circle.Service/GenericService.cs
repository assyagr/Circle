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
    public abstract class GenericService<T> : IGenericService<T> where T : BaseEntity
    {
        private readonly IGenericRepository<T> _repository;

        public GenericService(IGenericRepository<T> repository)
        {
            this._repository = repository;
        }

        public async Task<T> CreateAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            await _repository.CreateAsync(entity);
            return entity;
        }

        public async Task<T> DeleteAsync(T entity)
        {
            await _repository.DeleteAsync(entity);
            return entity; //Where do it return?
        }

        public async Task<T> EditAsync(T entity)
        {
            await _repository.EditAsync(entity);
            return entity;
        }

        public IQueryable<T> GetAll()
        {
            return this._repository.GetAll(); 
        }

        public IQueryable<T> GetAllNoTracking()
        {
            return this._repository.GetAllNoTracking(); 
        }
    }
}
