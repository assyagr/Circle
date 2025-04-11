using Circle.Data.Repositories;
using Circle.Service;
using Circle.Service.Cloudinary;
using Circle.Service.Comment;
using Circle.Service.Mappings;
using Circle.Service.Models;
using Circle.Service.Post;
using Circle.Web.Models.User;
using Microsoft.AspNetCore.Mvc;

namespace Circle.Web.Controllers
{
	public class ProfileController : Controller
	{
		private readonly ICircleUserService circleUserService;
		private readonly ICirclePostService circlePostService;
		private readonly ICloudinaryService cloudinaryService;

		public ProfileController(ICircleUserService circleUserService, ICirclePostService circlePostService, ICloudinaryService cloudinaryService)
		{
			this.circleUserService = circleUserService;
			this.circlePostService = circlePostService;
			this.cloudinaryService = cloudinaryService;
		}
		public async Task<IActionResult> UserProfile(string UserName)
		{
			List<CircleUserServiceModel> allUsers = this.circleUserService.GetAll().ToList();
			CircleUserServiceModel user = allUsers.SingleOrDefault(u => u.UserName == UserName);

			List<CirclePostServiceModel> allPosts = this.circlePostService.GetAll().ToList();
			List<CirclePostServiceModel> posts = allPosts.Where(p => p.CreatedBy.UserName == UserName).ToList();
			
			this.ViewData["Posts"] = posts;

			if (user == null)
			{
				return NotFound("User not found.");
			}

			return View(user);
		}

		public async Task<IActionResult> EditProfile(string UserName)
		{
			List<CircleUserServiceModel> allUsers = this.circleUserService.GetAll().ToList();
			CircleUserServiceModel user = allUsers.SingleOrDefault(u => u.UserName == UserName);
			EditUserModel model = new EditUserModel
			{
				Id = user.Id,
				UserName = user.UserName,
				Bio = user.Bio
			};
			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> EditConfirm(EditUserModel user)
		{
			CircleUserServiceModel userServiceModel = (await this.circleUserService.GetUserByUserName(user.UserName)).ToModel();

			userServiceModel.Bio = user.Bio;

			await this.circleUserService.EditAsync(userServiceModel);

			return Redirect($"/Profile/UserProfile?UserName={userServiceModel.UserName}");
		}

		public IActionResult SearchUser(string searchString)
		{
			if (searchString == "" || searchString == null)
			{
				return Redirect("/");
			}


			List<CircleUserServiceModel> foundUsers = circleUserService.SearchUser(searchString);
			this.ViewData["FoundUsers"] = foundUsers;
			this.ViewData["SearchText"] = searchString;

			return View();
		}

		public async Task<IActionResult> Follow(string following)
		{
			await circleUserService.Follow(following);
			return Redirect($"/Profile/UserProfile?UserName={following}");
		}

		public async Task<IActionResult> Unfollow(string following)
		{
			await circleUserService.Unfollow(following);
			return Redirect($"/Profile/UserProfile?UserName={following}");
		}
	}
}
