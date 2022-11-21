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
using personal_web.Iterfaces;
using personal_web.Reositories;

namespace personal_web.Controllers
{
    [Authorize(Roles = "SuperAdmin")]
    public class AccountController : Controller
    {
        private readonly IAccount accountRepository;

        public AccountController()
        {
            accountRepository = new IAccountRepository(new PersonalWeb_context());
        }

        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UpdateProfile(string oldPassword, string newPassword)
        {
            var userName = User.Identity.Name;
            User user = accountRepository.GetUser(userName);
            bool result = PasswordHashing.VerifyPassword(oldPassword, user.Password);
            if(result == false)
            {
                TempData["Msg"] = "Please Enter Correct Old Passowrd.";
                return View(nameof(Index));
            }
            else
            {
                user.Password = PasswordHashing.CreateHash(newPassword);
                accountRepository.UpdateProfile(user);
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
            var count = accountRepository.GetUser(username);
            if (count == null)
            {
                ViewBag.Msg = "Invalid Login Attempt........";
                return View();
            }
            bool result = PasswordHashing.VerifyPassword(password, count.Password);
            if (result)
            {
                FormsAuthentication.SetAuthCookie(username, false);
                //FormsAuthentication.SetAuthCookie(password, false);

                var role_value = accountRepository.GetUser(username).Role;

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