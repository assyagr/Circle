using Circle.Data.Models;
using Circle.Service.Friends;
using Circle.Service.Models;

namespace Circle.Service.Mappings
{
    public static class FriendshipMappings
    {
        public static FriendRequest? ToEntity(this FriendshipServiceModel model)
        {
            if (model == null)
                return null;

            return new FriendRequest
            {
                Id = model.Id,
                SenderId = int.Parse(model.SenderId),  
                ReceiverId = int.Parse(model.ReceiverId) 
            };
        }

        public static FriendshipServiceModel? ToModel(this FriendRequest entity)
        {
            if (entity == null)
                return null;

            return new FriendshipServiceModel
            {
                Id = entity.Id,
                SenderId = entity.SenderId.ToString(), 
                ReceiverId = entity.ReceiverId.ToString() 
            };
        }
    }
}
