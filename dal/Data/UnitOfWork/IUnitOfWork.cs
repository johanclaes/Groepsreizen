using dal.Data.Repositories;
using models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Monitor = models.Monitor;

namespace dal.Data.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Bestemming> BestemmingRepo { get; }
        IRepository<Bestemmingstype> BestemmingstypeRepo { get; }
        IRepository<Gebruiker> GebruikerRepo { get; }
        IRepository<GebruikerOpleiding> GebruikerOpleidingRepo { get; }
        IRepository<Groepsreis> GroepsreisRepo { get; }
        IRepository<Inschrijving> InschrijvingRepo { get; }
        IRepository<Monitor> MonitorRepo { get; }
        IRepository<Opleiding> OpleidingRepo { get; }
        IRepository<OpleidingType> OpleidingTypeRepo { get; }

        int Save();
    }
}
