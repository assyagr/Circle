using Circle.Data.Models;
using Circle.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circle.Service.Mappings
{
	public static class UserPostReactionMappings
	{
		public static UserPostReactionServiceModel ToModel(this UserPostReaction entity)
		{
			return new UserPostReactionServiceModel
			{
				Id = entity.Id,
				Reaction = entity.Reaction?.ToModel(),
				Post = entity.Post?.ToModel(),
				User = entity.User?.ToModel()
			};
		}
	}
}
