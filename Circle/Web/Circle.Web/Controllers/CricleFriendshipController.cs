using Circle.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Circle.Data.Models;
using System.Threading.Tasks;
using Circle.Data.Migrations;

namespace Circle.Web.Controllers
{
    public class CircleFriendshipController : Controller
    {
        private readonly CircleFriendshipService _friendshipService;
        private readonly UserManager<CircleUser> _userManager;

        public CircleFriendshipController(CircleFriendshipService friendshipService, UserManager<CircleUser> userManager)
        {
            _friendshipService = friendshipService;
            _userManager = userManager; //to get the logged in person ID?
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateFriendshipRequest(string sentToId)
        {
            //var user = await _userManager.GetUserAsync(User); //get user and Then just the id?

            //await _friendshipService.SendFriendRequestAsync(user.Id, sentToId);
            await _friendshipService.SendFriendRequestAsync(sentToId);
            return RedirectToAction("Index", "Home");
        }



        

        

    }
}