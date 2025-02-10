using Circle.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circle.Data.Repositories
{
	public abstract class BaseGenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
	{
		protected readonly CircleDbContext _dbContext;

		protected BaseGenericRepository(CircleDbContext _dbContext)
		{
			this._dbContext = _dbContext;
		}

		public virtual async Task<TEntity> CreateAsync(TEntity entity)
		{
			await this._dbContext.AddAsync(entity);
			await this._dbContext.SaveChangesAsync();
			return entity;
		}

		public virtual async Task<TEntity> DeleteAsync(TEntity entity)
		{
			this._dbContext.Remove(entity);
			await this._dbContext.SaveChangesAsync();
			return entity;
		}

		public virtual async Task<TEntity> EditAsync(TEntity entity)
		{
			this._dbContext.Update(entity);
			await this._dbContext.SaveChangesAsync();
			return entity;
		}

		public virtual IQueryable<TEntity> GetAll()
		{
			return this._dbContext.Set<TEntity>().AsQueryable<TEntity>();
		}

		public virtual IQueryable<TEntity> GetAllNoTracking()
		{
			return this._dbContext.Set<TEntity>().AsNoTracking();
		}
	}
}
