using dal.Data.Repositories;
using models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Monitor = models.Monitor;

namespace dal.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private IRepository<Bestemming> _bestemmingRepo;
        private IRepository<Bestemmingstype> _bestemmingstypeRepo;
        private IRepository<Gebruiker> _gebruikerRepo;
        private IRepository<GebruikerOpleiding> _gebruikerOpleidingRepo;
        private IRepository<Groepsreis> _groepsreisRepo;
        private IRepository<Inschrijving> _inschrijvingRepo;
        private IRepository<Monitor> _monitorRepo;
        private IRepository<Opleiding> _opleidingRepo;
        private IRepository<OpleidingType> _opleidingTypeRepo;

        public UnitOfWork(GroepsreizenContext grc)
        {
            Context = grc;
        }

        private GroepsreizenContext Context { get; }

        public IRepository<Bestemming> BestemmingRepo
        {
            get
            {
                if (_bestemmingRepo == null)
                {
                    _bestemmingRepo = new Repository<Bestemming>(Context);
                }
                return _bestemmingRepo;
            }
        }

        public IRepository<Bestemmingstype> BestemmingstypeRepo
        {
            get
            {
                if (_bestemmingstypeRepo == null)
                {
                    _bestemmingstypeRepo = new Repository<Bestemmingstype>(Context);
                }
                return _bestemmingstypeRepo;
            }
        }

        public IRepository<Gebruiker> GebruikerRepo
        {
            get
            {
                if (_gebruikerRepo == null)
                {
                    _gebruikerRepo = new Repository<Gebruiker>(Context);
                }
                return _gebruikerRepo;
            }
        }

        public IRepository<GebruikerOpleiding> GebruikerOpleidingRepo
        {
            get
            {
                if (_gebruikerOpleidingRepo == null)
                {
                    _gebruikerOpleidingRepo = new Repository<GebruikerOpleiding>(Context);
                }
                return _gebruikerOpleidingRepo;
            }
        }

        public IRepository<Groepsreis> GroepsreisRepo
        {
            get
            {
                if (_groepsreisRepo == null)
                {
                    _groepsreisRepo = new Repository<Groepsreis>(Context);
                }
                return _groepsreisRepo;
            }
        }

        public IRepository<Inschrijving> InschrijvingRepo
        {
            get
            {
                if (_inschrijvingRepo == null)
                {
                    _inschrijvingRepo = new Repository<Inschrijving>(Context);
                }
                return _inschrijvingRepo;
            }
        }

        public IRepository<Monitor> MonitorRepo
        {
            get
            {
                if (_monitorRepo == null)
                {
                    _monitorRepo = new Repository<Monitor>(Context);
                }
                return _monitorRepo;
            }
        }

        public IRepository<Opleiding> OpleidingRepo
        {
            get
            {
                if (_opleidingRepo == null)
                {
                    _opleidingRepo = new Repository<Opleiding>(Context);
                }
                return _opleidingRepo;
            }
        }

        public IRepository<OpleidingType> OpleidingTypeRepo
        {
            get
            {
                if (_opleidingTypeRepo == null)
                {
                    _opleidingTypeRepo = new Repository<OpleidingType>(Context);
                }
                return _opleidingTypeRepo;
            }
        }

        public void Dispose()
        {
            Context.Dispose();
        }

        public int Save()
        {
            return Context.SaveChanges();
        }
    }
}
