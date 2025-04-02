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
        public ActionResult Index() //test page
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
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                string circleUser = collection["circleuser"]; // Get the circleUser value from the form
                _circleFriendshipService.CreateFriendship(circleUser); // Pass the circleUser to the service
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
