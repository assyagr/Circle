using Circle.Data.Models;
using Circle.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circle.Service.Mappings
{
    public static class CircleFriendshipMappings
    {
        public static CircleFriendshipServiceModel ToEntity(this CircleFriendshipServiceModel model)
        {
            return new CircleFriendshipServiceModel
            {
                CreatedById = model.CreatedById,
                SentToId = model.SentToId,
                Status = model.Status,
                DateTime = model.DateTime
            };
        }

        public static CircleFriendshipServiceModel ToModel(this CircleFriendshipServiceModel entity)
        {
            return new CircleFriendshipServiceModel
            {
                Id = entity.Id,
                CreatedById = entity.CreatedById,
                SentToId = entity.SentToId,
                Status = entity.Status,
                DateTime = entity.DateTime
            };
        }
    }
}
