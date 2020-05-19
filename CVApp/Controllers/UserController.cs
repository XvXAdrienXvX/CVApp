using Microsoft.AspNetCore.Mvc;

namespace MyCV.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult PersonalInfoView()
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
        public ActionResult CheckCredentials(string usr, string pwd)
        {
        //    Users user = new UsersBL().GetUsers(usr,pwd);
        //    if (user?.isValid == false)
        //        return RedirectToAction("Login");

        //    Session["username"] = user.username;
        //    if(user.Role.Equals("Admin"))
        //    {
        //        return RedirectToAction("Admin", "Admin");
        //    }
            return RedirectToAction("Index", "Home");                               
        }
    }
}