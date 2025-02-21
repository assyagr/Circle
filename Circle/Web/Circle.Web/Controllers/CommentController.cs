using Circle.Data.Models;
using Circle.Service.Comment;
using Circle.Service.Models;
using Circle.Service.Post;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;

namespace Circle.Web.Controllers
{
	public class CommentController : Controller
	{
		private readonly ICirclePostService circlePostService;

		private readonly ICommentService commentService;
		public CommentController(ICirclePostService circlePostService, ICommentService commentService)
		{
			this.circlePostService = circlePostService;
			this.commentService = commentService;
		}

		public async Task<IActionResult> Reply(string parentCommentId, string replyText, string postId)
		{
			var result = await this.commentService.CreateReplyOnComment(new CommentServiceModel
			{
				Content = replyText,
				Parent = new CommentServiceModel { Id = parentCommentId}
			}, postId);

			return Redirect("/");
		}
	}
}
