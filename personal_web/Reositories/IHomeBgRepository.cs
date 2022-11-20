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
    public class IHomeBgRepository : IHomeBg
    {
        private readonly PersonalWeb_context dbContext;

        public IHomeBgRepository(PersonalWeb_context context)
        {
            this.dbContext = context;
        }
        public void CreateHomeBgDate(Home home)
        {
            dbContext.Homes.Add(home);
            dbContext.SaveChanges();
        }

        public void DeleteHoeBgData(Home home)
        {
            dbContext.Homes.Remove(home);
            dbContext.SaveChanges();
        }

        public IEnumerable<Home> GetHomeBgData()
        {
            return dbContext.Homes.ToList();
        }

        public Home GetHomeBgData(int Id)
        {
            return dbContext.Homes.Find(Id);
        }

        public void UpdateHomeBgData(Home home)
        {
            dbContext.Entry(home).State = EntityState.Modified;
            dbContext.SaveChanges();
        }
    }
}