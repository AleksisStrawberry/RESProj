using ResProjectForZoki.DataAccessModul;
using ResProjectForZoki.DataProxyModul;
using ResProjectForZoki.DB;
using ResProjectForZoki.FileReaderModul;
using ResProjectForZoki.Interfaces;
using ResProjectForZoki.LoggerModul;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResProjectForZoki
{
    public class ObjectMaker
    {
        static FileReader fileReader;
        static IDataProxy dataProxy;
        static ILogger logger = new Logger();
        static IDataAccess dataAccess = new DataAccess();

        static ObjectMaker()
        {
            fileReader = new FileReader(dataAccess);
            new Task(fileReader.Read).Start();
            dataProxy = new DataProxy(dataAccess);
        }

        public static IDataProxy DataProxy { get => dataProxy; }
    }
}
