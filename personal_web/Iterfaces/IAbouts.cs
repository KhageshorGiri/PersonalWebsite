using personal_web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personal_web.Iterfaces
{
    interface IAbouts
    {
        IEnumerable<About> GetAbouts();

        About GetAbout(int Id);

        void CreateAbout(About about);

        void UpdateAbout(About about);

        void DeleteAbout(int Id);
    }
}
