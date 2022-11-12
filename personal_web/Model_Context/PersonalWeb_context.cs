using personal_web.Models;
using System.Data.Entity;

namespace personal_web.Model_Context
{
    public class PersonalWeb_context: DbContext
    {
        public PersonalWeb_context(): base("name=PersonalWeb_context")
        {

        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Home> Homes { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Blog> Blogs { get; set; }
        public virtual DbSet<About> Abouts { get; set; }
        public virtual DbSet<links> Links { get; set; }
        public virtual DbSet<Skill> Skills { get; set; }
        public virtual DbSet<skillAttribute> SkillAttributes { get; set; }
        public virtual DbSet<History> Histories { get; set; }

        public System.Data.Entity.DbSet<personal_web.Models.BlogCategory> BlogCategories { get; set; }
    }
}