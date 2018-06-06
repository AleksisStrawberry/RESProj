using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResProjectForZoki.FileReaderModul
{
    public class ReaderHelper
    {
        public void ImportCSV(DataTable Podaci, string fileName)
        {
            string Date = Path.GetFileName(fileName);
            Date = Date.Split('.')[0];
            //Console.WriteLine(Date);

            string csvData = File.ReadAllText(fileName);   // D: Iscita se ceo fajl

            DateTime TimeStamp = DateTime.ParseExact(Date, "yyyy_MM_dd", CultureInfo.InvariantCulture);
            //Console.WriteLine(TimeStamp);

            foreach (string row in csvData.Split('\n'))     // D: Dodaju se podaci u tabelu red po red
            {
                string[] row1 = row.Split('\t');
                if (!string.IsNullOrEmpty(row) && int.TryParse(row1[0], out int n))   // D: Dodatna provera da li je prvo polje broj ili string ("Sat")
                {
                    Podaci.Rows.Add();
               
                    TimeSpan time = new TimeSpan(Int32.Parse(row1[0]), 0, 0);         //ovde kod dodavanja nesto nije dobro, msm da pristupanje nije dobro
                    TimeStamp = TimeStamp.Date + time;
                    Podaci.Rows[Podaci.Rows.Count - 1][0] = TimeStamp;      // D: Ubaci vreme

                    Podaci.Rows[Podaci.Rows.Count - 1][1] = row1[1];         // D: Ubaci potrosnju

                    Podaci.Rows[Podaci.Rows.Count - 1][2] = row1[2];         // D: Ubaci IdGeoPod

                    //Console.WriteLine(Podaci.Rows[Podaci.Rows.Count - 1][1].ToString());
                }
                
            }
        }
    }
}
