using models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpf.ViewModels
{
    public class OpleidingenViewModel : BaseViewModel
    {
        private ObservableCollection<Opleiding> _soortOpleidingen;
        private Opleiding _selectedSoortOpleiding;
        private DateTime _startdatum;
        private ObservableCollection<DateTime> _maanden;
        private DateTime _selectedMaand;
        private ObservableCollection<DateTime> _jaren;
        private DateTime _selectedJaar;
        private ObservableCollection<Opleiding> _opleidingen;
        private Opleiding _selectedOpleiding;
        private string _soortOpleiding;
        private string _deelnemer;
        private ObservableCollection<Gebruiker> _gezochteDeelnemers;
        private Gebruiker _selectedDeelnemer;
        private ObservableCollection<Gebruiker> _deelnemers;
        private string _errorOpleiding;

        public ObservableCollection<Opleiding> SoortOpleidingen
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

        public ObservableCollection<DateTime> Maanden
        {
            get { return _maanden; }
            set
            {
                _maanden = value;
                NotifyPropertyChanged();
            }
        }

        public DateTime SelectedMaand
        {
            get { return _selectedMaand; }
            set
            {
                _selectedMaand = value;
                NotifyPropertyChanged();
            }
        }

        public ObservableCollection<DateTime> Jaren
        {
            get { return _jaren; }
            set
            {
                _jaren = value;
                NotifyPropertyChanged();
            }
        }

        public DateTime SelectedJaar
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
            }
        }

        public void OpleidingAanmaken() { }
        public void OpleidingOpvragen() { }
        public void OpleidingstypeAanmaken() { }
        public void ZoekDeelnemer() { }
        public void VoegDeelnemerToe() { }
    }
}
