using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circle.Data.Models
{
	public abstract class MetadataBaseEntity : BaseEntity
	{
		public CircleUser CreatedBy { get; set; }

		public DateTime CreatedOn { get; set; }

		public CircleUser UpdatedBy { get; set;}

		public DateTime UpdatedOn { get; set; }

		public CircleUser DeletedBy { get; set; }

		public DateTime DeletedOn { get; set; }
	}
}
