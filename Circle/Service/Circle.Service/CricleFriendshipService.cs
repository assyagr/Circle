using System;
using System.Threading.Tasks;
using Circle.Data.Models;
using Circle.Data.Repositories;

namespace Circle.Service
{
    public class CircleFriendshipService
    {
        private readonly ICircleFriendshipReposiotry _friendshipRepository;

        public CircleFriendshipService(ICircleFriendshipReposiotry friendshipRepository)
        {
            _friendshipRepository = friendshipRepository;
        }

        public async Task<CircleFriendship> SendFriendRequestAsync(Guid senderId, string addresseeUsername)
        {
            return await _friendshipRepository.AddFriendAsync(senderId, addresseeUsername);
        }

        public async Task AcceptFriendRequestAsync(Guid friendshipId)
        {
            await _friendshipRepository.UpdateFriendshipStatusAsync(friendshipId, "Accepted");
        }

        public async Task DenyFriendRequestAsync(Guid friendshipId)
        {
            await _friendshipRepository.UpdateFriendshipStatusAsync(friendshipId, "Discarded");
        }

        public async Task CancelFriendRequestAsync(Guid friendshipId)
        {
            await _friendshipRepository.UpdateFriendshipStatusAsync(friendshipId, "Discarded");
        }
    }
}
