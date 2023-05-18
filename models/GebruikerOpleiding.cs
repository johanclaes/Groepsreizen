using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace models
{
    [Table("GebruikerOpleidingen")]
    public partial class GebruikerOpleiding
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public int GebruikerId { get; set; }

        [Required]
        public int OpleidingId { get; set; }

        //Navigatieproperty
        public Gebruiker Gebruiker { get; set; }
        public Opleiding Opleiding { get; set; }
    }
}
