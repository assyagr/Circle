using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Circle.Data.Models;
using Circle.Data.Repositories;

namespace Circle.Service.CircleFriendship
{
    public class CircleFriendshipService
    {
        private readonly ICircleFriendshipReposiotry _circleFriendshipRepository;

        public CircleFriendshipService(ICircleFriendshipReposiotry circleFriendshipRepository)
        {
            _circleFriendshipRepository = circleFriendshipRepository;
        }

        public void CreateFriendship(string circleUser)
        {
            var friendship = new Data.Models.CircleFriendship //gives error if just new cf
            {
                CreatedById = "currentUserId", // Replace with actual current user ID somehow
                SentToId = circleUser,
                Status = "Pending",
                DateTime = DateTime.UtcNow
            };

            _circleFriendshipRepository.Add(friendship);
        }
    }
}
