using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResProjectForZoki.LoggerModul
{
    public class Logger : ILogger
    {
        public void Write(string name, string logMessage)
        {
            using (StreamWriter writer = new StreamWriter("LogFile.txt", true))
            {
                writer.WriteLine($"{DateTime.Now} {name}: {logMessage}");
            }
        }
    }
}
