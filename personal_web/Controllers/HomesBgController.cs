using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using personal_web.Model_Context;
using personal_web.Models;

namespace personal_web.Controllers
{
    [Authorize(Roles = "SuperAdmin")]
    public class HomesBgController : Controller
    {
        private PersonalWeb_context db = new PersonalWeb_context();

        // GET: HomesBg
        public ActionResult Index()
        {
            return View(db.Homes.ToList());
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

                db.Homes.Add(home);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            return View(home);
        }

        // GET: HomesBg/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Home home = db.Homes.Find(id);
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
        public ActionResult Edit([Bind(Include = "HomeID,FullName,TitleDescription,Introduction,Image,CalltoAction")] Home home)
        {
            if (ModelState.IsValid)
            {
                db.Entry(home).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(home);
        }

        // GET: HomesBg/Delete/5
        public ActionResult Delete(int? id)
        {
            Home home = db.Homes.Find(id);
            db.Homes.Remove(home);
            db.SaveChanges();
            return RedirectToAction("Create");
        }

       /* // POST: HomesBg/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Home home = db.Homes.Find(id);
            db.Homes.Remove(home);
            db.SaveChanges();
            return RedirectToAction("Index");
        }*/

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
