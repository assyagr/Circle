using Circle.Service.Models;
using Circle.Web.Models.Post;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Linq;
using Circle.Service.Cloudinary;
using Circle.Service.Post;
using Circle.Service;
using Circle.Data.Migrations;

namespace Circle.Web.Controllers
{
	public class PostController : Controller
	{
		private readonly ICirclePostService circlePostService;

		private readonly ICircleUserService circleUserService;

		private readonly ICloudinaryService cloudinaryService;

		public PostController(ICirclePostService circlePostService, ICircleUserService circleUserService, ICloudinaryService cloudinaryService)
		{
			this.circlePostService = circlePostService;
			this.circleUserService = circleUserService;
			this.cloudinaryService = cloudinaryService;
		}

		[HttpGet]
		public async Task<IActionResult> Create()
		{
			this.ViewData["Users"] = this.circleUserService.GetAll().Select(user => user.UserName).ToList();

			return View();
		}

		[HttpPost]
		public async Task<IActionResult> CreateConfirm(CreatePostModel createPostModel)
		{
			List<AttachmentServiceModel> photos = new List<AttachmentServiceModel>();

			foreach (var photo in createPostModel.Content)
			{
				photos.Add(new AttachmentServiceModel { CloudUrl = await this.UploadPhoto(photo) });
			}

			//List<string> taggedUsersUsernames = createPostModel.TaggedUsers?.Split(',').ToList();
			List<CircleUserServiceModel> taggedUsers = new List<CircleUserServiceModel>();

			foreach (var taggedUser in createPostModel.TaggedUsers) 
			{
				//Doesnt trasnlate Linq so had to do it with foreach
				CircleUserServiceModel user = null;

				foreach (var u in this.circleUserService.GetAll())
				{
					if (u.UserName == taggedUser)
					{
						user = u;
						break;
					}
				}

				if (user != null)
				{
					taggedUsers.Add(user);
				}
			}

			//List<string> hashtagLabels = createPostModel.Hashtags?.Split(',').ToList();

			await this.circlePostService.CreateAsync(new CirclePostServiceModel
			{
				Caption = createPostModel.Caption,
				TaggedUsers = taggedUsers,
				Hashtags = createPostModel.Hashtags?.Select(hashtag => new HashtagServiceModel { Label = hashtag }).ToList(),
				//Hashtags = hashtagLabels?.Select(hashtag => new HashtagServiceModel { Label = hashtag }).ToList(),
				Content = photos
			});

			return Redirect("/");
		}
		
		private async Task<string> UploadPhoto(IFormFile photo)
		{
			var uploadResponse = await this.cloudinaryService.UploadFile(photo);

			if (uploadResponse == null)
			{
				return null;
			}
		
			return uploadResponse["url"].ToString();
		}
	}
}
