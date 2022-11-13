using personal_web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personal_web.Iterfaces
{
    interface IContact
    {
        IEnumerable<Contact> GetContactMessages();

        Contact GetContactMessage(int Id);

        void CreateContactMessage(Contact contact);

        void DeleteContactMessage(int Id);

        void SendReponse();
    }
}
