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
        /*
        public static DataTable Podaci = new DataTable();     // D: Tabela za podatke
        static string csv_file_path = @"C:\Users\David\Documents\Fax\RES\zadatak_4\csv\ostv_2018_05_07.csv";   // D: Putanja do csv-a na mom kompu

        public static void ImportCSV()
        {
            Podaci.Columns.AddRange         // D: Formira se tabela
            (new DataColumn[3]
                {
                    new DataColumn("Sat", typeof(string)),
                    new DataColumn("Potrosnja", typeof(string)),
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
            */

        public static DataTable oDataTable = new DataTable();
        public static DataTable ReadCsvFile(string path)
        {

            var fileNames = Directory.GetFiles(@"C: \Users\David\Documents\Fax\RES\zadatak_4\csv");
            foreach (var fileName in fileNames)

            {

                StreamReader oStreamReader = new StreamReader(fileName);


                int RowCount = 0;
                string[] ColumnNames = null;
                string[] oStreamDataValues = null;

                while (!oStreamReader.EndOfStream)
                {

                    String oStreamRowData = oStreamReader.ReadLine().Trim();
                    if (oStreamRowData.Length > 0)
                    {

                        oStreamDataValues = oStreamRowData.Split(',');

                        if (RowCount == 0)
                        {
                            RowCount = 1;
                            ColumnNames = oStreamRowData.Split('\t');
                            oDataTable = new DataTable();


                            foreach (string csvcolumn in ColumnNames)
                            {
                                DataColumn oDataColumn = new DataColumn(csvcolumn.ToUpper(), typeof(string));

                                oDataColumn.DefaultValue = string.Empty;

                                oDataTable.Columns.Add(oDataColumn);
                            }
                        }
                        else
                        {
          
                            DataRow oDataRow = oDataTable.NewRow();

                            for (int i = 0; i < ColumnNames.Length; i++)
                            {
                                oDataRow[ColumnNames[i]] = oStreamDataValues[i] == null ? string.Empty : oStreamDataValues[i].ToString();
                            }
       
                            oDataTable.Rows.Add(oDataRow);
                        }

                    }
                }
                oStreamReader.Close();

                oStreamReader.Dispose();
            }
            return oDataTable;
        }

    }
}
