using models.Partials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace models
{
    public partial class Groepsreis : BasisKlasse
    {
        public override string ToString()
        {
            return $"{Bestemming.ToString()} - {Startdatum}";
        }

        public override string this[string columnName]
        {
            get
            {
                if (columnName == "Naam" && string.IsNullOrWhiteSpace(Naam))
                {
                    return "Naam moet ingevuld zijn.";
                }
                if (columnName == "Deelneemprijs" && Deelneemprijs <= 0)
                {
                    return "Deelnemerprijs moet ingevuld zijn.";
                }
                if (columnName == "BestemmingId" && BestemmingId <= -1)
                {
                    return "De bestemming moet ingevuld zijn.";
                }
                if (columnName == "Startdatum" && string.IsNullOrWhiteSpace(Startdatum.ToString()))
                {
                    return "Startdatum moet ingevuld zijn.";
                }
                if (columnName == "Einddatum" && string.IsNullOrWhiteSpace(Einddatum.ToString()))
                {
                    return "Einddatum moet ingevuld zijn.";
                }
                if (columnName == "MinimumLeeftijd" && Minimumleeftijd <= 0)
                {
                    return "Minimumleeftijd moet ingevuld zijn.";
                }
                if (columnName == "Maximumleeftijd" && Maximumleeftijd <= 0)
                {
                    return "Maximumleeftijd moet ingevuld zijn.";
                }

                return "";
            }
        }
    }
}
