using models.Partials;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace models
{
    public partial class Bestemmingstype : BasisKlasse
    {
        public override string ToString()
        {
            return Naam;
        }

        public override string this[string columnName]
        {
            get
            {
                if (columnName == "Naam" && string.IsNullOrWhiteSpace(Naam))
                {
                    return "Naam moet ingevuld zijn.";
                }

                return "";
            }
        }
    }
}
