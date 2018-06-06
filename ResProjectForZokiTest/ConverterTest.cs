using Microsoft.VisualStudio.TestTools.UnitTesting;
using ResProjectForZoki.DataAccessModul;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResProjectForZokiTest
{
    [TestClass]
    public class ConverterTest
    {
        public DataTable MakeTable()
        {
            DataTable retVal = new DataTable();
            retVal.Columns.AddRange         // D: Formira se tabela
                (new DataColumn[3]
                    {
                        new DataColumn("TimeStamp", typeof(DateTime)),
                        new DataColumn("Comsumption", typeof(int)),
                        new DataColumn("IdGeoArea", typeof(string))
                    }
                );
            retVal.Rows.Add();
            retVal.Rows.Add();
            retVal.Rows.Add();

            retVal.Rows[0][0] = new DateTime(2018, 1, 1);
            retVal.Rows[0][1] = 1000;
            retVal.Rows[0][2] = "BG";

            retVal.Rows[1][0] = new DateTime(2018, 1, 2);
            retVal.Rows[1][1] = 1001;
            retVal.Rows[1][2] = "BG";

            retVal.Rows[2][0] = new DateTime(2018, 1, 3);
            retVal.Rows[2][1] = 1002;
            retVal.Rows[2][2] = "NS";

            return retVal;
        }

        [TestMethod]
        public void ConvertDataTable_3inTable_3inList()
        {
            DataTable input = MakeTable();
            List<Consummation> output = new List<Consummation>()
            {
                new Consummation(new DateTime(2018, 1, 1), 1000, "BG"),
                new Consummation(new DateTime(2018, 1, 2), 1001, "BG"),
                new Consummation(new DateTime(2018, 1, 3), 1002, "NS"),
            };
            IConverter converter = new Converter();

            var result = converter.ConvertDataTable(input);

            CollectionAssert.AreEquivalent(output, result);
        }
    }
}
