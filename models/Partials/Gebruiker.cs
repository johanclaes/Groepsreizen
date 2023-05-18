using models.Partials;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace models
{
    public partial class Gebruiker : BasisKlasse
    {
        public override string ToString()
        {
            return $"{Voornaam} {Naam} - {Geboortedatum.ToShortDateString()}";
        }

        public string ToStringNaam() 
        {
            return $"{Voornaam} {Naam}";
        }

        public override string this[string columnName]
        {
            get
            {
                if (columnName == "Naam" && string.IsNullOrWhiteSpace(Naam))
                {
                    return "Naam moet ingevuld zijn.";
                }
                if (columnName == "Voornaam" && string.IsNullOrWhiteSpace(Voornaam))
                {
                    return "Voornaam mag niet leeg zijn.";
                }
                if (columnName == "Geboortedatum" && string.IsNullOrWhiteSpace(Geboortedatum.ToString()))
                {
                    return "Geboortedatum moet ingevuld zijn.";
                }
                if (columnName == "Email" && string.IsNullOrWhiteSpace(Email))
                {
                    return "Email mag niet leeg zijn.";
                }
                if (columnName == "Adres" && string.IsNullOrWhiteSpace(Adres))
                {
                    return "Adres moet groter dan 0 zijn.";
                }
                if (columnName == "Woonplaats" && string.IsNullOrWhiteSpace(Woonplaats))
                {
                    return "Woonplaats moet ingevuld zijn.";
                }

                return "";
            }
        }
    }
}
