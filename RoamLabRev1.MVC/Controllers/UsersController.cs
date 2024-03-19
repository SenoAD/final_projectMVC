using Microsoft.AspNetCore.Mvc;

namespace RoamLabRev1.MVC.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
    }
}
