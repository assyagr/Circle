using System;
using System.Threading.Tasks;
using Circle.Data.Repositories;
using Circle.Service.Models;

namespace Circle.Service
{
    public class CricleFriendshipService
    {
        private readonly ICircleFriendshipReposiotry _friendshipRepository;

        public CricleFriendshipService(ICircleFriendshipReposiotry friendshipRepository)
        {
            _friendshipRepository = friendshipRepository;
        }

        public async Task CreateRequestAsync(string senderId, string addresseeUsername)
        {
            // Validate input parameters
            if (string.IsNullOrEmpty(senderId) || string.IsNullOrEmpty(addresseeUsername))
            {
                throw new ArgumentException("Sender ID and Addressee Username cannot be null or empty.");
            }

            // Create the friend request using the repository
            await _friendshipRepository.CreateRequest(senderId, addresseeUsername);
        }
    }
}