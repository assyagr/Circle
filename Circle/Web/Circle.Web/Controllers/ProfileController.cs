using Circle.Data.Repositories;
using Circle.Service;
using Circle.Service.Models;
using Microsoft.AspNetCore.Mvc;

namespace Circle.Web.Controllers
{
	public class ProfileController : Controller
	{
		private readonly ICircleUserService circleUserService;

		public ProfileController(ICircleUserService circleUserService)
		{
			this.circleUserService = circleUserService;
		}
		public async Task<IActionResult> UserProfile(string UserName)
		{
			List<CircleUserServiceModel> allUsers = this.circleUserService.GetAll().ToList();
			CircleUserServiceModel user = allUsers.SingleOrDefault(u => u.UserName == UserName);

			if (user == null)
			{
				return NotFound("User not found.");
			}

			return View(user);
		}
	}
}
