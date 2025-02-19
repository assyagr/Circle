using Circle.Data.Models;
using Circle.Data.Repositories;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circle.Service
{
    public abstract class GenericService<TEntity, TModel> : IGenericService<TEntity, TModel> where TModel : BaseEntity
    {
        //whole thing is just wrong

        private readonly IGenericRepository<TModel> _repository;

        public GenericService(IGenericRepository<TModel> repository)
        {
            this._repository = repository;
        }

        public async Task<TModel> CreateAsync(TModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            await _repository.CreateAsync(model);
            return model;
        }

        public async Task<TModel> DeleteAsync(string id)
        {
            //await _repository.DeleteAsync(string id);
            //return entity; //Where do it return?
            throw new NotImplementedException();
        }

        public async Task<TModel> EditAsync(TModel model)
        {
            await _repository.EditAsync(model);
            return model;
        }

        public IQueryable<TModel> GetAll()
        {
            return this._repository.GetAll(); 
        }

        //public IQueryable<TModel> GetAllNoTracking()
        //{
        //    return this._repository.GetAllNoTracking(); 
        //}
    }
}
