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
    public class IAboutRepository : IAbouts
    {
        private readonly PersonalWeb_context dbContext;

        public IAboutRepository(PersonalWeb_context context)
        {
            this.dbContext = context;
        }
        public void CreateAbout(About about)
        {
            dbContext.Abouts.Add(about);
            dbContext.SaveChanges();
        }

        public void DeleteAbout(About about)
        {
            dbContext.Abouts.Remove(about);
            dbContext.SaveChanges();
        }

        public About GetAbout(int Id)
        {
            return dbContext.Abouts.Find(Id);
        }

        public IEnumerable<About> GetAbouts()
        {
            return dbContext.Abouts.ToList();
        }

        public void UpdateAbout(About about)
        {
            dbContext.Entry(about).State = EntityState.Modified;
            dbContext.SaveChanges();
        }
    }
}