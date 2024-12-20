using Circle.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circle.Data.Repositories
{
	public class AttachmentRepository : BaseGenericRepository<Attachment>
	{
		public AttachmentRepository(CircleDbContext _dbContext) : base(_dbContext)
		{
		}
	}
}
