using personal_web.Models;
using personal_web.Model_Context;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace personal_web.Controllers
{
    [Authorize(Roles = "SuperAdmin")]
    public class SkillsController : Controller
    {
        private readonly PersonalWeb_context db = new PersonalWeb_context();
        // GET: Skills
        public ActionResult Index()
        {
            var skills = db.Skills.ToList();
            return View(skills);
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult AddSkill(string skilltableData, HttpPostedFileBase Image, string Description)
        {
            var skill_list = skilltableData.Split('#');
            if(Image != null)
            {
                Skill skill = new Skill();

                var filename = Path.GetFileName(Image.FileName);
                var path = Path.Combine(Server.MapPath("~/images"), filename);
                Image.SaveAs(path);
                skill.Image = "/images/" + filename;

                skill.Description = Description;
                db.Skills.Add(skill);

                foreach(var item in skill_list)
                {
                    if (item != "" && item != null)
                    {
                        skillAttribute skill_atr = new skillAttribute();
                        skill_atr.SkillTitle = item;
                        skill_atr.SkillID = skill.SkillID;
                        db.SkillAttributes.Add(skill_atr);
                    }
                }
                db.SaveChanges();
            }
            return RedirectToAction("create");
        }
    }
}