using personal_web.Iterfaces;
using personal_web.Model_Context;
using personal_web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace personal_web.Reositories
{
    public class IContactRepository : IContact
    {
        private readonly PersonalWeb_context dbContext;

        public IContactRepository(PersonalWeb_context context)
        {
            this.dbContext = context;
        }
        public void CreateContactMessage(Contact contact)
        {
            dbContext.Contacts.Add(contact);
            dbContext.SaveChanges();
        }

        public void DeleteContactMessage(Contact contact)
        {
            dbContext.Contacts.Remove(contact);
            dbContext.SaveChanges();
        }

        public Contact GetContactMessage(int Id)
        {
            return dbContext.Contacts.Find(Id);
        }

        public IEnumerable<Contact> GetContactMessages()
        {
            return dbContext.Contacts.ToList();
        }

        public void SendReponse()
        {
            throw new NotImplementedException();
        }
    }
}