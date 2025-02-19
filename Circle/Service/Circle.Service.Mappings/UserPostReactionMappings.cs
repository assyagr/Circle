using Circle.Data.Models;
using Circle.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circle.Service.Mappings
{
	public enum UserPostReactionMappingsContext
	{
		Post,
		Reaction,
		User
	}
	public static class UserPostReactionMappings
	{
		public static UserPostReactionServiceModel ToModel(this UserPostReaction entity, UserPostReactionMappingsContext context)
		{
			return new UserPostReactionServiceModel
			{
				Id = entity.Id,
				Reaction = ShouldMapReaction(context) ? entity.Reaction?.ToModel() : null,
				Post = ShouldMapThread(context) ? entity.Post?.ToModel() : null,
				User = ShouldMapUser(context) ? entity.User?.ToModel() : null
			};
		}

		private static bool ShouldMapReaction(UserPostReactionMappingsContext context)
		{
			return context == UserPostReactionMappingsContext.Post || context == UserPostReactionMappingsContext.User;
		}

		private static bool ShouldMapThread(UserPostReactionMappingsContext context)
		{
			return context == UserPostReactionMappingsContext.Reaction || context == UserPostReactionMappingsContext.User;
		}

		private static bool ShouldMapUser(UserPostReactionMappingsContext context)
		{
			return context == UserPostReactionMappingsContext.Post || context == UserPostReactionMappingsContext.Reaction;
		}
	}
}
