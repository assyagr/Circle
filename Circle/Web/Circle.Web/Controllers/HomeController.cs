using System.Diagnostics;
using AspNetCoreGeneratedDocument;
using Circle.Models;
using Circle.Service.Models;
using Circle.Service.Post;
using Circle.Service.Reaction;
using Microsoft.AspNetCore.Mvc;

namespace Circle.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICirclePostService _circlePostService;
        private readonly IReactionService _reactionService;

        public HomeController(ILogger<HomeController> logger, ICirclePostService circlePostService, IReactionService reactionService)
        {
            _logger = logger;
            _circlePostService = circlePostService;
            _reactionService = reactionService;
        }

        public IActionResult Index()
        {
            if(User.Identity.IsAuthenticated == false)
            {
                return View("IndexNotLogged");
            }

            List<CirclePostServiceModel> allPosts = this._circlePostService.GetAll().ToList();
			//List<ReactionServiceModel> allReactions = this._reactionService.GetAll().ToList();
			this.ViewData["Posts"] = allPosts;
			//this.ViewData["Reactions"] = allReactions;

			return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
