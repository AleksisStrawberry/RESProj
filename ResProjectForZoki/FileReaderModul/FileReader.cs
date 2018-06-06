using ResProjectForZoki.DataAccessModul;
using ResProjectForZoki.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResProjectForZoki.FileReaderModul
{
    class FileReader
    {
        ReaderHelper reader = new ReaderHelper();
        IDataAccess dataAccess;
        string csv_file_path = @"..\..\..\csv";   // D: relativna putanja do csv-a
        bool succes;
        DataTable data = new DataTable();     // D: Tabela za podatke                                                                            // D: Zameni sa svojom putanjom

        public FileReader(IDataAccess dataAccess)
        {
            this.dataAccess = dataAccess;
            data.Columns.AddRange         // D: Formira se tabela
                (new DataColumn[3]
                    {
                        new DataColumn("TimeStamp", typeof(DateTime)),
                        new DataColumn("Comsumption", typeof(int)),
                        new DataColumn("IdGeoArea", typeof(int))
                    }
                );

        }

        public void Read()
        {       
            var fileNames = Directory.GetFiles(csv_file_path);

            foreach (string fileName in fileNames)
            {
                reader.ImportCSV(data, fileName);      // D: Ucitaj iz konkretnog fajla

                succes = dataAccess.WriteToDataBase(data);  // D: Pokusaj upis u bazu

                if (succes == false)
                {
                    // Nije uspelo upisivanje u bazu
                    //logger.log ...
                }
            }
        }
    }
}
