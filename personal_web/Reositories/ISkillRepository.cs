using personal_web.Iterfaces;
using personal_web.Model_Context;
using personal_web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace personal_web.Reositories
{
    public class ISkillRepository : ISkill
    {
        private readonly PersonalWeb_context dbContext;

        public ISkillRepository(PersonalWeb_context _context)
        {
            this.dbContext = _context;
        }
        public void CreateSkill(Skill skill)
        {
            dbContext.Skills.Add(skill);
            dbContext.SaveChanges();
        }

        public void DeleteSkill(int Id)
        {
            throw new NotImplementedException();
        }

        public Skill GetSkill(int Id)
        {
            return dbContext.Skills.Find(Id);
        }

        public IEnumerable<Skill> GetSkills()
        {
            return dbContext.Skills.ToList();
        }

        public void UpdateSkill(Skill skill)
        {
            throw new NotImplementedException();
        }

        public void CreateSkillAttribute(skillAttribute skillAttribute)
        {
            dbContext.SkillAttributes.Add(skillAttribute);
            dbContext.SaveChanges();
        }
    }
}