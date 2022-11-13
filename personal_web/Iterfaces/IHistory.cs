using personal_web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personal_web.Iterfaces
{
    interface IHistory
    {
        IEnumerable<History> GetHistories();

        void CreateHistory(History history);

        void DeleteHistory(int Id);
    }
}
