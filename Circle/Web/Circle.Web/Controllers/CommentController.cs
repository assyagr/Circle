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
	}
}
