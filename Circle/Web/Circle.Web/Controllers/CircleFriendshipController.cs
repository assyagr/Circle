using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Circle.Service;

namespace Circle.Web.Controllers
{
    public class FriendshipController : Controller
    {
        private readonly CricleFriendshipService _friendshipService;

        public FriendshipController(CricleFriendshipService friendshipService)
        {
            _friendshipService = friendshipService;
        }

        [HttpGet]
        public IActionResult SendRequest()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendRequest(string addresseeUsername)
        {
            if (string.IsNullOrEmpty(addresseeUsername))
            {
                ModelState.AddModelError(string.Empty, "Addressee Username cannot be empty.");
                return View();
            }

            var senderId = "currentUserId"; // Replace with the actual current user ID
            await _friendshipService.CreateRequestAsync(senderId, addresseeUsername);

            return RedirectToAction("Index", "Home");
        }
    }
}