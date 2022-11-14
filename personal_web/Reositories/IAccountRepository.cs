using personal_web.Iterfaces;
using personal_web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace personal_web.Reositories
{
    public class IAccountRepository : IAccount
    {
        public User GetUser(string userName)
        {
            throw new NotImplementedException();
        }

        public void UpdateProfile(string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }
    }
}