using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace models
{
    [Table("Inschrijvingen")]
    public partial class Inschrijving
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public bool Betaald { get; set; }

        [Required]
        public int GroepsreisId { get; set; }

        [Required]
        public int GebruikerId { get; set; }

        //Navigatieproperties
        public Gebruiker Gebruiker { get; set; }
        public Groepsreis Groepsreis { get; set; }
    }
}
