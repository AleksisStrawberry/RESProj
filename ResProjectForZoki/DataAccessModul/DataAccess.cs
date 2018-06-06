using ResProjectForZoki.DB;
using ResProjectForZoki.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;

namespace ResProjectForZoki.DataAccessModul
{
    public class DataAccess : IDataAccess
    {
        private IConverter converter;
        private IDatabase database;

        public DataAccess()
        {
            converter = new Converter();
            database = new Database();
            Console.WriteLine("Izvrsen DataAccess()");
        }

        public DataAccess(IDatabase database, IConverter converter)
        {
            this.database = database;
            this.converter = converter;
        }


        public List<Consummation> GetConsummationsFromInterval(DateTime from, DateTime to)
        {
            if(from > to)
            {
                throw new ArgumentOutOfRangeException("From time is after to time");
            }

            List<Consummation> All = database.GetAll();
            List<Consummation> RetVal = new List<Consummation>();
            foreach (var d in All)
            {
                if (d.TimeStamp >= from && d.TimeStamp <= to)
                {
                    RetVal.Add(d);
                }
            }
            return RetVal;
        }


        public bool WriteToDataBase(DataTable dataTable)
        {
            if (dataTable == null)
            {
                throw new ArgumentNullException("dataTable is null.");
            }

            List<Consummation> listOfConsummations = converter.ConvertDataTable(dataTable);    //poziva se metoda koja konvertuje dataTable u listu
            foreach (var c in listOfConsummations)                                              //(jer data table ne moze da se upise u bazu zbog fundamentalne razlike)
            {
                database.Add(c);            //zatim se svaki objekat iz liste doda u bazu podataka pozivom metode iz Database-a
            }
            return true;
        }
    }
}
