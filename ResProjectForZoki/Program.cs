using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ResProjectForZoki.Interfaces;
using ResProjectForZoki.DB;

namespace ResProjectForZoki
{
    class Program
    {
        static void Main(string[] args)
        {
            IniinitializeDatabasePath();

            IDatabase baza = new Database();
            baza.Add(new DataAccessModul.Consummation(2, 345, "SRB"));

            Console.WriteLine("Caoooooooooo");
            Console.WriteLine("Ovo nije lazni komit.");
            Console.WriteLine("Proveriti da li treba da se prave posebno projekti za DataAccess i ostalo!");
        }

        private static void IniinitializeDatabasePath() //kad god se pokrene da se podesi putanja bez obzira na kom je racunaru
        {
            string path = Directory.GetCurrentDirectory();
            path = path.Substring(0, path.LastIndexOf("bin")) + "DB";
            Directory.CreateDirectory(path);
            AppDomain.CurrentDomain.SetData("DataDirectory", path);
        }
    }
}
