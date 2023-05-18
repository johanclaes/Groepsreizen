using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using models;
using Monitor = models.Monitor;
using Microsoft.Data.SqlClient;

namespace dal
{
    public class GroepsreizenContext : DbContext
    {
        public DbSet<Bestemming> Bestemmingen { get; set; }
        public DbSet<Bestemmingstype> Bestemmingentypes { get; set; }
        public DbSet<Gebruiker> Gebruikers { get; set; }
        public DbSet<GebruikerOpleiding> GebruikerOpleidingen { get; set; }
        public DbSet<Groepsreis> Groepsreizen { get; set; }
        public DbSet<Inschrijving> Inschrijvingen { get; set; }
        public DbSet<Monitor> Monitors { get; set; }
        public DbSet<Opleiding> Opleidingen { get; set; }
        public DbSet<OpleidingType> OpleidingTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=TestAT;Trusted_Connection=True;");
            //optionsBuilder.UseSqlServer(@"Data Source = groepsreizenagiletesting.database.windows.net; Initial Catalog = GroepsreizenAgileEnTesting; User ID = groepsreizen; Password = AgileTesting123; Connect Timeout = 30; Encrypt = True; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False");
            optionsBuilder.UseSqlServer(@"Data Source = groepsreizenagiletesting.database.windows.net; Initial Catalog = gevordprogagiletest; User ID = groepsreizen; Password = AgileTesting123; Connect Timeout = 30; Encrypt = True; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False");

        }
    }
}
