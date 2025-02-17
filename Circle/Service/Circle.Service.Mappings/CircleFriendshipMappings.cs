using Circle.Data.Models;
using Circle.Service.Models;
using System;

namespace Circle.Service.Mappings
{
    public static class CircleFriendshipMappings
    {
        public static CircleFriendship ToEntity(this CircleFriendshipServiceModel model)
        {
            return new CircleFriendship
            {
                Id = model.Id,
                SenderId = model.SenderId.ToEntity(),
                SenderName = model.SenderName,
                AddresseeId = model.AddresseeId.ToEntity(),
                AddresseeName = model.AddresseeName,
                Status = model.Status,
                CreatedOn = model.CreatedOn,
                AcceptedOn = model.AcceptedOn
            };
        }

        public static CircleFriendshipServiceModel ToModel(this CircleFriendship entity)
        {
            return new CircleFriendshipServiceModel
            {
                Id = entity.Id,
                SenderId = entity.SenderId.ToModel(),
                SenderName = entity.SenderName,
                AddresseeId = entity.AddresseeId.ToModel(),
                AddresseeName = entity.AddresseeName,
                Status = entity.Status,
                CreatedOn = entity.CreatedOn,
                AcceptedOn = entity.AcceptedOn
            };
        }
    }
}
