using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResProjectForZoki.DataAccessModul
{
    public class Converter
    {
        public List<Consummation> ConvertDataTable(DataTable tbl)
        {
            List<Consummation> results = new List<Consummation>();

            // iterate over your data table
            foreach (DataRow row in tbl.Rows)
            {
                Consummation convertedObject = ConvertRowToMyObject(row);
                results.Add(convertedObject);
            }

            return results;
        }

        public Consummation ConvertRowToMyObject(DataRow row)
        {
            Consummation result = new Consummation();

            result.Hour = Convert.ToInt32(row["Sat"]);
            result.ConsummationMWH = Convert.ToInt32(row["Potrosnja"]);
            result.IdOfArea = Convert.ToString(row["IdGeoPod"]);

            return result;
        }
    }
}

