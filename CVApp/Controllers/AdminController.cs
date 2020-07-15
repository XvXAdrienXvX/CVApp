using BL;
using BL.Interfaces;
using BL.DTO;
using CVApp.Models;
using CVApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace CVApp.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminBL _adminBL;
        private readonly IMapper _mapper;

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
            var userModel = _mapper.Map<UsersDTO>(model);
            _adminBL.CreateUser(userModel);

            return RedirectToAction("Admin");
        }
    }
}