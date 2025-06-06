﻿using Circle.Data.Migrations;
using Circle.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circle.Data.Repositories
{
    public interface ICircleUserReposiotry
    {
        Task<CircleUser> CreateAsync(CircleUser Userinfo); //Userinfo contains everything right?

		Task<CircleUser> EditAsync(CircleUser user);

		Task<CircleUser> DeleteAsync(CircleUser user);

		IQueryable<CircleUser> GetAll();

		Task Follow(string followerId, string followingId);

		Task Unfollow(string unfollowerId, string followingId);
	}
}
