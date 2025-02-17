using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Circle.Data.Models;

namespace Circle.Data.Repositories
{
    public interface ICircleFriendshipReposiotry
    {
        Task<CircleFriendship> AddFriendAsync(Guid senderId, string addresseeUsername);
        Task RemoveFriendAsync(Guid senderId, Guid addresseeId);
        Task<bool> AreFriendsAsync(Guid senderId, Guid addresseeId);
        IQueryable<CircleFriendship> GetAllFriendships();
        Task<CircleFriendship> GetFriendshipByIdAsync(Guid friendshipId);
        Task UpdateFriendshipStatusAsync(Guid friendshipId, string status);
    }
}
