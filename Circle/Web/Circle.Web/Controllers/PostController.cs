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

			//doesnt recognize the array properly, puts all the values as one, even though it returns a list
			List<string> allTaggedUsers = new List<string>();
			
			//always one element in list
			foreach (var taggedUsers in createPostModel.TaggedUsers)
			{
				if (taggedUsers != null)
				{
					allTaggedUsers = taggedUsers.Split(',').ToList();
				}
				else { allTaggedUsers = null; }
			}

			//doesnt recognize the array properly, puts all the values as one, even though it returns a list
			List<string> allHashtags = new List<string>();

			//always one element in list
			foreach (var hashtags in createPostModel.Hashtags)
			{
				if (hashtags != null)
				{
					allHashtags = hashtags.Split(',').ToList();
				}
				else { allHashtags = null; }
			}

			await this.circlePostService.CreateAsync(new CirclePostServiceModel
			{
				Caption = createPostModel.Caption,
				Content = photos,
				TaggedUsers = allTaggedUsers?.Select(username => new CircleUserServiceModel { UserName = username }).ToList(),
				Hashtags = allHashtags?.Select(hashtag => new HashtagServiceModel { Label = hashtag }).ToList()
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
