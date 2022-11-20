using personal_web.Helpers;
using personal_web.Iterfaces;
using personal_web.Model_Context;
using personal_web.Models;
using personal_web.Reositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace personal_web.Controllers
{
    public class HomeController : Controller
    {
        private readonly PersonalWeb_context db = new PersonalWeb_context();

        //[Authorize(Roles = "SuperAdmin")]
        public ActionResult CreateUser()
        {
            string username = "Admin";
            string password = "Admin";
            string role = "SuperAdmin";

            User user = new User();
            user.UserName = username;
            user.Password = PasswordHashing.CreateHash(password);
            user.Role = role;
            db.Users.Add(user);
            db.SaveChanges();
            return RedirectToAction("Login", "Account");
        }

        public ActionResult Index()
        {
            ViewBag.callToAction = db.Homes.OrderByDescending(x => x.HomeID).Take(1).FirstOrDefault().CalltoAction;
            ViewBag.Name = db.Homes.OrderByDescending(x => x.HomeID).Take(1).FirstOrDefault().FullName;
            return View();
        }

        public ActionResult Background()
        {
            var background = db.Homes.OrderByDescending(x=>x.HomeID).Take(1).ToList();
            return View(background);
        }

        public ActionResult About()
        {
            var about = db.Abouts.OrderByDescending(x => x.AboutID).Take(1).ToList();
            return View(about);
        }

        public ActionResult Skills()
        {
            var skills = db.Skills.OrderByDescending(x => x.SkillID).Take(1).ToList();
            return View(skills);
        }

        public ActionResult History()
        {
            var skills = db.Histories.OrderByDescending(x => x.HistoryID).ToList();
            return View(skills);
        }


        public ActionResult Blogs()
        {
            ViewBag.Name = db.Homes.OrderByDescending(x => x.HomeID).Take(1).FirstOrDefault().FullName;
            var blogs = db.Blogs.OrderByDescending(x => x.BlogID).Take(3).ToList();
            return View(blogs);
        }

        public ActionResult BlogDetails()
        {
            ViewBag.Name = db.Homes.OrderByDescending(x => x.HomeID).Take(1).FirstOrDefault().FullName;
            var blogs = db.Blogs.OrderByDescending(x => x.BlogID).ToList();
            return View(blogs);
        }

        [Route("blogs/{id}/{category}/{*title}")]
        public ActionResult Blog(int id)
        {
            ViewBag.Name = db.Homes.OrderByDescending(x => x.HomeID).Take(1).FirstOrDefault().FullName;
            Blog blogs = db.Blogs.Find(id);
            return View(blogs);
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [Authorize(Roles = "SuperAdmin")]
        public ActionResult Dashbord()
        {
            return View();
        }
    }
}