using Circle.Data.Models;
using Circle.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circle.Service.Mappings
{
		public enum UserPostCommentMappingsContext
		{
			Post,
			Comment,
			User
		}

		public static class UserPostCommentMappings
		{
			public static UserPostCommentServiceModel ToModel(this UserPostComment entity, UserPostCommentMappingsContext context)
			{
				return new UserPostCommentServiceModel
				{
					Id = entity.Id,
					Comment = ShouldMapComments(context) ? entity.Comment?.ToModel() : null,
					Post = ShouldMapThread(context) ? entity.Post?.ToModel() : null,
					User = ShouldMapUser(context) ? entity.User?.ToModel() : null
				};
			}

			private static bool ShouldMapComments(UserPostCommentMappingsContext context)
			{
				return context == UserPostCommentMappingsContext.Post || context == UserPostCommentMappingsContext.User;
			}

			private static bool ShouldMapThread(UserPostCommentMappingsContext context)
			{
				return context == UserPostCommentMappingsContext.Comment || context == UserPostCommentMappingsContext.User;
			}

			private static bool ShouldMapUser(UserPostCommentMappingsContext context)
			{
				return context == UserPostCommentMappingsContext.Post || context == UserPostCommentMappingsContext.Comment;
			}
		}
}
