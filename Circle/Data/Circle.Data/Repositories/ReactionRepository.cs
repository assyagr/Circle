using Circle.Data.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circle.Data.Repositories
{
	public class ReactionRepository : MetadataBaseGenericRepository<Reaction>
	{
		public ReactionRepository(CircleDbContext _dbContext, IHttpContextAccessor httpContextAccessor) : base(_dbContext, httpContextAccessor)
		{
		}
	}
}
