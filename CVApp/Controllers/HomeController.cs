using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CVApp.Models;
using CVApp.Services;
using BL.Interfaces;

namespace CVApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUsersBL _userBL;

        public HomeController(IUsersBL userBL)
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
            var data = _userBL.GetUsers();
            var model = new ConvertToViewModel().convert(data);

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

        public ActionResult Skills()
        {

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
