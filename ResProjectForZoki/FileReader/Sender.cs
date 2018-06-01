using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResProjectForZoki.FileReader
{
    public class Sender
    {
        static public void SendCSV()
        {
            foreach (DataRow row in Reader.oDataTable.Rows)
            {
                Console.WriteLine(row[0].ToString());
            }

        }

    }
}
