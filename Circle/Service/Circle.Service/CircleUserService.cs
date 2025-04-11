using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Circle.Data.Migrations;
using Circle.Data.Models;
using Circle.Data.Repositories;
using Circle.Service.Mappings;
using Circle.Service.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Circle.Service
{
	public class CircleUserService : ICircleUserService
	{
		private readonly CircleUserRepository userRepository;

		private readonly IHttpContextAccessor _httpContextAccessor;

		private readonly IUserStore<CircleUser> _userStore;
		//private readonly FriendshipRepository friendshipRepository;

		public CircleUserService(CircleUserRepository userRepository, IHttpContextAccessor httpContextAccessor, IUserStore<CircleUser> userStore)
		{
			this.userRepository = userRepository;
			this._httpContextAccessor = httpContextAccessor;
			this._userStore = userStore;
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
			return userRepository.GetAll()
				.Include(u => u.Following)
				//Include friends is giving an error????????????????????????????????????????????????????
				.Include(u => u.Followers)
				.Select(user => user.ToModel());
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
		public async Task<CircleUser> GetCurrentUserAsync()
		{
			string? userId = this._httpContextAccessor?.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

			return await this._userStore.FindByIdAsync(userId, CancellationToken.None);
		}

		public async Task<CircleUser> GetUserByUserName(string username)
		{
			return await this._userStore.FindByNameAsync(username.ToUpper(), CancellationToken.None);
		}

		public async Task<CircleUserServiceModel> EditAsync(CircleUserServiceModel model)
		{
			CircleUser user = await GetUserByUserName(model.UserName);
			user.Bio = model.Bio;

			userRepository.EditAsync(user);
			return user.ToModel();
		}

		public List<CircleUserServiceModel> SearchUser(string searchString)
		{
			List<CircleUser> allUsers = userRepository.GetAll().ToList();
			List<CircleUser> foundUserEntities = allUsers?.Where(u =>
				u.UserName.Contains(searchString, StringComparison.OrdinalIgnoreCase)).ToList();
			List<CircleUserServiceModel> foundUserModels = foundUserEntities?.Select(u => u.ToModel()).ToList();
			return foundUserModels;
		}

		public async Task Follow(string following)
		{
			CircleUser followerUser = await GetCurrentUserAsync();
			CircleUser followingUser = await GetUserByUserName(following);
			userRepository.Follow(followerUser.Id, followingUser.Id);
		}

		public async Task Unfollow(string following)
		{
			CircleUser unfollowerUser = await GetCurrentUserAsync();
			CircleUser followingUser = await GetUserByUserName(following);
			userRepository.Unfollow(unfollowerUser.Id, followingUser.Id);
		}
	}
}
