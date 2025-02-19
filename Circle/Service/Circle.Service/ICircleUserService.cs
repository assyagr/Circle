using System;
using System.Linq;
using System.Threading.Tasks;
using Circle.Data.Migrations;
using Circle.Data.Models;
using Circle.Service.Models;

namespace Circle.Service
{
	public interface ICircleUserService
	{
		Task<CircleUserServiceModel> CreateAsync(CircleUserServiceModel model);
		Task<CircleUserServiceModel> DeleteAsync(string id);
		IQueryable<CircleUserServiceModel> GetAll();
		Task<CircleUserServiceModel> GetByIdAsync(string id);
		Task<CircleUserServiceModel> UpdateAsync(string id, CircleUserServiceModel model);
		Task<CircleUserServiceModel> GetUserByEmailAsync(string email);
		Task<CircleUser> GetCurrentUserAsync();

		Task<CircleUser> GetUserByUserName(string username);
		Task AddFriendAsync(Guid userId, Guid friendId);
		Task RemoveFriendAsync(Guid userId, Guid friendId);
	}
}