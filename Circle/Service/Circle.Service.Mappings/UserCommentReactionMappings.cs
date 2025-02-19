﻿using Circle.Data.Models;
using Circle.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circle.Service.Mappings
{
	public enum UserCommentReactionMappingsContext
	{
		Comment,
		Reaction,
		User
	}
	public static class UserCommentReactionMappings
	{
		public static UserCommentReactionServiceModel ToModel(this UserCommentReaction entity, UserCommentReactionMappingsContext context)
		{
			return new UserCommentReactionServiceModel
			{
				Id = entity.Id,
				Comment = ShouldMapComments(context) ? entity.Comment?.ToModel(CommentMappingsContext.Reaction) : null,
				Reaction = ShouldMapReaction(context) ? entity.Reaction?.ToModel() : null,
				User = ShouldMapUser(context) ? entity.User?.ToModel() : null
			};
		}

		private static bool ShouldMapComments(UserCommentReactionMappingsContext context)
		{
			return context == UserCommentReactionMappingsContext.Reaction || context == UserCommentReactionMappingsContext.User;
		}

		private static bool ShouldMapReaction(UserCommentReactionMappingsContext context)
		{
			return context == UserCommentReactionMappingsContext.Comment || context == UserCommentReactionMappingsContext.User;
		}

		private static bool ShouldMapUser(UserCommentReactionMappingsContext context)
		{
			return context == UserCommentReactionMappingsContext.Reaction || context == UserCommentReactionMappingsContext.Comment;
		}
	}
}
