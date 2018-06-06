using ResProjectForZoki.DataAccessModul;
using ResProjectForZoki.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ResProjectForZoki.FileReader
{
    public class Sender
    {
        bool succes;
        public DataTable Podaci = new DataTable();     // D: Tabela za podatke
        public string csv_file_path = @"C:\Users\David\Documents\Fax\RES\zadatak_4\csv";   // D: Putanja do csv-a na mom kompu

        public void SaveTable()
        {                                    
            Podaci.Columns.AddRange         // D: Formira se tabela
                (new DataColumn[3]
                    {
                        new DataColumn("TimeStamp", typeof(DateTime)),
                        new DataColumn("Comsumption", typeof(int)),
                        new DataColumn("IdGeoArea", typeof(int))
                    }
                );
            Reader r = new Reader();
            DataAccess d = new DataAccess();
            var fileNames = Directory.GetFiles(csv_file_path);

            foreach (string fileName in fileNames)
            {
                r.ImportCSV(Podaci, fileName);      // D: Ucitaj iz konkretnog fajla
                
                succes = d.WriteToDataBase(Podaci);  // D: Pokusaj upis u bazu

                if (succes == false)
                {
                    // Nije uspelo upisivanje u bazu
                }
            }


        }

    }
}
