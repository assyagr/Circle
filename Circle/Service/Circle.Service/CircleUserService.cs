using System;
using System.Linq;
using System.Threading.Tasks;
using Circle.Data.Migrations;
using Circle.Data.Models;
using Circle.Data.Repositories;
using Circle.Service.Mappings;
using Circle.Service.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Circle.Service
{
	public class CircleUserService : ICircleUserService
	{
		private readonly CircleUserRepository userRepository;
		//private readonly FriendshipRepository friendshipRepository;

		public CircleUserService(CircleUserRepository userRepository)
		{
			this.userRepository = userRepository;
			//this.friendshipRepository = friendshipRepository;
		}

		public async Task<CircleUserServiceModel> CreateAsync(CircleUserServiceModel model)
		{
			throw new NotImplementedException();
			//CircleUser user = model.ToEntity();
			//await this.userRepository.CreateAsync(user);
			//return user.ToModel();
		}

		public async Task<CircleUserServiceModel> DeleteAsync(string id)
		{
			throw new NotImplementedException();
			//CircleUser user = await this.userRepository.GetAll().SingleOrDefaultAsync(u => u.Id.ToString() == id);
			//if (user == null) throw new NullReferenceException($"No user found with id - {id}.");
			//await this.userRepository.DeleteAsync(user);
			//return user.ToModel();
		}

		public IQueryable<CircleUserServiceModel> GetAll()
		{
			//throw new NotImplementedException();
			return userRepository.GetAll().Select(user => user.ToModel());
			//	.Include(u => u.Friends)
			//	.Select(u => u.ToModel());
		}

		public async Task<CircleUserServiceModel> GetByIdAsync(string id)
		{
			throw new NotImplementedException();
			//return (await this.userRepository.GetAll()
			//	.Include(u => u.Friends)
			//	.SingleOrDefaultAsync(u => u.Id.ToString() == id))?.ToModel();
		}

		public async Task<CircleUserServiceModel> UpdateAsync(string id, CircleUserServiceModel model)
		{
			throw new NotImplementedException();
			//User user = await this.userRepository.GetAll().SingleOrDefaultAsync(u => u.Id.ToString() == id);
			//if (user == null) throw new NullReferenceException($"No user found with id - {id}.");
			//user.UserName = model.UserName;
			//user.Email = model.Email;
			//await this.userRepository.UpdateAsync(user);
			//return user.ToModel();
		}

		public async Task<CircleUserServiceModel> GetUserByEmailAsync(string email)
		{
			throw new NotImplementedException();
			//User user = await this.userRepository.GetAll().SingleOrDefaultAsync(u => u.Email == email);
			//return user?.ToModel();
		}

		public async Task AddFriendAsync(Guid userId, Guid friendId)
		{
			throw new NotImplementedException();
			//await this.friendshipRepository.AddFriendAsync(userId, friendId);
		}

		public async Task RemoveFriendAsync(Guid userId, Guid friendId)
		{
			throw new NotImplementedException();
			//await this.friendshipRepository.RemoveFriendAsync(userId, friendId);
		}
	}
}
