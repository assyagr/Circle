using System;
using System.Linq;
using System.Threading.Tasks;
using Circle.Data.Migrations;
using Circle.Service.Models;

namespace Circle.Service
{
	public interface IUserService
	{
		Task<UserServiceModel> CreateAsync(UserServiceModel model);
		Task<UserServiceModel> DeleteAsync(string id);
		IQueryable<UserServiceModel> GetAll();
		Task<UserServiceModel> GetByIdAsync(string id);
		Task<UserServiceModel> UpdateAsync(string id, UserServiceModel model);
		Task<UserServiceModel> GetUserByEmailAsync(string email);
		Task AddFriendAsync(Guid userId, Guid friendId);
		Task RemoveFriendAsync(Guid userId, Guid friendId);
	}
}