using personal_web.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using personal_web.Model_Context;
using personal_web.Models;
using System.Data.Entity;

namespace personal_web.Controllers
{
    [Authorize(Roles = "SuperAdmin")]
    public class AccountController : Controller
    {
        private readonly PersonalWeb_context db = new PersonalWeb_context();
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UpdateProfile(string oldPassword, string newPassword)
        {
            var userName = User.Identity.Name;
            var count = db.Users.Where(x => x.UserName == userName).SingleOrDefault();
            bool result = PasswordHashing.VerifyPassword(oldPassword, count.Password);
            if(result == false)
            {
                TempData["Msg"] = "Please Enter Correct Old Passowrd.";
                return View(nameof(Index));
            }
            else
            {
                User user = new User();
                user.Password = PasswordHashing.CreateHash(newPassword);
                db.Entry(User).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Dashbord", "Home");
            }
        }
        [AllowAnonymous]
        public ActionResult Login()
        {
            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Login(string username, string password)
        {
            var count = db.Users.Where(x => x.UserName == username).SingleOrDefault();
            if (count == null)
            {
                ViewBag.Msg = "Invalid Login Attempt........";
                return View();
            }
            bool result = PasswordHashing.VerifyPassword(password, count.Password);
            if (result)
            {
                FormsAuthentication.SetAuthCookie(password, false);

                var role_value = db.Users.Where(x => x.UserName == username).FirstOrDefault().Role;

                if (role_value == "SuperAdmin")
                {
                    return RedirectToAction("Dashbord", "Home");
                }
               
            }
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }
    }
}