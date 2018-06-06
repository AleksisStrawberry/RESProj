using ResProjectForZoki.DataAccessModul;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.Entity;

namespace ResProjectForZoki.DB
{ 
    [NotMapped]
    internal class Context : DbContext  //kako smo mokovali kontekst????
    {
       public Context() : base("dbConnection2017") { //kupi iz konfiguracionog fajla
            Configuration.LazyLoadingEnabled = false;
            System.Data.Entity.Database.SetInitializer(new CreateDatabaseIfNotExists<Context>());
        }
        public DbSet<Consummation> consumations { get; set; }
    }
}
