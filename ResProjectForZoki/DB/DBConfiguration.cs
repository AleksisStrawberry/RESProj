using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResProjectForZoki.DB
{
    [NotMapped]
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
