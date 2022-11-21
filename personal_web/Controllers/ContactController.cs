using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using personal_web.Iterfaces;
using personal_web.Model_Context;
using personal_web.Models;
using personal_web.Reositories;

namespace personal_web.Controllers
{
    [Authorize(Roles = "SuperAdmin")]
    public class ContactController : Controller
    {
        private readonly PersonalWeb_context db = new PersonalWeb_context();
        private IContact contactrepository;

        public ContactController()
        {
            contactrepository = new IContactRepository(new PersonalWeb_context());
        }

        // GET: Contact
        public ActionResult Index()
        {
            var contacts = contactrepository.GetContactMessages().OrderByDescending(contact => contact.ContactID);
            return View(contacts);
        }

        // GET: Contact/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string FullName, string Email, string Message)
        {
            Contact contact = new Contact();
            contact.FullName = FullName;
            contact.Email = Email;
            contact.Message = Message;
            contactrepository.CreateContactMessage(contact);
            return RedirectToAction("Index","Home");
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
