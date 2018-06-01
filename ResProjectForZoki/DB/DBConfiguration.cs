using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResProjectForZoki.DB
{
    internal class DBConfiguration: DbMigrationsConfiguration<Context>
    {
        public DBConfiguration()
        {
            AutomaticMigrationsEnabled = true;  //ne diraj nista, vidi na netu sta radi
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "Database";
        }
    }
}
