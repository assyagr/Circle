using Circle.Data.Models;

public interface IFriendRequestRepository
{
    Task CreateAsync(FriendRequest entity);
    Task<FriendRequest> GetByIdAsync(int id);
    Task<List<FriendRequest>> GetAllAsync();
    Task DeleteAsync(FriendRequest entity);
}
public interface ICircleUsersRepository
{
    Task<CircleUser> GetByIdAsync(string id);
    Task UpdateAsync(CircleUser user);
}

