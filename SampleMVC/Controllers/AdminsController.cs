using Microsoft.AspNetCore.Mvc;
using RoamLab.BLL.DTO;
using RoamLab.BLL.Interface;
using RoamLab.DAL.Interface;

namespace RoamLab.MVC.Controllers
{
    public class AdminsController : Controller
    {
        private readonly ILocationBLL _locationBLL;
        private readonly IPlaceBLL _placeBLL;
        private readonly ICategoryBLL _categoryBLL;

        public AdminsController(ILocationBLL locationBLL, IPlaceBLL placeBLL, ICategoryBLL categoryBLL)
        {
            _locationBLL = locationBLL;
            _placeBLL = placeBLL;
            _categoryBLL = categoryBLL;
            //_roleBLL = roleBLL;
        }

        public IActionResult Index()
        {
            var locations = _locationBLL.GetAll();
            var places = _placeBLL.GetAll();

            ViewBag.Locations = locations;
            ViewBag.Places = places;

            return View();
        }

        public IActionResult CreateHotelPlace() 
        { 
            var locations = _locationBLL.GetAll();

            ViewBag.Locations = locations;

            return View();
        }
        [HttpPost]
        public IActionResult CreateHotelPlace(CreateHotelPlaceDTO createHotelPlaceDTO) 
        {
            _placeBLL.InsertPlaceHotel(createHotelPlaceDTO);
            return RedirectToAction("Index");
        }
		public IActionResult CreateRestaurantPlace()
		{
			var locations = _locationBLL.GetAll();

			ViewBag.Locations = locations;

			return View();
		}
        [HttpPost]
        public IActionResult CreateRestaurantPlace(CreateRestaurantPlaceDTO createRestaurantPlaceDTO)
        {
            _placeBLL.InsertPlaceRestaurant(createRestaurantPlaceDTO);
            return RedirectToAction("Index");
        }
		public IActionResult CreateAttractionPlace()
		{
			var locations = _locationBLL.GetAll();

			ViewBag.Locations = locations;

			return View();
		}
        [HttpPost]
        public IActionResult CreateAttractionPlace(CreateAttractionPlaceDTO createAttractionPlaceDTO)
        {
            _placeBLL.InsertPlaceAttraction(createAttractionPlaceDTO);
            return RedirectToAction("Index");
        }
        public IActionResult CreateLocation()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateLocation(LocationDTO locationDTO)
        {
            _locationBLL.Insert(locationDTO);
            return RedirectToAction("Index");
        }
    }
}
