using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using personal_web.Model_Context;

namespace personal_web.Controllers
{
    [Authorize(Roles = "SuperAdmin")]
    public class ContactController : Controller
    {
        private readonly PersonalWeb_context db = new PersonalWeb_context();
        // GET: Contact
        public ActionResult Index()
        {
            var contacts = db.Contacts.OrderByDescending(x=>x.ContactID).ToList();
            return View(contacts);
        }

        // GET: Contact/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

       

        
        // GET: Contact/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Contact/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
