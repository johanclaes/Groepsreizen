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
using System.IO;

namespace wpf.ViewModels
{
    public class BestemmingenViewModel : BaseViewModel
    {
        private IUnitOfWork _unitOfWork = new UnitOfWork(new GroepsreizenContext());

        private ObservableCollection<Bestemmingstype> _bestemmingsTypes;
        private Bestemmingstype _selectedBestemmingsTypes;
        private Bestemming _bestemmingRecord;
        private ObservableCollection<Bestemming> _bestemmingen;
        private Bestemming _selectedBestemming;
        private string _nieuwBestemmingtype;
        private string _foutmeldingBestemming;
        private ObservableCollection<string> _landen;

        private string _selectedBestemmingsType;
        private string _selectedLand1;
        private string _selectedLand2;
        private string _naam;
        private string _straat;
        private string _gemeente;
        private int _capaciteit;

        public string SelectedBestemmingsType
        {
            get { return _selectedBestemmingsType; }
            set
            {
                _selectedBestemmingsType = value;
                NotifyPropertyChanged();
            }
        }

        public string? SelectedLand1
        {
            get { return _selectedLand1; }
            set
            {
                _selectedLand1 = value;
                // IsBestemmingAanmaken = true;
                NotifyPropertyChanged();
                
            }
        }

        public string? SelectedLand2
        {
            get { return _selectedLand2; }
            set
            {
                _selectedLand2 = value;
                NotifyPropertyChanged();
                VulListBoxPerLandIn(_selectedLand2);
                IsBestemmingAanmaken = false;
            }
        }

        public string Naam
        {
            get { return _naam; }
            set
            {
                _naam = value;
                NotifyPropertyChanged();
            }
        }

        public string Straat
        {
            get { return _straat; }
            set
            {
                _straat = value;
                NotifyPropertyChanged();
            }
        }

        public string Gemeente
        {
            get { return _gemeente; }
            set
            {
                _gemeente = value;
                NotifyPropertyChanged();
            }
        }

        public int Capaciteit
        {
            get { return _capaciteit; }
            set
            {
                _capaciteit = value;
                if (!IsBestemmingGeselecteerd)
                {
                    IsBestemmingAanmaken = true;
                }
                NotifyPropertyChanged();
            }
        }

        public void VulListBoxPerLandIn(string SelectedLand5)
        {
            //MessageBox.Show(SelectedLand5);
            Bestemmingen = new ObservableCollection<Bestemming>(_unitOfWork.BestemmingRepo.Ophalen(x => x.Land.Contains(SelectedLand5)));

        }

        public ObservableCollection<Bestemmingstype> BestemmingsTypes
        {
            get { return _bestemmingsTypes; }
            set
            {
                _bestemmingsTypes = value;
                NotifyPropertyChanged();
            }
        }

        public Bestemming BestemmingRecord
        {
            get { return _bestemmingRecord; }
            set
            {
                _bestemmingRecord = value;
                NotifyPropertyChanged();
            }
        }

        private bool _isBestemmingGeselecteerd;

        public bool IsBestemmingGeselecteerd
        {
            get { return _isBestemmingGeselecteerd; }
            set 
            { 
                _isBestemmingGeselecteerd = value;
                NotifyPropertyChanged();
            }
        }

        private bool _isBestemmingAanmaken;

        public bool IsBestemmingAanmaken
        {
            get { return _isBestemmingAanmaken; }
            set 
            { 
                _isBestemmingAanmaken = value;
                NotifyPropertyChanged();
            }
        }


        public ObservableCollection<Bestemming> Bestemmingen
        {
            get { return _bestemmingen; }
            set
            {
                _bestemmingen = value;
                NotifyPropertyChanged();
            }
        }

        public Bestemming SelectedBestemming
        {
            get { return _selectedBestemming; }
            set
            {
                _selectedBestemming = value;
                IsBestemmingGeselecteerd = true;
                IsBestemmingAanmaken = false;
                VulInfoGeselecteerdeBestemmingIn(SelectedBestemming);
                NotifyPropertyChanged();
            }
        }

        public void VulInfoGeselecteerdeBestemmingIn(Bestemming bestemming5)
        {
            if (bestemming5 != null)
            {
                SelectedBestemmingsType = bestemming5.Bestemmingstype.Naam;
                SelectedLand1 = bestemming5.Land;
                Naam = bestemming5.Naam;
                Gemeente = bestemming5.Gemeente;
                Straat = bestemming5.Straat;
                Capaciteit = (bestemming5.Capaciteit);
            }

        }

        public string NieuwBestemmingtype
        {
            get { return _nieuwBestemmingtype; }
            set
            {
                _nieuwBestemmingtype = value;
                NotifyPropertyChanged();
            }
        }

        private bool _bestemmingAanmaken;

        public bool BestemmingAanmaken
        {
            get { return _bestemmingAanmaken; }
            set 
            { 
                _bestemmingAanmaken = value;
                NotifyPropertyChanged();
            }
        }



        public string FoutmeldingBestemming
        {
            get { return _foutmeldingBestemming; }
            set
            {
                _foutmeldingBestemming = value;
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
                case "MaakBestemming": return true;
                case "UpdateBestemming": return true;
                case "VeldenLeegmaken": return true;
                case "BestemmingstypeToevoegen": return true;
            }
            return true;
        }

        public override void Execute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "MaakBestemming": MaakBestemming(); break;
                case "UpdateBestemming": UpdateBestemming(); break;
                case "VeldenLeegmaken": VeldenLeegmaken(); break;
                case "BestemmingstypeToevoegen": BestemmingstypeToevoegen(); break;
            }
        }

        

        public ObservableCollection<string> Landen
        {
            get
            {
                return _landen;
            }
            set
            {
                _landen = value;
                NotifyPropertyChanged();
            }

        }

        // constructor ==========================================================

        public BestemmingenViewModel()
        {
            Landen = new ObservableCollection<string> { "Belgie", "Nederland", "Frankrijk", "Oostenrijk" };
            BestemmingsTypes = new ObservableCollection<Bestemmingstype>(_unitOfWork.BestemmingstypeRepo.Ophalen());
            IsBestemmingAanmaken = false;
            IsBestemmingGeselecteerd = false;
        }

        public void MaakBestemming() 
        {
            string bestemmingstype1 = SelectedBestemmingsType;
            string land1 = SelectedLand1;
            string naam1 = Naam;
            string gemeente1 = Gemeente;
            string straat1 = Straat;
            int capaciteit1 = Capaciteit;
            MessageBox.Show(gemeente1 + " " + straat1 + " " + capaciteit1.ToString());


            BestemmingRecord.Bestemmingstype.Naam = bestemmingstype1;
            
            BestemmingRecord.Land = SelectedLand1;
            BestemmingRecord.Naam = Naam;
            BestemmingRecord.Gemeente = Gemeente;
            BestemmingRecord.Straat = Straat;
            BestemmingRecord.Capaciteit = Capaciteit;
            BestemmingRecord.Fotonaam = "test.png";

        }
        public void UpdateBestemming() 
        {
            MessageBox.Show("update");
        }
        public void VeldenLeegmaken() 
        {
            SelectedBestemmingsType = null;
            SelectedLand1 = null;
            Naam = string.Empty;
            Gemeente = string.Empty;
            Straat = string.Empty;
            Capaciteit = 0;
            SelectedLand2 = null;
            IsBestemmingAanmaken = false;
            IsBestemmingGeselecteerd = false;
            
        }
        public void BestemmingstypeToevoegen() 
        {
            Bestemmingstype Bestemmingstype1 = new Bestemmingstype();
            Bestemmingstype1.Naam = NieuwBestemmingtype;

            // testing of nieuw bestemmingstype minstens 3 karakters heeft
            if (Bestemmingstype1.Naam.Length < 3)
            {
                FoutmeldingBestemming = "Bestemmingstype minstens 3 karakters";
            }
            else
            {
                FoutmeldingBestemming = "";
                _unitOfWork.BestemmingstypeRepo.Toevoegen(Bestemmingstype1);
                int oke = _unitOfWork.Save();
                if (oke > 0)
                {
                    MessageBox.Show("Het bestemmingstype is toegevoegd.");
                    NieuwBestemmingtype = "";
                }
                else
                {
                    MessageBox.Show("Het bestemmingstype is niet toegevoegd.");
                }
            }

            


        }
    }
}
