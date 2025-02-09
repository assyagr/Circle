using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circle.Service.Models
{
	public abstract class MetadataBaseServiceModel : BaseServiceModel
	{
		public CircleUserServiceModel CreatedBy { get; set; }

		public DateTime CreatedOn { get; set; }

		public CircleUserServiceModel? UpdatedBy { get; set; }

		public DateTime? UpdatedOn { get; set; }

		public CircleUserServiceModel? DeletedBy { get; set; }

		public DateTime? DeletedOn { get; set; }
	}
}
