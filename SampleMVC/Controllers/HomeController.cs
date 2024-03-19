using Microsoft.AspNetCore.Mvc;

namespace RoamLab.MVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
