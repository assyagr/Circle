using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Circle.Data.Models;
using Circle.Data.Repositories;
using Circle.Service.Friends;
using Circle.Service.Mappings;
using Circle.Service.Models;

namespace Circle.Service.Friends
{
    public class CircleFriendsService : ICircleFriendsService
    {
        private readonly IFriendRequestRepository friendRequestRepository;
        private readonly ICircleUsersRepository circleUsersRepository;

        public CircleFriendsService(
            IFriendRequestRepository friendRequestRepository,
            ICircleUsersRepository circleUsersRepository)
        {
            this.friendRequestRepository = friendRequestRepository;
            this.circleUsersRepository = circleUsersRepository;
        }

        public async Task<FriendshipServiceModel> CreateFriendRequestAsync(FriendshipServiceModel model)
        {
            var requestEntity = model.ToEntity();
            await friendRequestRepository.CreateAsync(requestEntity);
            return requestEntity.ToModel();
        }

        public async Task<List<FriendshipServiceModel>> GetAllFriendRequestsAsync(string userId)
        {
            var allRequests = await friendRequestRepository.GetAllAsync();
            return allRequests
                .Where(r => r.ReceiverId == userId)
                .Select(r => r.ToModel())
                .ToList();
        }

        public async Task<bool> CancelFriendRequestAsync(int requestId, string senderId)
        {
            var request = await friendRequestRepository.GetByIdAsync(requestId);
            if (request == null || request.SenderId != senderId)
                return false;

            await friendRequestRepository.DeleteAsync(request);
            return true;
        }

        public async Task<bool> AcceptFriendRequestAsync(int requestId, string receiverId)
        {
            var request = await friendRequestRepository.GetByIdAsync(requestId);
            if (request == null || request.ReceiverId != receiverId)
                return false;

            var sender = await circleUsersRepository.GetByIdAsync(request.SenderId);
            var receiver = await circleUsersRepository.GetByIdAsync(request.ReceiverId);
            if (sender == null || receiver == null)
                return false;

      
            sender.Friends.Add(receiver);
            receiver.Friends.Add(sender);

     
            await circleUsersRepository.UpdateAsync(sender);
            await circleUsersRepository.UpdateAsync(receiver);

         
            await friendRequestRepository.DeleteAsync(request);

            return true;
        }
    }
}
