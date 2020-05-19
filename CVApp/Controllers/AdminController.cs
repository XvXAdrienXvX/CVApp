using BL;
using BL.Interfaces;
using BL.Models;
using CVApp.Models;
using CVApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace MyCV.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminBL _adminBL;
        private readonly ConvertToViewModel _model;

        public AdminController()
        {
            _adminBL = new AdminBl();
            _model = new ConvertToViewModel();
        }

        public ActionResult Admin()
        {
            var data = _adminBL.GetUsers();
            var ViewModel = _model.convertToUserList(data);

            return View(ViewModel);
        }
      
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddUser(UserViewModel model)
        {
            Users user = new Users
            {
                Username = model.username,
                password = model.Password,
                Email = model.Email

            };

            _adminBL.CreateUser(user);

            return RedirectToAction("Admin");
        }
    }
}