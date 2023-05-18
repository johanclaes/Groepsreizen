using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace models.Partials
{
    public partial class OpleidingType : BasisKlasse
    {
        public override string ToString()
        {
            //return $"{Naam}";
            return "test";
        }

        public override string this[string columnName]
        {
            get
            {


                return "";
            }
        }


    }
}
