using Circle.Data.Models;
using Circle.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circle.Service.Mappings
{
	public static class CommentMappings
	{
		public static Comment ToEntity(this CommentServiceModel model)
		{
			return new Comment
			{
				Content = model.Content,
				//Reactions = model.Reactions?.Select(r => r.ToEntity()).ToList(),
			};
		}

		public static CommentServiceModel ToModel(this Comment entity)
		{
			return new CommentServiceModel
			{
				Id = entity.Id,
				CreatedBy = entity.CreatedBy.ToModel(),
				CreatedOn = entity.CreatedOn,
				UpdatedBy = entity.UpdatedBy?.ToModel(),
				UpdatedOn = entity.UpdatedOn,
				DeletedBy = entity.DeletedBy?.ToModel(),
				Content = entity.Content,
				Reactions = entity.Reactions?.Select(reaction => reaction.ToModel()).ToList(),
				Replies = entity.Replies?.Select(reply => reply.ToModel()).ToList(),

			};
		}
	}
}
