﻿using Circle.Data.Migrations;
using Circle.Data.Models;
using Circle.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circle.Service.Mappings
{
	public static class CircleUserMappings
	{
		public static CircleUser ToEntity(this CircleUserServiceModel model)
		{
			return new CircleUser();
		}

		public static CircleUserServiceModel ToModel(this CircleUser entity)
		{
			if(entity == null)
			{
				return new CircleUserServiceModel();
			}

			return new CircleUserServiceModel
			{
				Email = entity.Email,
				//DisplayName = entity.DisplayName,
				Id = entity.Id,
				UserName = entity.UserName,
				Bio = entity.Bio,
				Posts = (List<CirclePostServiceModel>)entity.Posts?.Select(p => p.ToModel()),
				Friends = entity.Friends?.Select(f => new CircleUserServiceModel { UserName = f.UserName}).ToList(),
				Followers = entity.Followers?.Select(f => new CircleUserServiceModel { UserName = f.UserName }).ToList(),
				Following = entity.Following?.Select(f => new CircleUserServiceModel { UserName = f.UserName }).ToList()
			};
		}
	}
}
