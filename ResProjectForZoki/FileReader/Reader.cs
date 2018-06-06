using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResProjectForZoki.FileReader
{
    public class Reader
    {
       

        public void ImportCSV(DataTable Podaci, string fileName)
        {
             string Date = fileName.Split('\\')[8];
             Date = Date.Split('.')[0];
             //Console.WriteLine(Date);

             string csvData = File.ReadAllText(fileName);   // D: Iscita se ceo fajl

             DateTime TimeStamp = DateTime.ParseExact(Date, "yyyy_MM_dd", CultureInfo.InvariantCulture);
             //Console.WriteLine(TimeStamp);

             foreach (string row in csvData.Split('\n'))     // D: Dodaju se podaci u tabelu red po red
             {
                 if (!string.IsNullOrEmpty(row))
                 {
                    Podaci.Rows.Add();

                    TimeSpan time = new TimeSpan(row[0], 0, 0);
                    TimeStamp = TimeStamp.Date + time;
                    Podaci.Rows[Podaci.Rows.Count - 1][0] = TimeStamp;      // D: Ubaci vreme

                    Podaci.Rows[Podaci.Rows.Count - 1][1] = row[1];         // D: Ubaci potrosnju

                    Podaci.Rows[Podaci.Rows.Count - 1][2] = row[2];         // D: Ubaci IdGeoPod

                 }
             }
            
        }
    }
}
