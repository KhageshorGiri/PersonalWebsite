using personal_web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personal_web.Iterfaces
{
    interface ISkill
    {
        IEnumerable<Skill> GetSkills();

        Skill GetSkill(int Id);

        void CreateSkill(Skill skill);

        void UpdateSkill(Skill skill);

        void DeleteSkill(int Id);
    }
}
