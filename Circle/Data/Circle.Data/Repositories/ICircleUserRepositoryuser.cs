
using System.Threading.Tasks;
using Circle.Data.Models;

namespace Circle.Data.Repositories
{
    public interface ICircleUsersRepository
    {
        Task<CircleUser> GetByIdAsync(string id);
        Task UpdateAsync(CircleUser user);
    }
}
