using Circle.Data.Models;
using Circle.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circle.Service.Mappings
{
	public static class ReactionMappings
	{
		public static Data.Models.Reaction ToEntity(this ReactionServiceModel model)
		{
			return new Data.Models.Reaction
			{
				Label = model.Label,
				Emote = model.Emote.ToEntity()
			};
		}

		public static ReactionServiceModel ToModel(this Data.Models.Reaction entity)
		{
			return new ReactionServiceModel
			{
				Id = entity.Id,
				CreatedBy = entity.CreatedBy.ToModel(),
				CreatedOn = entity.CreatedOn,
				UpdatedBy = entity.UpdatedBy?.ToModel(),
				UpdatedOn = entity.UpdatedOn,
				DeletedBy = entity.DeletedBy?.ToModel(),
				DeletedOn = entity.DeletedOn,
				Label = entity.Label,
				Emote = entity.Emote?.ToModel()
			};
		}
	}
}
