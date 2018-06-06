using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResProjectForZoki.DataAccessModul;
using ResProjectForZoki.Interfaces;

namespace ResProjectForZoki.DataProxyModul
{
    public class DataProxy : IDataProxy
    {
        IDataAccess dataAccess;
        private Dictionary<DateTime, List<Consummation>> cashData = new Dictionary<DateTime, List<Consummation>>();

        public DataProxy()
        {
            dataAccess = new DataAccess();
        }

        public DataProxy(IDataAccess dataAccess)
        {
            this.dataAccess = dataAccess;
        }

        public Dictionary<DateTime, List<Consummation>> CashData { get => cashData; set => cashData = value; }

        public List<Consummation> GetData(DateTime from, DateTime to)
        {
            List<Consummation> retVal = new List<Consummation>();
            for (int i = 0; i < 0; i++)
            {

            }
            retVal = dataAccess.GetConsummationsFromInterval(from, to);
            return retVal;
        }
    }
}
