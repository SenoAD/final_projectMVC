using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using RoamLab.BLL;
using RoamLab.BLL.DTO;
using RoamLab.BLL.Interface;
using RoamLab.DAL.Interface;

namespace RoamLab.MVC.Controllers
{
    public class VacationsController : Controller
    {
        private readonly IVacationPlanBLL _vacationPlan;
        private readonly IPlaceBLL _place;
        public VacationsController(IVacationPlanBLL vacationPlanBLL, IPlaceBLL placeBLL)
        {
            _vacationPlan = vacationPlanBLL;
            _place = placeBLL;
        }
        public IActionResult Index()
        {
            var userJson = HttpContext.Session.GetString("user");
            bool isLoggedIn = userJson != null;

            if (isLoggedIn)
            {
                userJson = HttpContext.Session.GetString("user");
                var userDto = JsonSerializer.Deserialize<LoginUserDTO>(userJson);

                var vacationPlan = _vacationPlan.GetVacationPlanByUserID(userDto.UserID);
                return View(vacationPlan);
            }
            
            return RedirectToAction("Login","Users");
        }

        public IActionResult CreateVacationPlan()
        {
            var userJson = HttpContext.Session.GetString("user");
            bool isLoggedIn = userJson != null;

            if (isLoggedIn)
            {
                userJson = HttpContext.Session.GetString("user");
                var userDto = JsonSerializer.Deserialize<LoginUserDTO>(userJson);
                ViewBag.UserDTO = userDto;
                var placeList = _place.GetAllwithLocationID();
                if (string.IsNullOrEmpty(HttpContext.Session.GetString("PlaceCart")))
                {
                    var cartItems = new List<PlaceDTO>();
                    var cartSerialize = JsonSerializer.Serialize(cartItems);
                    HttpContext.Session.SetString("PlaceCart", cartSerialize);
                }
                if (string.IsNullOrEmpty(HttpContext.Session.GetString("PlanItems")))
                {
                    var planItems = new List<InsertPlanItemDTO>();
                    var planItemsSerialize = JsonSerializer.Serialize(planItems);
                    HttpContext.Session.SetString("PlanItems", planItemsSerialize);
                }
                return View(placeList);
            }

            return RedirectToAction("Login", "Users");
        }

        [HttpPost]
        public IActionResult SaveVacationPlan(string Name, string Description)
        {
            var planItemsSerialize = HttpContext.Session.GetString("PlanItems");
            var planItems = JsonSerializer.Deserialize<List<InsertPlanItemDTO>>(planItemsSerialize);
            var userJson = HttpContext.Session.GetString("user");
            var userDto = JsonSerializer.Deserialize<LoginUserDTO>(userJson);

            var VacationPlan = new InsertVacationPlanDTO
            {
                UserID = userDto.UserID,
                Name = Name,
                Description = Description,
                PlanItems = planItems
            };

            _vacationPlan.Insert(VacationPlan);
            HttpContext.Session.Remove("PlanItems");
            HttpContext.Session.Remove("PlaceCart");
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult AddToCart(int PlaceID, string DatePlace)
        {
            var planItem = new InsertPlanItemDTO 
            { 
                DatePlace = DatePlace,
                PlaceID = PlaceID,
            };
            var planItemsSerialize = HttpContext.Session.GetString("PlanItems");
            var planItems = JsonSerializer.Deserialize<List<InsertPlanItemDTO>>(planItemsSerialize);

            var place = _place.GetPlaceByID(PlaceID);
            var cartSerialize = HttpContext.Session.GetString("PlaceCart");
            var cartItems = JsonSerializer.Deserialize<List<PlaceDTO>>(cartSerialize);

            cartItems.Add(place);
            planItems.Add(planItem);

            var cartSerialize2 = JsonSerializer.Serialize(cartItems);
            var planItemsSerialize2 = JsonSerializer.Serialize(planItems);

            HttpContext.Session.SetString("PlaceCart", cartSerialize2);
            HttpContext.Session.SetString("PlanItems", planItemsSerialize2);
            return RedirectToAction("CreateVacationPlan");
        }

        public IActionResult EditVacationPlan(int PlanID)
        {
           var EditVacationPlanData = _vacationPlan.GetVacationPlanAndPlanItemByPlanID(PlanID);
            return View(EditVacationPlanData);
        }

    }
}
