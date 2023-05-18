using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace models
{
    [Table("Opleidingen")]
    public partial class Opleiding
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public int OpleidingTypeId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Startdatum { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Einddatum { get; set; }

        //Navigatieproperties
        public List<GebruikerOpleiding> GebruikerOpleidingen { get; set; }
        public OpleidingType OpleidingType { get; set; }
    }
}
