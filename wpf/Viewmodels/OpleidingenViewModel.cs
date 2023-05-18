using dal.Data.UnitOfWork;
using dal;
using models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using models.Partials;

namespace wpf.ViewModels
{
    public class OpleidingenViewModel : BaseViewModel
    {
        private IUnitOfWork _unitOfWork = new UnitOfWork(new GroepsreizenContext());

        private ObservableCollection<models.OpleidingType> _soortOpleidingen;
        private Opleiding _selectedSoortOpleiding;
        private DateTime _startdatum;
        private DateTime _einddatum;
        private ObservableCollection<string> _maanden;
        private string _selectedMaand;
        private ObservableCollection<int> _jaren;
        private int _selectedJaar;
        private ObservableCollection<Opleiding> _opleidingen;
        private Opleiding _selectedOpleiding;
        private string _soortOpleiding;
        private string _deelnemer;
        private ObservableCollection<Gebruiker> _gezochteDeelnemers;
        private Gebruiker _selectedDeelnemer;
        private ObservableCollection<Gebruiker> _deelnemers;
        private string _errorOpleiding;


        private string _opleidingsType;

        public string OpleidingsType
        {
            get { return _opleidingsType; }
            set { _opleidingsType = value; }
        }


        public ObservableCollection<models.OpleidingType> SoortOpleidingen
        {
            get { return _soortOpleidingen; }
            set
            {
                _soortOpleidingen = value;
                NotifyPropertyChanged();
            }
        }

        public Opleiding SelectedSoortOpleiding
        {
            get { return _selectedSoortOpleiding; }
            set
            {
                _selectedSoortOpleiding = value;
                NotifyPropertyChanged();
            }
        }

        public DateTime Startdatum
        {
            get { return _startdatum; }
            set
            {
                _startdatum = value;
                NotifyPropertyChanged();
            }
        }

        public DateTime Einddatum
        {
            get { return _einddatum; }
            set { _einddatum = value; }
        }


        public ObservableCollection<string> Maanden
        {
            get { return _maanden; }
            set
            {
                _maanden = value;
                NotifyPropertyChanged();
            }
        }

        public string SelectedMaand
        {
            get { return _selectedMaand; }
            set
            {
                _selectedMaand = value;
                NotifyPropertyChanged();
            }
        }

        public ObservableCollection<int> Jaren
        {
            get { return _jaren; }
            set
            {
                _jaren = value;
                NotifyPropertyChanged();
            }
        }

        public int SelectedJaar
        {
            get { return _selectedJaar; }
            set
            {
                _selectedJaar = value;
                NotifyPropertyChanged();
            }
        }

        public ObservableCollection<Opleiding> Opleidingen
        {
            get { return _opleidingen; }
            set
            {
                _opleidingen = value;
                NotifyPropertyChanged();
            }
        }

        public Opleiding SelectedOpleiding
        {
            get { return _selectedOpleiding; }
            set
            {
                _selectedOpleiding = value;
                NotifyPropertyChanged();
            }
        }

        public string SoortOpleiding
        {
            get { return _soortOpleiding; }
            set
            {
                _soortOpleiding = value;
                NotifyPropertyChanged();
            }
        }

        public string Deelnemer
        {
            get { return _deelnemer; }
            set
            {
                _deelnemer = value;
                NotifyPropertyChanged();
            }
        }

        public ObservableCollection<Gebruiker> GezochteDeelnemers
        {
            get { return _gezochteDeelnemers; }
            set
            {
                _gezochteDeelnemers = value;
                NotifyPropertyChanged();
            }
        }

        public Gebruiker SelectedDeelnemer
        {
            get { return _selectedDeelnemer; }
            set
            {
                _selectedDeelnemer = value;
                NotifyPropertyChanged();
            }
        }

        public ObservableCollection<Gebruiker> Deelnemers
        {
            get { return _deelnemers; }
            set
            {
                _deelnemers = value;
                NotifyPropertyChanged();
            }
        }

        public string ErrorOpleiding
        {
            get { return _errorOpleiding; }
            set
            {
                _errorOpleiding = value;
                NotifyPropertyChanged();
            }
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
                case "OpleidingAanmaken": return true;
                case "OpleidingOpvragen": return true;
                case "OpleidingstypeAanmaken": return true;
                case "ZoekDeelnemer": return true;
                case "VoegDeelnemerToe": return true;
                case "VerwijderDeelnemer": return true;
            }
            return true;
        }

        public override void Execute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "OpleidingAanmaken": OpleidingAanmaken(); break;
                case "OpleidingOpvragen": OpleidingOpvragen(); break;
                case "OpleidingstypeAanmaken": OpleidingstypeAanmaken(); break;
                case "ZoekDeelnemer": ZoekDeelnemer(); break;
                case "VoegDeelnemerToe": VoegDeelnemerToe(); break;
                case "VerwijderDeelnemer": VerwijderDeelnemer(); break;
            }
        }

        public OpleidingenViewModel()
        {
            SoortOpleidingen = new ObservableCollection<models.OpleidingType>(_unitOfWork.OpleidingTypeRepo.Ophalen());

            Maanden = new ObservableCollection<string> { "Jan", "Feb", "Maart", "April", "Mei", "Juni", "Juli", "Aug", "Sept", "Okt", "Nov", "Dec" };
            Jaren = new ObservableCollection<int> { 2022, 2023, 2024, 2025 };
            Startdatum = DateTime.Today;
            Einddatum = DateTime.Today;
        }

        public void OpleidingAanmaken() 
        {
            MessageBox.Show("opleiding aanmaken");
        }
        public void OpleidingOpvragen() 
        {
            MessageBox.Show("opleiding opvragen");
        }
        public void OpleidingstypeAanmaken() 
        {
            MessageBox.Show("opleidingType aanmaken");

            string test = SoortOpleiding;

            // SoortOpleiding = "kegelen";

            models.OpleidingType Opleidingtype1 = new models.OpleidingType();
            Opleidingtype1.Naam = SoortOpleiding;

            // testing of nieuw bestemmingstype minstens 3 karakters heeft
            if (Opleidingtype1.Naam.Length < 3)
            {
                ErrorOpleiding = "Opleidingstype minstens 3 karakters";
            }
            else
            {
                ErrorOpleiding = "";
                _unitOfWork.OpleidingTypeRepo.Toevoegen(Opleidingtype1);
                int oke = _unitOfWork.Save();
                if (oke > 0)
                {
                    MessageBox.Show("Het bestemmingstype is toegevoegd.");
                    SoortOpleiding = "";
                }
                else
                {
                    MessageBox.Show("Het bestemmingstype is niet toegevoegd.");
                }
            }
        }
        public void ZoekDeelnemer() 
        {
            MessageBox.Show("zoek deelnemer");
        }
        public void VoegDeelnemerToe() 
        {
            MessageBox.Show("voeg deelnemer toe");
        }

        public void VerwijderDeelnemer() 
        {
            MessageBox.Show("verwijder deelnemer");
        }
    }
}
