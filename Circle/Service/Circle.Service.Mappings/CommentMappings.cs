using Circle.Data.Models;
using Circle.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circle.Service.Mappings
{
	public enum CommentMappingsContext
	{
		Reaction,
		Parent,
		Reply,
		User
	}

	public static class CommentMappings
	{
		public static Data.Models.Comment ToEntity(this CommentServiceModel model)
		{
			return new Data.Models.Comment
			{
				Content = model.Content
				//Reactions = model.Reactions?.Select(r => r.ToEntity()).ToList(),
			};
		}

		public static CommentServiceModel ToModel(this Data.Models.Comment entity, CommentMappingsContext context)
		{
			return new CommentServiceModel
			{
				Id = entity.Id,
				CreatedBy = ShouldMapUser(context) ? entity.CreatedBy.ToModel() : null,
				CreatedOn = entity.CreatedOn,
				Content = entity.Content,
				Parent = ShouldMapParent(context) ? entity.Parent?.ToModel(CommentMappingsContext.Reply) : null,
				Reactions = ShouldMapReactions(context) ? entity.Reactions?.Select(reaction => reaction.ToModel(UserCommentReactionMappingsContext.Comment)).ToList() : null,
				Replies = ShouldMapReplies(context) ? entity.Replies?.Select(reply => reply.ToModel(CommentMappingsContext.Parent)).ToList() : null,

			};
		}

		private static bool ShouldMapReactions(CommentMappingsContext context)
		{
			return context == CommentMappingsContext.Parent
				|| context == CommentMappingsContext.Reply
				|| context == CommentMappingsContext.User;
		}

		private static bool ShouldMapReplies(CommentMappingsContext context)
		{
			return context == CommentMappingsContext.Parent
				|| context == CommentMappingsContext.Reaction
				|| context == CommentMappingsContext.User;
		}

		private static bool ShouldMapParent(CommentMappingsContext context)
		{
			return context == CommentMappingsContext.Reaction
				|| context == CommentMappingsContext.Reply
				|| context == CommentMappingsContext.User;
		}

		private static bool ShouldMapUser(CommentMappingsContext context)
		{
			return context == CommentMappingsContext.Reaction
				|| context == CommentMappingsContext.Parent
				|| context == CommentMappingsContext.Reply;
		}
	}
}
