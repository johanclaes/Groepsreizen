using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace models
{
    [Table("Groepsreizen")]
    public partial class Groepsreis
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Naam { get; set; }

        [Required]
        public decimal Deelneemprijs { get; set; }
        public string? Thema { get; set; }

        [Required]
        public int BestemmingId { get; set; }
        public decimal? Budget { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Startdatum { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Einddatum { get; set; }

        [Required]
        public int Minimumleeftijd { get; set; }

        [Required]
        public int Maximumleeftijd { get; set; }
        public decimal? OverschotBudget { get; set; }

        [Required]
        public bool PlaatsenVrij { get; set; }

        [Required]
        public bool InschrijvingGestopt { get; set; }

        //Navigatieproperties
        public List<Inschrijving> Inschrijvingen { get; set; }
        public Bestemming Bestemming { get; set; }
        public List<Monitor> Monitoren { get; set; }
    }
}
