using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace models
{
    [Table("Gebruikers")]
    public partial class Gebruiker
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Naam { get; set; }

        [Required]
        public string Voornaam { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Geboortedatum { get; set; }
        public bool IsLid { get; set; }
        public string? Telefoonnummer { get; set; }
        public bool Monitorbrevet { get; set; }
        public bool Hoofdmonitorbrevet { get; set; }
        public bool Webadmin { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Adres { get; set; }

        [Required]
        public string Woonplaats { get; set; }
        public string? Allergie { get; set; }
        public string? Medicatie { get; set; }
        public bool? Rolstoel { get; set; }
        public string? Opmerking { get; set; }
        public string? Paswoord { get; set; }

        //Navigatieproperties
        public List<GebruikerOpleiding> GebruikerOpleidingen { get; set; }
        public List<Inschrijving> Inschrijvingen { get; set; }
    }
}
