using personal_web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personal_web.Iterfaces
{
    interface IHomeBg
    {
        void CreateHomeBgDate(Home home);

        IEnumerable<Home> GetHomeBgData();

        Home GetHomeBgData(int Id);

        void UpdateHomeBgData(Home home);

        void DeleteHoeBgData(Home home);

    }
}
