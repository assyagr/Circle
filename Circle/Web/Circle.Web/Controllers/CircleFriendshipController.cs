using Circle.Service.CircleFriendship;
using Microsoft.AspNetCore.Mvc;

namespace Circle.Web.Controllers
{
    public class CircleFriendshipController : Controller
    {
        private readonly ICircleFriendshipService _circleFriendshipService;

        public CircleFriendshipController(ICircleFriendshipService circleFriendshipService)
        {
            _circleFriendshipService = circleFriendshipService;
        }

        // GET: CircleFriendshipController
        public ActionResult Index()
        {
            return View();
        }

        // GET: CircleFriendshipController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CircleFriendshipController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CircleFriendshipController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string circleUser)
        {
            try
            {
                // Assuming the currently logged-in user can be retrieved from User.Identity.Name
                var currentUser = User.Identity?.Name;

                if (string.IsNullOrEmpty(currentUser))
                {
                    // Handle the case where the user is not logged in
                    return Unauthorized();
                }

                // Combine the current user and the input from the view
                var package = $"{currentUser}:{circleUser}";

                // Call the service to create the friendship
                _circleFriendshipService.CreateFriendship(package);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CircleFriendshipController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CircleFriendshipController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CircleFriendshipController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CircleFriendshipController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
