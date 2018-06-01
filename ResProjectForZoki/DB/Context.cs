using ResProjectForZoki.DataAccessModul;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.Entity;

namespace ResProjectForZoki.DB
{ 
    public class User
    {
            private string _userName;
            private string _password;
            private string _firstName;
            private string _lastName;
            private string _groups;

            public User() { }

            public User(string userName, string password, string fname, string lname, string groups)
            {
                _userName = userName;
                _password = password;
                _firstName = fname;
                _lastName = lname;
                _groups = groups;
            }

            [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
            public string UserName { get => _userName; set { _userName = value; } }

            public string Password { get => _password; set { _password = value; } }
                                                                                                              

            public string FirstName { get => _firstName; set { _firstName = value; } }

            public string LastName { get => _lastName; set { _lastName = value;} }


            public string Groups { get => _groups; set { _groups = value; } }
        }

    internal class Context : DbContext  //kako smo mokovali kontekst????
    {
       public Context() : base("dbConnection2017") { //kupi iz konfiguracionog fajla
            Configuration.LazyLoadingEnabled = false;
            System.Data.Entity.Database.SetInitializer(new CreateDatabaseIfNotExists<Context>());
        }
        public DbSet<Consummation> consumations { get; set; }   //BITNO
        //obrisi User-a, umesto njega ide neka druga klasa koju napravis.. mozes promeniti ime od "data"
    }
}
