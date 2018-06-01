using ResProjectForZoki.FileReader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResProjectForZoki
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Caoooooooooo");
            Console.WriteLine("Ovo nije lazni komit.");

            Reader.ReadCsvFile(@"C: \Users\David\Documents\Fax\RES\zadatak_4\csv");
            Sender.SendCSV();
        }
    }
}
