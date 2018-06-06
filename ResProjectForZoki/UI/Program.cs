using System;
using System.IO;
using ResProjectForZoki.Interfaces;
using ResProjectForZoki.DB;
using ResProjectForZoki.DataProxyModul;

namespace ResProjectForZoki
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "1	3250	SRB";
            Console.WriteLine(s[0]);
            Console.WriteLine(s[1]);
            Console.WriteLine(s[2]);

            InitializeDatabasePath();

            Meni();

        }

        private static void Meni()
        {
            IDataProxy dataProxy = ObjectMaker.DataProxy;
            while (true)
            {
                Console.WriteLine("Enter start of interval: ");
                DateTime start = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Enter end of interval: ");
                DateTime end = DateTime.Parse(Console.ReadLine());

                var result = dataProxy.GetData(start, end);

                if(result.Count == 0)
                {
                    Console.WriteLine("There is no data in entered interval.");
                }
                else
                {
                    Console.WriteLine("\nData:");
                    foreach (var item in result)
                    {
                        Console.WriteLine(item);
                    }
                }
            }
        }

        private static void InitializeDatabasePath() //kad god se pokrene da se podesi putanja bez obzira na kom je racunaru
        {
            string path = Directory.GetCurrentDirectory();
            path = path.Substring(0, path.LastIndexOf("bin")) + "DB";
            Directory.CreateDirectory(path);
            AppDomain.CurrentDomain.SetData("DataDirectory", path);
        }
    }
}
