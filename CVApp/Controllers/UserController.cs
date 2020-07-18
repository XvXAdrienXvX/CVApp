using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CVApp.Models;
using CVApp.Services;
using BL.Interfaces;
using Microsoft.AspNetCore.Http;

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
            var model = new ConvertToViewModel().convertToViewWithNavigationProp(_userBL.GetUserDetailsById((int)userId), _userBL.GetUserSkillsById((int)userId));

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
            int? userId = _userBL.GetUserId(username, password);
            if(userId != null)
            {
                var userModel = new ConvertToViewModel().convertToViewWithNavigationProp(_userBL.GetUserDetailsById((int)userId), _userBL.GetUserSkillsById((int)userId));

                HttpContext.Session.SetString("Username", userModel.FirstName);
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
            else
            {
                return RedirectToAction("Login");
            }
           
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
