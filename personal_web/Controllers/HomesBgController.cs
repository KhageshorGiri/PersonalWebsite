using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using personal_web.Iterfaces;
using personal_web.Model_Context;
using personal_web.Models;
using personal_web.Reositories;

namespace personal_web.Controllers
{
    [Authorize(Roles = "SuperAdmin")]
    public class HomesBgController : Controller
    {
        private readonly IHomeBg homeRepository;
        public HomesBgController()
        {
            homeRepository = new IHomeBgRepository(new PersonalWeb_context());
        }
        // GET: HomesBg
        public ActionResult Index()
        {
            return View(homeRepository.GetHomeBgData());
        }


        // GET: HomesBg/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HomesBg/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HomeID,FullName,TitleDescription,Introduction,Image,CalltoAction")] Home home, HttpPostedFileBase ImageFile)
        {
            if (ModelState.IsValid)
            {
                var filename = Path.GetFileName(ImageFile.FileName);
                var path = Path.Combine(Server.MapPath("~/images"), filename);
                ImageFile.SaveAs(path);
                home.Image = "/images/" + filename;
                homeRepository.CreateHomeBgDate(home);

                TempData["Sucess"] = "Data Created Sucessfully.";

                return RedirectToAction("Create");
            }
            TempData["Fail"] = "We are not able to save your data.";
            return View(home);
        }

        // GET: HomesBg/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Home home = homeRepository.GetHomeBgData(Convert.ToInt32(id));
            if (home == null)
            {
                return HttpNotFound();
            }
            return View(home);
        }

        // POST: HomesBg/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HomeID,FullName,TitleDescription,Introduction,Image,CalltoAction")] Home home, HttpPostedFileBase NewBgImage)
        {
            if (ModelState.IsValid)
            {
                if (NewBgImage != null)
                {
                    var filename = Path.GetFileName(NewBgImage.FileName);
                    var path = Path.Combine(Server.MapPath("~/images"), filename);
                    NewBgImage.SaveAs(path);
                    home.Image = "/images/" + filename;
                }
                homeRepository.UpdateHomeBgData(home);

                TempData["Sucess"] = "Data Edited Sucessfully.";
                return RedirectToAction("create");
            }
            TempData["Fail"] = "We are not able to edit your data.";
            return View(home);
        }

        // GET: HomesBg/Delete/5
        public ActionResult Delete(int? id)
        {
            Home home = homeRepository.GetHomeBgData(Convert.ToInt32(id));
            if (home == null)
            {
                return HttpNotFound();
            }
            homeRepository.DeleteHoeBgData(home);
            TempData["Sucess"] = "Data Deleted Sucessfully.";
            return RedirectToAction("Create");
        }

    }
}
