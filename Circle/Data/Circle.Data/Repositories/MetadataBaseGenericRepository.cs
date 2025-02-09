using Circle.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Circle.Data.Repositories
{
	public class MetadataBaseGenericRepository<TEntity> : BaseGenericRepository<TEntity> where TEntity : MetadataBaseEntity
	{
		private readonly IHttpContextAccessor _httpContextAccessor;

		public MetadataBaseGenericRepository(CircleDbContext dbContext, IHttpContextAccessor httpContextAccessor) : base(dbContext)
		{
			this._httpContextAccessor = httpContextAccessor;
		}

		public override async Task<TEntity> CreateAsync(TEntity entity)
		{
			entity.CreatedOn = DateTime.UtcNow;
			entity.CreatedBy = await this.GetUser();
			return await base.CreateAsync(entity);
		}

		public override async Task<TEntity> EditAsync(TEntity entity)
		{
			entity.UpdatedOn = DateTime.UtcNow;
			entity.UpdatedBy = await this.GetUser();
			return await base.EditAsync(entity);
		}

		public override async Task<TEntity> DeleteAsync(TEntity entity)
		{
			entity.DeletedOn = DateTime.UtcNow;
			entity.DeletedBy = await this.GetUser();
			return await base.DeleteAsync(entity);
		}

		private async Task<CircleUser> GetUser()
		{
			string? userId = this._httpContextAccessor?.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

			return await this._dbContext.Users.SingleOrDefaultAsync(user => user.Id == userId);
		}
	}
}
