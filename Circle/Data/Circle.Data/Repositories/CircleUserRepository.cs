using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Circle.Data.Migrations;
using Circle.Data.Models;
using Circle.Service.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Circle.Data.Repositories
{



    public class CircleUserRepository : ICircleUserReposiotry //I should just inherit the base repo but
        // i get error that i dont have Circle.Data.Model.Cricle conversion to Cricle.Data.Model.BaseE
    {
        protected readonly CircleDbContext _dbContext;

        public CircleUserRepository(CircleDbContext dbContext) //inject db 
        {
            this._dbContext = dbContext;
        }

        public async Task<CircleUser> CreateAsync(CircleUser user)
        {
            await this._dbContext.AddAsync(user);
            await this._dbContext.SaveChangesAsync(); 
            return user;
        }

		public async Task<CircleUser> EditAsync(CircleUser user)
		{
			this._dbContext.Update(user);
			await this._dbContext.SaveChangesAsync();
			return user;
		}

		public async Task<CircleUser> DeleteAsync(CircleUser user)
		{
			throw new NotImplementedException();
		}

		public IQueryable<CircleUser> GetAll()
		{
            return this._dbContext.Users;
		}

        public async Task Follow(string followerId, string followingId)
        {
			CircleUser follower = _dbContext.Users
				.Include(u => u.Following)
				.FirstOrDefault(u => u.Id == followerId);

			CircleUser following = _dbContext.Users
				.Include(u => u.Followers)
				.FirstOrDefault(u => u.Id == followingId);

			follower.Following.Add(following);
			following.Followers.Add(follower);

			await this._dbContext.SaveChangesAsync();
		}

		public async Task Unfollow(string unfollowerId, string followingId)
		{
			CircleUser unfollower = _dbContext.Users
				.Include(u => u.Following)
				.FirstOrDefault(u => u.Id == unfollowerId);

			CircleUser following = _dbContext.Users
				.Include(u => u.Followers)
				.FirstOrDefault(u => u.Id == followingId);

			unfollower.Following.Remove(following);
			following.Followers.Remove(unfollower);

			await this._dbContext.SaveChangesAsync();
		}
	}
}
