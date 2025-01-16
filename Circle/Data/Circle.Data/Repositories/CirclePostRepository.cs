using Circle.Data.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circle.Data.Repositories
{
	public class CirclePostRepository : MetadataBaseGenericRepository<CirclePost>
	{
		public CirclePostRepository(CircleDbContext _dbContext, IHttpContextAccessor httpContextAccessor) : base(_dbContext, httpContextAccessor)
		{
		}
	}
}
