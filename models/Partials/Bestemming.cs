using models.Partials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace models
{
    public partial class Bestemming : BasisKlasse
    {
        public override string ToString()
        {
            return $"{Naam + " -  " + Gemeente}";
        }

        public string ToStringGemeente() 
        {
            return $"{Gemeente}";
        }

        public string ToStringLand()
        {
            return $"{Land}";
        }

        public override string this[string columnName]
        {
            get
            {
                if (columnName == "Naam" && string.IsNullOrWhiteSpace(Naam))
                {
                    return "Naam moet ingevuld zijn.";
                }
                if (columnName == "Land" && string.IsNullOrWhiteSpace(Land))
                {
                    return "Land mag niet leeg zijn.";
                }
                if (columnName == "Gemeente" && string.IsNullOrWhiteSpace(Gemeente))
                {
                    return "Gemeente moet ingevuld zijn.";
                }
                if (columnName == "Straat" && string.IsNullOrWhiteSpace(Straat))
                {
                    return "Straat mag niet leeg zijn.";
                }
                if (columnName == "Capaciteit" && Capaciteit <= 0)
                {
                    return "Capaciteit moet groter dan 0 zijn.";
                }
                if (columnName == "Fotonaam" && string.IsNullOrWhiteSpace(Fotonaam))
                {
                    return "Fotonaam moet ingevuld zijn.";
                }
                //if (columnName == "BestemmingstypeId" && BestemmingstypeId != null)
                //{
                //    return "Bestemmingstype moet ingevuld zijn.";
                //}

                return "";
            }
        }
    }
}
