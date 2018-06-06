using ResProjectForZoki.DataAccessModul;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResProjectForZoki.DataProxyModul
{
    public interface IDataProxy
    {
        List<Consummation> GetData(DateTime from, DateTime to);
    }
}
