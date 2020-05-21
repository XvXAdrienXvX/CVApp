using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CVApp.Models;
using CVApp.Services;
using BL.Interfaces;
using BL.Models;
using BL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace CVApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IUsersBL  _userBL;

        public UserController(IUsersBL userBL)
        {
            _userBL = userBL;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult About()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            var model = new ConvertToViewModel().convert(_userBL.GetUsersById((int)userId));

            return View(model);
        }

        public ActionResult Logout()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Login");
        }

        public ActionResult Academic()
        {

            return View();
        }

        public ActionResult Skill()
        {
            //var userId = HttpContext.Session.GetInt32("UserId");
            //var model = new ConvertToViewModel().convertToSkillList(_userBL.GetUserSkillsById((int)userId));

            return View();
        }

        [HttpGet]
        public string IdentifyUser(string username)
        {
            return username;
        }

        public ActionResult User_Options()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CheckCredentials(string username, string password)
        {
            int userId = _userBL.GetUserId(username, password);
            var userModel = new ConvertToViewModel().convert(_userBL.GetUsersById(userId));

            HttpContext.Session.SetString("Username", userModel.Username);
            HttpContext.Session.SetInt32("UserId", userModel.UserId);
            if (userModel.Admin)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
