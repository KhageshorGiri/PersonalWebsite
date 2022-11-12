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
    public class BlogsController : Controller
    {
        private PersonalWeb_context db = new PersonalWeb_context();

        // GET: Blogs
        public ActionResult Index()
        {
            return View(db.Blogs.ToList());
        }

        public ActionResult BlogCategoryIndex()
        {
            return View(db.BlogCategories.ToList());
        }
        public ActionResult BlogCateogry()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BlogCateogry(string Category)
        {
            BlogCategory category = new BlogCategory();
            category.Category = Category;
            db.BlogCategories.Add(category);
            db.SaveChanges();
            return RedirectToAction("BlogCateogry", "Blogs");
        }

        // GET: Blogs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // GET: Blogs/Create
        public ActionResult Create()
        {
            ViewBag.BlogCategory = new SelectList(db.BlogCategories, "CategoryID", "Category");
            return View();
        }

        // POST: Blogs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BlogID,Title,Date,ShortDescription, Description,Image")] Blog blog, int? BlogCategory, HttpPostedFileBase ImageFile)
        {
            if (ModelState.IsValid)
            {

                var filename = Path.GetFileName(ImageFile.FileName);
                var path = Path.Combine(Server.MapPath("~/Images"), filename);
                ImageFile.SaveAs(path);
                blog.Image = "/Images/" + filename;

                blog.CategoryID = BlogCategory;
                db.Blogs.Add(blog);
                db.SaveChanges();
                return RedirectToAction("create");
            }
            ViewBag.BlogCategory = new SelectList(db.BlogCategories, "CategoryID", "Category");
            return View(blog);
        }


        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase file)
        {
            var location = SaveFile(Server.MapPath("/Images/"), file);
            return Json(new { location }, JsonRequestBehavior.AllowGet);
        }
        private static string SaveFile(string targetFolder, HttpPostedFileBase file)
        {
            const int megabyte = 1024 * 1024;

            if (!file.ContentType.StartsWith("image/"))
            {
                throw new InvalidOperationException("Invalid MIME content type.");
            }

            var extension = Path.GetExtension(file.FileName.ToLowerInvariant());
            string[] extensions = { ".gif", ".jpg", ".png", ".svg", ".webp" };
            if (!extensions.Contains(extension))
            {
                throw new InvalidOperationException("Invalid file extension.");
            }

            if (file.ContentLength > (10 * megabyte))
            {
                throw new InvalidOperationException("Error: Maximum file size is 10MB.");
            }

            var fileName = Guid.NewGuid() + extension;
            var path = Path.Combine(targetFolder, fileName);
            file.SaveAs(path);
            var return_file_path = Path.Combine("/Images", fileName).Replace('\\', '/');
            return return_file_path;
        }

       
        // GET: Blogs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // POST: Blogs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BlogID,Title,Date,ShortDescription,Description,Image")] Blog blog)
        {
            if (ModelState.IsValid)
            {
                db.Entry(blog).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(blog);
        }

        // GET: Blogs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // POST: Blogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Blog blog = db.Blogs.Find(id);
            db.Blogs.Remove(blog);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

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
