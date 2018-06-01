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
        private int hour;            //sat
        private int consummationMWH; //potrosnja(mW/h)
        private string idOfArea;     //id podrucja

        #region Properties
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Hour { get => hour; set => hour = value; }
        public int ConsummationMWH { get => consummationMWH; set => consummationMWH = value; }
        public string IdOfArea { get => idOfArea; set => idOfArea = value; }
        #endregion Properties

        public Consummation() { }
        public Consummation(int hour, int consummationMWH, string idOfArea)
        {
            Hour = hour;
            ConsummationMWH = consummationMWH;
            IdOfArea = idOfArea;
        }

    }
}
