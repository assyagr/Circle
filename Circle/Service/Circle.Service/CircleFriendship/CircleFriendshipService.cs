using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Circle.Data.Models;
using Circle.Data.Repositories;

namespace Circle.Service.CircleFriendship
{
    public class CircleFriendshipService : ICircleFriendshipService
    {
        private readonly ICircleFriendshipReposiotry _circleFriendshipRepository;

        public CircleFriendshipService(ICircleFriendshipReposiotry circleFriendshipRepository)
        {
            _circleFriendshipRepository = circleFriendshipRepository;
        }

        public void CreateFriendship(string package)
        {
            // Split the package into the current user and the circle user
            var parts = package.Split(':');

            var currentUserId = parts[0];
            var circleUserId = parts[1];

            // Create a new CircleFriendship object
            var friendship = new Circle.Data.Models.CircleFriendship
            {
                CreatedById = currentUserId,
                SentToId = circleUserId,
                Status = "Pending", // Default status
                DateTime = DateTime.UtcNow // Set the current UTC time
            };

            // Add the friendship to the repository
            _circleFriendshipRepository.Add(friendship);
        }
    }
}
