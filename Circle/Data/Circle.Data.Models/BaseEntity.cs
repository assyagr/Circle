using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circle.Data.Models
{
	public abstract class BaseEntity
	{
		public string Id { get; set; } = Guid.NewGuid().ToString();
	}
}
