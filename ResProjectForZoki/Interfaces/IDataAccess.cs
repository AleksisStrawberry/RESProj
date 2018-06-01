using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ResProjectForZoki.DataAccessModul;

namespace ResProjectForZoki.Interfaces
{
    public interface IDataAccess
    {
        bool WriteToDataBase(DataTable dataTable);
        List<Consummation>GetConsummationsFromInterval(DateTime from, DateTime to); 

    }
}
