using personal_web.Iterfaces;
using personal_web.Model_Context;
using personal_web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace personal_web.Reositories
{
    public class IAccountRepository : IAccount
    {
        private readonly PersonalWeb_context dbContext;

        public IAccountRepository(PersonalWeb_context context)
        {
            this.dbContext = context;
        }
        public User GetUser(string userName)
        {
            return dbContext.Users.Where(user => user.UserName == userName).SingleOrDefault();
        }

        public void UpdateProfile(User user)
        {
            dbContext.Entry(user).State = EntityState.Modified;
            dbContext.SaveChanges();
        }

        public void CreateUser(User user)
        {
            dbContext.Users.Add(user);
            dbContext.SaveChanges();
        }
    }
}