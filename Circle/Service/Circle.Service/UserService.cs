using System;
using System.Linq;
using System.Threading.Tasks;
using Circle.Data.Migrations;
using Circle.Data.Models;
using Circle.Data.Repositories;
using Circle.Service.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Circle.Service
{
	public class UserService : IUserService
	{
		private readonly UserRepository userRepository;
		private readonly CircleFriendshipRepository friendshipRepository;

		public UserService(UserRepository userRepository, CircleFriendshipRepository friendshipRepository)
		{
			this.userRepository = userRepository;
			this.friendshipRepository = friendshipRepository;
		}

		public async Task<UserServiceModel> CreateAsync(UserServiceModel model)
		{
			User user = model.ToEntity();
			await this.userRepository.CreateAsync(user);
			return user.ToModel();
		}

		public async Task<UserServiceModel> DeleteAsync(string id)
		{
			User user = await this.userRepository.GetAll().SingleOrDefaultAsync(u => u.Id.ToString() == id);
			if (user == null) throw new NullReferenceException($"No user found with id - {id}.");
			await this.userRepository.DeleteAsync(user);
			return user.ToModel();
		}

		public IQueryable<UserServiceModel> GetAll()
		{
			return this.userRepository.GetAll()
				.Include(u => u.Friends)
				.Select(u => u.ToModel());
		}

		public async Task<UserServiceModel> GetByIdAsync(string id)
		{
			return (await this.userRepository.GetAll()
				.Include(u => u.Friends)
				.SingleOrDefaultAsync(u => u.Id.ToString() == id))?.ToModel();
		}

		public async Task<UserServiceModel> UpdateAsync(string id, UserServiceModel model)
		{
			User user = await this.userRepository.GetAll().SingleOrDefaultAsync(u => u.Id.ToString() == id);
			if (user == null) throw new NullReferenceException($"No user found with id - {id}.");
			user.Name = model.Name;
			user.Email = model.Email;
			await this.userRepository.UpdateAsync(user);
			return user.ToModel();
		}

		public async Task<UserServiceModel> GetUserByEmailAsync(string email)
		{
			User user = await this.userRepository.GetAll().SingleOrDefaultAsync(u => u.Email == email);
			return user?.ToModel();
		}

		public async Task AddFriendAsync(Guid userId, Guid friendId)
		{
			await this.friendshipRepository.AddFriendAsync(userId, friendId);
		}

		public async Task RemoveFriendAsync(Guid userId, Guid friendId)
		{
			await this.friendshipRepository.RemoveFriendAsync(userId, friendId);
		}
	}
}