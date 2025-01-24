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
			return new CircleUser
			{
				Email = model.Email,
				PasswordHash = model.PasswordHash, //nz dali e tochno passwordhash ama mai da
				DisplayName = model.DisplayName,
				CreatedAt = model.CreatedAt,
				CricleRole = model.CricleRole,
				IsDeleted = model.IsDeleted
			};
		}

		public static CircleUserServiceModel ToModel(this CircleUser entity)
		{
			return new CircleUserServiceModel
			{
				Email = entity.Email,
				PasswordHash = entity.PasswordHash, //nz dali e tochno passwordhash ama mai da
				DisplayName = entity.DisplayName,
				CreatedAt = entity.CreatedAt,
				CricleRole = entity.CricleRole,
				IsDeleted = entity.IsDeleted
			};
		}
	}
}
