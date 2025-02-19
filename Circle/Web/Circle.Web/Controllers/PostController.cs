using Circle.Service.Models;
using Circle.Web.Models.Post;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Linq;
using Circle.Service.Cloudinary;
using Circle.Service.Post;
using Circle.Service;
using Circle.Data.Migrations;
using System.Threading;
using Circle.Service.Hashtag;
using Circle.Data.Models;
using Circle.Service.Comment;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Circle.Web.Controllers
{
	public class PostController : Controller
	{
		private readonly ICirclePostService circlePostService;

		private readonly ICircleUserService circleUserService;

		private readonly ICloudinaryService cloudinaryService;

		private readonly IHashtagService hashtagService;

		private readonly ICommentService commentService;

		public PostController(ICirclePostService circlePostService, ICircleUserService circleUserService, ICloudinaryService cloudinaryService, IHashtagService hashtagService)
		{
			this.circlePostService = circlePostService;
			this.circleUserService = circleUserService;
			this.cloudinaryService = cloudinaryService;
			this.hashtagService = hashtagService;
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
			// TODO: trqbwa da ne mozhe da se kachwa bez snimka
			List<AttachmentServiceModel> photos = new List<AttachmentServiceModel>();

			foreach (var photo in createPostModel.Content)
			{
				photos.Add(new AttachmentServiceModel { CloudUrl = await this.UploadPhoto(photo) });
			}

			await this.circlePostService.CreateAsync(new CirclePostServiceModel
			{
				Caption = createPostModel.Caption,
				Content = photos,
				TaggedUsers = createPostModel.TaggedUsers?.Select(username => new CircleUserServiceModel { UserName = username }).ToList(),
				Hashtags = createPostModel.Hashtags?.Select(hashtag => new HashtagServiceModel { Label = hashtag }).ToList()
			});

			return Redirect("/");
		}

		public async Task<IActionResult> Details(string postId)
		{
			CirclePostServiceModel post = await this.circlePostService.GetByIdAsync(postId);
			List<CommentServiceModel> comments = post.Comments.Select(upc => upc.Comment).ToList();
			this.ViewData["Comments"] = comments;

			if (post == null)
			{
				return NotFound("Post not found.");
			}

			return View(post);
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

		[HttpPost]
		public async Task<IActionResult> Edit(string postId)
		{
			this.ViewData["Users"] = this.circleUserService.GetAll().Select(user => user.UserName).ToList();

			CirclePostServiceModel postModel = await circlePostService.GetByIdAsync(postId);

			CreatePostModel createPostModel = new CreatePostModel
			{
				Id = postModel.Id,
				Caption = postModel.Caption,
				TaggedUsers = postModel.TaggedUsers.Select(user => user.UserName).ToList(),
				Hashtags = postModel.Hashtags.Select(hashtag => hashtag.Label).ToList()
			};
			return View(createPostModel);
		}

		[HttpPost]
		public async Task<IActionResult> EditConfirm(CreatePostModel editPostModel)
		{
			CirclePostServiceModel postModel = await circlePostService.GetByIdAsync(editPostModel.Id);

			postModel.Caption = editPostModel.Caption;
			await this.circlePostService.EditAsync(postModel, editPostModel.TaggedUsers, editPostModel.Hashtags);

			return Redirect("/");
		}

		[HttpPost]
		public async Task<IActionResult> Delete(string postId)
		{
			await circlePostService.DeleteAsync(postId);

			return Redirect("/");
		}

		public async Task<IActionResult> Comment(string postId, string commentText, string? parentId = null)
		{
			var result = await this.circlePostService.CreateCommentOnPost(new CommentServiceModel
			{
				Content = commentText
			}, postId, parentId);

			return Redirect("/");
		}
	}
}
