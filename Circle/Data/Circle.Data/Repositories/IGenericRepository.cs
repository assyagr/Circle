using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circle.Data.Repositories
{
	public interface IGenericRepository<TEntity>
	{
		Task<TEntity> CreateAsync(TEntity entity);

		IQueryable<TEntity> GetAll();

		IQueryable<TEntity> GetAllNoTracking();

		Task<TEntity> EditAsync(TEntity entity);

		Task<TEntity> DeleteAsync(TEntity entity);
	}
}
