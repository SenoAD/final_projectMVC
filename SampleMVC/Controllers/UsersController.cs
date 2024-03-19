using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using RoamLab.BLL.DTO;
using RoamLab.BLL.Interface;

namespace SampleMVC.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserBLL _userBLL;
        //private readonly IRoleBLL _roleBLL;

        public UsersController(IUserBLL userBLL) 
        { 
            _userBLL = userBLL;
            //_roleBLL = roleBLL;
        }
        public IActionResult Index()
        {
			if (TempData["Message"] != null)
			{
				ViewBag.Message = TempData["Message"];
			}

			//var users = _userBLL.GetAll();
			//var listUsers = new SelectList(users, "Username", "Username");
			//ViewBag.Users = listUsers;

			//var roles = _roleBLL.GetAllRoles();
			//var listRoles = new SelectList(roles, "RoleID", "RoleName");
			//ViewBag.Roles = listRoles;

			//var usersWithRoles = _userBLL.GetAllWithRoles();
			return View();
		}

        public IActionResult Login() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                var userdto = _userBLL.Login(username,password);
                var userDtoSerialize = JsonSerializer.Serialize(userdto);
                HttpContext.Session.SetString("user", userDtoSerialize);
                ViewBag.Message = @"<div class='alert alert-success'><strong>Success!&nbsp;</strong>Registration process successfully !</div>";
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                ViewBag.Message = @"<div class='alert alert-danger'><strong>Error!&nbsp;</strong>" + ex.Message + "</div>";
            }

            return View();

        }
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("user");
            return RedirectToAction("Login");
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(UserCreateDTO userCreateDTO)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            _userBLL.Insert(userCreateDTO);
            return RedirectToAction("Login");
        }

    }
}
