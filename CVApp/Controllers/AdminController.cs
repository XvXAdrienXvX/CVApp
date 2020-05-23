using BL;
using BL.Interfaces;
using BL.Models;
using CVApp.Models;
using CVApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CVApp.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminBL _adminBL;

        public AdminController(IAdminBL adminBL)
        {
            _adminBL = adminBL;
        }

        public ActionResult Admin()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            var adminId = _adminBL.GetAdminId((int)userId);
            var data = _adminBL.GetUsers(adminId);
            var model = new ConvertToViewModel().convertToUserList(data);

            return View(model);
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
                Password = model.Password,
                Email = model.Email

            };

            _adminBL.CreateUser(user);

            return RedirectToAction("Admin");
        }
    }
}