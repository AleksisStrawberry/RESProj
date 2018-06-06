using System.Collections.Generic;
using System.Data;

namespace ResProjectForZoki.DataAccessModul
{
    public interface IConverter
    {
        List<Consummation> ConvertDataTable(DataTable tbl);
    }
}