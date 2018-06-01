using ResProjectForZoki.DataAccessModul;
using ResProjectForZoki.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResProjectForZoki.DB
{
    public class Database : IDatabase
    {
        public bool Add(Consummation data)
        {
            using (var database = new Context())
            { 
                //database.data.ToList();
                database.consumations.Add(data);
                database.SaveChanges(); //BITNOOOOOOOOOOO, ne kod citanja
            }

            return true;
        }

        public List<Consummation> GetAll()
        {
            using (var database = new Context())
            {
                return database.consumations.ToList();
            }
        }
    }
}
