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
using wpf.UserControls;

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
        private string _selectedLand1;
        private string _selectedLand2;
        

        public Bestemmingstype SelectedBestemmingsType
        {
            get { return _selectedBestemmingsTypes; }
            set
            {
                _selectedBestemmingsTypes = value;
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
            }
        }


        public void VulListBoxPerLandIn(string SelectedLand5)
        {
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
                BestemmingRecord = SelectedBestemming;
                VulInfoGeselecteerdeBestemmingIn(SelectedBestemming);
                NotifyPropertyChanged();
            }
        }

        public void VulInfoGeselecteerdeBestemmingIn(Bestemming bestemming5)
        {
            if (bestemming5 != null)
            {
                SelectedBestemmingsType = bestemming5.Bestemmingstype;
                SelectedLand1 = bestemming5.Land;
                
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
                case "MaakBestemming": return (BestemmingRecord.Naam != null) && (BestemmingRecord.Capaciteit != 0) && (SelectedBestemming == null);
                case "UpdateBestemming": return SelectedBestemming != null;
                case "VeldenLeegmaken": return true;
                case "BestemmingstypeToevoegen": return NieuwBestemmingtype != null;
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
            BestemmingRecord = new Bestemming();
        }

        // de 4 knoppen ==========================================================
        public void MaakBestemming() 
        {
            Bestemming Bestemming1 = new Bestemming();
            // Bestemmingstype Bestemmingstype2 = new Bestemmingstype();

            Bestemming1.Bestemmingstype = SelectedBestemmingsType;
            Bestemming1.Land = SelectedLand1;
            Bestemming1.Naam = BestemmingRecord.Naam;
            Bestemming1.Gemeente = BestemmingRecord.Gemeente;
            Bestemming1.Straat = BestemmingRecord.Straat;
            Bestemming1.Capaciteit = BestemmingRecord.Capaciteit;
            Bestemming1.Fotonaam = "test.png";                      // de verwijzing naar de foto zit in de db, voorlopig doen we er niks mee

            if (Bestemming1.Error != string.Empty)                  // check of alle velden zijn ingevuld.
            {
                FoutmeldingBestemming = Bestemming1.Error;
            }
            else
            {
                _unitOfWork.BestemmingRepo.Toevoegen(Bestemming1);
                int oke = _unitOfWork.Save();
                if (oke > 0) 
                    { 
                    MessageBox.Show("bestemming toegevoegd."); 
                    VeldenLeegmaken(); 
                    BestemmingRecord = new Bestemming(); 
                    }
                else
                    {
                    MessageBox.Show("jammer, niet toegevoegd.");
                    }
            }
        }
        public void UpdateBestemming() 
        {
            if (SelectedBestemming != null)                 // om te vermijden bij VeldenLeegmaken, dat null error komt.
            {
                Bestemming Bestemming = new Bestemming();
                
                Bestemming.Bestemmingstype = SelectedBestemmingsType;
                Bestemming.BestemmingstypeId = BestemmingRecord.BestemmingstypeId;                         
                Bestemming.Id = BestemmingRecord.Id;
                Bestemming.Land = SelectedLand1;
                Bestemming.Naam = BestemmingRecord.Naam;
                Bestemming.Gemeente = BestemmingRecord.Gemeente;
                Bestemming.Straat = BestemmingRecord.Straat;
                Bestemming.Capaciteit = BestemmingRecord.Capaciteit;
                Bestemming.Fotonaam = BestemmingRecord.Fotonaam;

                _unitOfWork.BestemmingRepo.ToevoegenOfAanpassen(BestemmingRecord);
                int oke = _unitOfWork.Save();

                if (oke > 0) 
                { MessageBox.Show("Bestemming is aangepast!"); VeldenLeegmaken(); BestemmingRecord = new Bestemming(); } else 
                { MessageBox.Show("Bestemming NIET aangepast!"); };

                
            }
            else
            {
                FoutmeldingBestemming = "Eerst een bestemming selecteren!";
            }
        }
        public void VeldenLeegmaken() 
        {
            SelectedBestemmingsType = null;
            SelectedLand1 = null;
            BestemmingRecord = null;
            SelectedLand2 = null;
            NieuwBestemmingtype = null;
            
        }
        public void BestemmingstypeToevoegen() 
        {
            Bestemmingstype Bestemmingstype1 = new Bestemmingstype();
            Bestemmingstype1.Naam = NieuwBestemmingtype;

            if (Bestemmingstype1.Naam != null) 
            {
                // testing of nieuw bestemmingstype minstens 3 karakters heeft
                if (Bestemmingstype1.Naam.Length < 3  )
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
                        FoutmeldingBestemming = "";
                    }
                    else
                    {
                        MessageBox.Show("Het bestemmingstype is niet toegevoegd.");
                    }
                }
            }
            else
            {
                FoutmeldingBestemming = "Gelieve iets in te vullen.";
            }

        }
    }
}
