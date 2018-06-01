using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResProjectForZoki.FileReader
{
    public class Reader
    {
        private DataTable Podaci = new DataTable();     // D: Tabela za podatke
        string csv_file_path = @"C:\Users\David\Documents\Fax\RES\zadatak_4\csv\ostv_2018_05_07.csv";   // D: Putanja do csv-a na mom kompu

        public void ImportCSV()
        {
            Podaci.Columns.AddRange(new DataColumn[3]   // D: Formira se tabela
                {
                    new DataColumn("Sat", typeof(int)),     //ovde treba na engleskom da nam budu imena, zbog konzistentnosti koda
                    new DataColumn("Potrosnja", typeof(int)),
                    new DataColumn("IdGeoPod", typeof(string))
                }
            );

            string csvData = File.ReadAllText(csv_file_path);   // D: Iscita se ceo fajl

            foreach (string row in csvData.Split('\n'))     // D: Dodaju se podaci u tabelu red po red
            {
                if (!string.IsNullOrEmpty(row))
                {
                    Podaci.Rows.Add();
                    int i = 0;
  
                    foreach (string cell in row.Split(' '))     // D: Dodaje se svako polje u redu
                    {
                        Podaci.Rows[Podaci.Rows.Count - 1][i] = cell;
                        i++;
                    }
                }
            }

            
        }
    }
}
