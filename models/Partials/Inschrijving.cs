using models.Partials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace models
{
    public partial class Inschrijving : BasisKlasse
    {
        public override string ToString()
        {
            return $"{Gebruiker.Voornaam} {Gebruiker.Naam} - {Groepsreis.Naam} - {Groepsreis.Startdatum.ToShortDateString()}";
        }

        public override string this[string columnName]
        {
            get
            {
                if (columnName == "GebruikerId" && GebruikerId <= 0)
                {
                    return "Naam moet ingevuld zijn.";
                }
                if (columnName == "GroepsreisId" && GroepsreisId <= 0)
                {
                    return "Deelnemerprijs moet ingevuld zijn.";
                }

                return "";
            }
        }
    }
}
