using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResProjectForZoki.DataAccessModul
{
    public class Consummation
    {
        private DateTime timeStamp;     //datum i vreme
        private int comsumption;       //potrosnja(mW/h)
        private string idGeoArea;     //id podrucja

        #region Properties
        [Key]
        public int Id { get; set; }
        public DateTime TimeStamp { get => timeStamp; set => timeStamp = value; }
        public int Comsumption { get => comsumption; set => comsumption = value; }
        public string IdGeoArea { get => idGeoArea; set => idGeoArea = value; }
        #endregion Properties

        public Consummation() { }
        public Consummation(DateTime timeStamp, int comsumption, string idGeoArea)
        {
            TimeStamp = timeStamp;
            Comsumption = comsumption;
            IdGeoArea = idGeoArea;
        }

        public override bool Equals(object obj)
        {
            Consummation c = (Consummation) obj;
            if(Id != c.Id)
            {
                return false;
            }
            if (TimeStamp != c.TimeStamp)
            {
                return false;
            }
            if (Comsumption != c.Comsumption)
            {
                return false;
            }
            if (IdGeoArea != c.IdGeoArea)
            {
                return false;
            }
            return true;
        }
    }
}
