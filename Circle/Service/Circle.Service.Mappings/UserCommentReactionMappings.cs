using Circle.Data.Models;
using Circle.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circle.Service.Mappings
{
	public static class UserCommentReactionMappings
	{
		public static UserCommentReactionServiceModel ToModel(this UserCommentReaction entity)
		{
			return new UserCommentReactionServiceModel
			{
				Id = entity.Id,
				Comment = entity.Comment?.ToModel(),
				Reaction = entity.Reaction?.ToModel(),
				User = entity.User?.ToModel()
			};
		}
	}
}
