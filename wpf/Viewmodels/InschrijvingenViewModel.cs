using dal.Data.UnitOfWork;
using dal;
using models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using models.Partials;
using Microsoft.Toolkit.Collections;

namespace wpf.ViewModels
{
    public class InschrijvingenViewModel : BaseViewModel
    {
        private IUnitOfWork _unitOfWork = new UnitOfWork(new GroepsreizenContext());

        private string _naamGebruiker;
        private ObservableCollection<Gebruiker> _gebruikers;
        private Gebruiker _geselecteerdeGebruiker;
        private ObservableCollection<Groepsreis> _groepsreizen;
        private ObservableCollection<Inschrijving> _ingeschrevenReizen;
        private Inschrijving _selectedIngeschrevenReis;
        private ObservableCollection<string> _landen;
        private Bestemming _selectedLand;
        private ObservableCollection<Bestemming> _gemeentes;
        private Bestemming _selectedGemeente;
        private ObservableCollection<Groepsreis> _gezochteReizen;
        private Groepsreis _selectedReis;
        private string _errorInschrijving;

        public string NaamGebruiker
        {
            get { return _naamGebruiker; }
            set
            {
                _naamGebruiker = value;
                NotifyPropertyChanged();
            }
        }

        public ObservableCollection<Gebruiker> Gebruikers
        {
            get { return _gebruikers; }
            set
            {
                _gebruikers = value;
                NotifyPropertyChanged();
            }
        }

        public Gebruiker GeselecteerdeGebruiker
        {
            get { return _geselecteerdeGebruiker; }
            set
            {
                _geselecteerdeGebruiker = value;
                Groepsreizen = new ObservableCollection<Groepsreis>(_unitOfWork.GroepsreisRepo.Ophalen());
                IngeschrevenReizen = new ObservableCollection<Inschrijving>(_unitOfWork.InschrijvingRepo.Ophalen(x => x.GebruikerId == GeselecteerdeGebruiker.Id));
                NotifyPropertyChanged();
            }
        }

        public ObservableCollection<Groepsreis> Groepsreizen
        {
            get { return _groepsreizen; }
            set
            {
                _groepsreizen = value;
                NotifyPropertyChanged();
            }
        }

        public ObservableCollection<Inschrijving> IngeschrevenReizen
        {
            get { return _ingeschrevenReizen; }
            set
            {
                _ingeschrevenReizen = value;
                NotifyPropertyChanged();
            }
        }

        public Inschrijving SelectedIngeschrevenReis
        {
            get { return _selectedIngeschrevenReis; }
            set
            {
                _selectedIngeschrevenReis = value;
                NotifyPropertyChanged();
            }
        }

        public ObservableCollection<string> Landen
        {
            get { return _landen; }
            set
            {
                _landen = value;
                NotifyPropertyChanged();
            }
        }

        public Bestemming SelectedLand
        {
            get { return _selectedLand; }
            set
            {
                _selectedLand = value;
                NotifyPropertyChanged();
            }
        }

        public ObservableCollection<Bestemming> Gemeentes
        {
            get { return _gemeentes; }
            set
            {
                _gemeentes = value;
                NotifyPropertyChanged();
            }
        }

        public Bestemming SelectedGemeente
        {
            get { return _selectedGemeente; }
            set
            {
                _selectedGemeente = value;
                NotifyPropertyChanged();
            }
        }

        public ObservableCollection<Groepsreis> GezochteReizen
        {
            get { return _gezochteReizen; }
            set
            {
                _gezochteReizen = value;
                NotifyPropertyChanged();
            }
        }

        public Groepsreis SelectedReis
        {
            get { return _selectedReis; }
            set
            {
                _selectedReis = value;
                NotifyPropertyChanged();
            }
        }

        public string ErrorInschrijving
        {
            get { return _errorInschrijving; }
            set
            {
                _errorInschrijving = value;
                NotifyPropertyChanged();
            }
        }

        public InschrijvingenViewModel() 
        {
            //Landen = new ObservableCollection<IGrouping<string, string>>(_unitOfWork.BestemmingRepo.Ophalen().GroupBy(x => x.Land));
            Landen = new ObservableCollection<string>(_unitOfWork.BestemmingRepo.Ophalen().Select(x => x.Land).Distinct());

            //var landenbestemming = new ObservableCollection<Bestemming>(_unitOfWork.BestemmingRepo.Ophalen());
            //Landen = (ObservableCollection<Bestemming>)landenbestemming.GroupBy(x => x.Land);
            //Gemeentes = new ObservableCollection<Bestemming>(_unitOfWork.BestemmingRepo.Ophalen());
        }

        public override string this[string columnName]
        {
            get
            {
                return "";
            }
        }

        public override bool CanExecute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "ZoekGebruikers": return true;
                case "MaakReservering": return true;
                case "ReserveerBetaling": return true;
                case "AnnuleerInschrijving": return true;
            }
            return true;
        }

        public override void Execute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "ZoekGebruikers": ZoekGebruikers(); break;
                case "MaakReservering": MaakReservering(); break;
                case "ReserveerBetaling": ReserveerBetaling(); break;
                case "AnnuleerInschrijving": AnnuleerInschrijving(); break;
            }
        }

        public void ZoekGebruikers() 
        {
            if (string.IsNullOrWhiteSpace(NaamGebruiker))
                Gebruikers = new ObservableCollection<Gebruiker>(_unitOfWork.GebruikerRepo.Ophalen());
            else
                Gebruikers = new ObservableCollection<Gebruiker>(_unitOfWork.GebruikerRepo.Ophalen(x => x.Naam.Contains(NaamGebruiker) || x.Voornaam.Contains(NaamGebruiker)));
        }
        public void MaakReservering() { }
        public void ReserveerBetaling() { }
        public void AnnuleerInschrijving() { }
    }
}
