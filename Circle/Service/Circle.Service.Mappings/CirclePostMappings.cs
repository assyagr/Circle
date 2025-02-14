using Circle.Data.Models;
using Circle.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circle.Service.Mappings
{
	public static class CirclePostMappings
	{
		public static CirclePost ToEntity(this CirclePostServiceModel model)
		{
			return new CirclePost
			{
				Content = model.Content?.Select(content => content.ToEntity()).ToList(),
				Caption = model.Caption,
				TaggedUsers = model.TaggedUsers?.Select(user => user.ToEntity()).ToList(),
				Hashtags = model.Hashtags?.Select(hashtag => hashtag.ToEntity()).ToList()
			};
		}

		public static CirclePostServiceModel ToModel(this CirclePost entity)
		{
			return new CirclePostServiceModel
			{
				Id = entity.Id,
				Content = entity.Content?.Select(content => content.ToModel()).ToList(),
				Caption = entity.Caption,
				Reactions= entity.Reactions?.Select(reaction => reaction.ToModel()).ToList(),
				Comments= entity.Comments?.Select(comment => comment.ToModel(UserPostCommentMappingsContext.Post)).ToList(),
				TaggedUsers = entity.TaggedUsers?.Select(user => user.ToModel()).ToList(),
				Hashtags = entity.Hashtags?.Select(hashtag => hashtag.ToModel()).ToList()
			};
		}
	}
}
