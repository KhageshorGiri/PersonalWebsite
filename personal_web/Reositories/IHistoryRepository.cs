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
    public class IHistoryRepository : IHistory
    {
        private readonly PersonalWeb_context dbContext;

        public IHistoryRepository(PersonalWeb_context context)
        {
            this.dbContext = context;
        }
        public void CreateHistory(History history)
        {
            dbContext.Histories.Add(history);
            dbContext.SaveChanges();
        }

        public void DeleteHistory(History history)
        {
            dbContext.Histories.Remove(history);
            dbContext.SaveChanges();
        }

        public IEnumerable<History> GetHistories()
        {
            return dbContext.Histories.ToList();
        }

        public History GetHistory(int Id)
        {
            return dbContext.Histories.Find(Id);
        }

        public void UpdateHistory(History history)
        {
            dbContext.Entry(history).State = EntityState.Modified;
            dbContext.SaveChanges();
        }
    }
}