using Circle.Data.Models;
using Circle.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circle.Service.Mappings
{
	public static class CircleUserMappings
	{
		public static CircleUser ToEntity(this CircleUserServiceModel model)
		{
			return new CircleUser();
		}

		public static CircleUserServiceModel ToModel(this CircleUser entity)
		{
			if(entity == null)
			{
				return new CircleUserServiceModel();
			}

			return new CircleUserServiceModel
			{
				Email = entity.Email,
				//DisplayName = entity.DisplayName,
				Id = entity.Id,
				UserName = entity.UserName
			};
		}
	}
}
