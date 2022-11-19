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
    public class AboutsController : Controller
    {
        private readonly IAbouts aboutRepository;

        public AboutsController()
        {
            aboutRepository = new IAboutRepository(new PersonalWeb_context());
        }
        // GET: Abouts
        public ActionResult Index()
        {
            return View(aboutRepository.GetAbouts());
        }


        // GET: Abouts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Abouts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AboutID,Image,Qutation,ShortDescription,Description")] About about, HttpPostedFileBase ImageFile)
        {
            if (ModelState.IsValid)
            {
                var filename = Path.GetFileName(ImageFile.FileName);
                var path = Path.Combine(Server.MapPath("~/images"), filename);
                ImageFile.SaveAs(path);
                about.Image = "/images/" + filename;

                aboutRepository.CreateAbout(about);
                return RedirectToAction("Create");
            }

            return View(about);
        }

        // GET: Abouts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            About about = aboutRepository.GetAbout(Convert.ToInt32(id));
            if (about == null)
            {
                return HttpNotFound();
            }
            return View(about);
        }

        // POST: Abouts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AboutID,Image,Qutation,ShortDescription,Description")] About about)
        {
            if (ModelState.IsValid)
            {
                aboutRepository.UpdateAbout(about);
                return RedirectToAction("Index");
            }
            return View(about);
        }

        // GET: Abouts/Delete/5
        public ActionResult Delete(int? id)
        {
            About about = aboutRepository.GetAbout(Convert.ToInt32(id));
            if(about == null)
            {
                return HttpNotFound();
            }
            aboutRepository.DeleteAbout(about);
            return RedirectToAction("Create");
        }

    
    }
}
