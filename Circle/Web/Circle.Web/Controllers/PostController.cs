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

			//doesnt recognize the array properly, puts all the values as one, even though it returns a list


			//1.srawnqwam ws tagowe ot postModel w editpostmodel
			//2.ako ima nqkoi koito go nqma w editpostmodel trqbwa da go mahna ot entityto
			//3.ako ima nqkoi koito go ima w editpostmodel, no ne w entity trqbwa da se dobawi w entity
			//4.ako ima hashtag w editpostmodel koito ne sushtestwuwa w bazata

			List<string> allTaggedUsers = new List<string>();
			//always one element in list
			foreach (var taggedUsers in editPostModel.TaggedUsers)
			{
				if (taggedUsers != null)
				{
					allTaggedUsers = taggedUsers.Split(',').ToList();
				}
			}

			//doesnt recognize the array properly, puts all the values as one, even though it returns a list
			List<string> allHashtags = new List<string>();

			//always one element in list
			foreach (var hashtags in editPostModel.Hashtags)
			{
				if (hashtags != null)
				{
					allHashtags = hashtags.Split(',').ToList();
				}
			}

			await this.circlePostService.EditAsync(postModel, allTaggedUsers, allHashtags);

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

			return Ok(result);
		}
	}
}
