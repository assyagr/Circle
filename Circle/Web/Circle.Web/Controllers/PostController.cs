using Circle.Service.Models;
using Circle.Service.Post;
using Circle.Web.Models.Post;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Linq;

namespace Circle.Web.Controllers
{
	public class PostController : Controller
	{
		private readonly ICirclePostService circlePostService;

		//private readonly ICloudinaryService cloudinaryService;

		public PostController(ICirclePostService circlePostService)
		{
			this.circlePostService = circlePostService;
		}

		[HttpGet]
		public IActionResult Create()
		{
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

			await this.circlePostService.CreateAsync(new CirclePostServiceModel
			{
				Caption = createPostModel.Caption,
				//todo tagged and flags
				//TaggedUsers = createPostModel.TaggedUsers,
				Content = photos
			});

			return Redirect("/");
		}
		
		private async Task<string> UploadPhoto(IFormFile photo)
		{
			//var uploadResponse = await this.cloudinaryService.UploadFile(photo);

			//if (uploadResponse == null)
			//{
				return null;
			//}
		
			//return uploadResponse["url"].ToString();
		}
	}
}
