using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace models
{
    [Table("Bestemmingen")]
    public partial class Bestemming
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Naam { get; set; }

        [Required]
        public string Land { get; set; }

        [Required]
        public string Gemeente { get; set; }

        [Required]
        public string Straat { get; set; }

        [Required]
        public int Capaciteit { get; set; }

        
        public string? Fotonaam { get; set; }

        [Required]
        public int BestemmingstypeId { get; set; }

        //Navigatieproperty
        public Bestemmingstype Bestemmingstype { get; set; }
        public List<Groepsreis> Groepsreizen { get; set; }
    }
}
