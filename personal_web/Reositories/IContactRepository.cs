using personal_web.Iterfaces;
using personal_web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace personal_web.Reositories
{
    public class IContactRepository : IContact
    {
        public void CreateContactMessage(Contact contact)
        {
            throw new NotImplementedException();
        }

        public void DeleteContactMessage(int Id)
        {
            throw new NotImplementedException();
        }

        public Contact GetContactMessage(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Contact> GetContactMessages()
        {
            throw new NotImplementedException();
        }

        public void SendReponse()
        {
            throw new NotImplementedException();
        }
    }
}