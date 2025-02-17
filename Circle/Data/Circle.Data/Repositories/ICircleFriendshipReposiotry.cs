using System.Threading.Tasks;

namespace Circle.Data.Repositories
{
    public interface ICircleFriendshipReposiotry
    {
        Task CreateRequest(string senderId, string addresseeUsername);
    }
}
