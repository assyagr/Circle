using Circle.Data.Models;

public interface IFriendRequestRepository
{
    Task CreateAsync(FriendRequest entity);
    Task<FriendRequest> GetByIdAsync(string id);
    Task<List<FriendRequest>> GetAllAsync();
    Task DeleteAsync(FriendRequest entity);
    Task CreateAsync(Circle.Data.Repositories.FriendRequest requestEntity);
   
}
public interface ICircleUsersRepository
{
    Task<CircleUser> GetByIdAsync(string id);
    Task UpdateAsync(CircleUser user);
}

