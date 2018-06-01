using ResProjectForZoki.DataAccessModul;
using ResProjectForZoki.DB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResProjectForZoki.Interfaces
{
    public interface IDatabase
    {
        bool Add(Consummation data);
        List<Consummation> GetAll();

    }
}
