using System.Collections.Generic;
using System.Threading.Tasks;

namespace Circle.Service.Friends
{
    public interface ICircleFriendsService
    {
        Task<FriendshipServiceModel> CreateFriendRequestAsync(FriendshipServiceModel model);
        Task<List<FriendshipServiceModel>> GetAllFriendRequestsAsync(string userId);
        Task<bool> CancelFriendRequestAsync(int requestId, string senderId);
        Task<bool> AcceptFriendRequestAsync(int requestId, string receiverId);
    }
}
