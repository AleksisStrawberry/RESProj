using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResProjectForZoki.DataAccessModul
{
    public class Converter:IConverter
    {
        public List<Consummation> ConvertDataTable(DataTable tbl)
        {
            List<Consummation> results = new List<Consummation>();
            Consummation convertedObject;
            // iterate over your data table
            foreach (DataRow row in tbl.Rows)
            {
                convertedObject = ConvertRowToMyObject(row);
                results.Add(convertedObject);
            }

            return results;
        }

        private Consummation ConvertRowToMyObject(DataRow row)
        {
            Consummation result = new Consummation();

            result.TimeStamp = Convert.ToDateTime(row["TimeStamp"]);
            result.Comsumption = Convert.ToInt32(row["Comsumption"]);
            result.IdGeoArea = Convert.ToString(row["IdGeoArea"]);

            return result;
        }
    }
}

