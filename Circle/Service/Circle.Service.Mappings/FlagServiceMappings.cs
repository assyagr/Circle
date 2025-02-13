using Circle.Data.Models;
using Circle.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circle.Service.Mappings
{
	public static class HashtagServiceMappings
	{
		public static Hashtag ToEntity(this HashtagServiceModel model)
		{
			return new Hashtag
			{
				Label = model.Label
			};
		}

		public static HashtagServiceModel ToModel(this Hashtag entity)
		{
			return new HashtagServiceModel
			{
				Id = entity.Id,
				CreatedBy = entity.CreatedBy.ToModel(),
				CreatedOn = entity.CreatedOn,
				UpdatedBy = entity.UpdatedBy?.ToModel(),
				UpdatedOn = entity.UpdatedOn,
				DeletedBy = entity.DeletedBy?.ToModel(),
				DeletedOn = entity.DeletedOn,
				Label = entity.Label
			};
		}
	}
}
