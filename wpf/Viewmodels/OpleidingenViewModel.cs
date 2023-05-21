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
using System.Reflection.Metadata;
using wpf.UserControls;

namespace wpf.ViewModels
{
    public class OpleidingenViewModel : BaseViewModel
    {
        private IUnitOfWork _unitOfWork = new UnitOfWork(new GroepsreizenContext());

        private ObservableCollection<models.OpleidingType> _soortOpleidingen;
        private string _selectedSoortOpleiding;
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
        private Gebruiker _selectedDeelnemerDelete;
        private ObservableCollection<GebruikerOpleiding> _gebruikerOpleidingen;

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

        public ObservableCollection<models.GebruikerOpleiding> GebruikerOpleidingen
        {
            get { return _gebruikerOpleidingen; }
            set
            {
                _gebruikerOpleidingen = value;
                NotifyPropertyChanged();
            }
        }

        public string SelectedSoortOpleiding
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
            set 
            { 
                _einddatum = value;
                NotifyPropertyChanged();
            }
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
                // als een bepaalde opleiding met datum wordt geselecteerd, dan moeten alle deelnemers getoond worden in de rechtse listbox
                _selectedOpleiding = value;
                if (SelectedOpleiding != null)
                {
                    int PKselectedOpleiding = SelectedOpleiding.Id;

                    GebruikerOpleidingen = new ObservableCollection<GebruikerOpleiding>(_unitOfWork.GebruikerOpleidingRepo.Ophalen(x => x.OpleidingId == PKselectedOpleiding));
                    
                    Deelnemers = new ObservableCollection<Gebruiker>();

                    foreach (var item in GebruikerOpleidingen)
                    {
                        // MessageBox.Show(item.GebruikerId.ToString());
                        Gebruiker abc = new Gebruiker();
                        abc = (_unitOfWork.GebruikerRepo.Ophalen(x => x.Id == item.GebruikerId)).FirstOrDefault();
                        Deelnemers.Add(abc);
                    }
                    
                }

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

        public Gebruiker SelectedDeelnemerDelete
        {
            get { return _selectedDeelnemerDelete; }
            set 
            {
                _selectedDeelnemerDelete = value;
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
                case "OpleidingAanmaken": return ( (Startdatum != DateTime.Now.Date) && (Einddatum != DateTime.Now.Date) && (SelectedSoortOpleiding != null));
                case "OpleidingOpvragen": return ( (SelectedMaand != null) && ( SelectedJaar != 0));
                case "OpleidingstypeAanmaken": return SoortOpleiding != null;
                case "ZoekDeelnemer": return true;
                case "VoegDeelnemerToe": return ((SelectedOpleiding != null) && (SelectedDeelnemer != null));
                case "VerwijderDeelnemer": return SelectedDeelnemerDelete != null;
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

        // constructor =========================================
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
            // er wordt een lijst gemaakt (meestal grootte 1) van opleidingtype obv in combobox geselecteerd type
            var opleidingsstypes = new ObservableCollection<OpleidingType>(_unitOfWork.OpleidingTypeRepo.Ophalen(x => x.Naam.Contains(SelectedSoortOpleiding)));

            if (opleidingsstypes.Count() == 0)
            {
                ErrorOpleiding = "Kies opleidingstype.";
            }
            else
            {
                if (Startdatum < Einddatum)
                {
                    // er wordt opleiding aangemaakt verwijzend naar opleidingstype
                    models.Opleiding Opleiding1 = new models.Opleiding() { OpleidingTypeId = opleidingsstypes.FirstOrDefault().Id, Startdatum = Startdatum, Einddatum = Einddatum };

                    ErrorOpleiding = "";
                    _unitOfWork.OpleidingRepo.Toevoegen(Opleiding1);
                    int oke = _unitOfWork.Save();
                    if (oke > 0)
                    {
                        MessageBox.Show("Het opleidingsmoment is toegevoegd.");
                        SelectedSoortOpleiding = null;
                        Startdatum = DateTime.Now;
                        Einddatum = DateTime.Now;
                    }
                    else
                    {
                        MessageBox.Show("Het opleidingsmoment is niet toegevoegd.");
                    }
                }
                else
                {
                    ErrorOpleiding = "Begindatum liefst voor einddatum.";
                }

                
            }

        }
        public void OpleidingOpvragen() 
        {
            int SelectedMaandnr = 0 ;
            if (Deelnemers != null)
            {
                Deelnemers.Clear();
            }
           
            switch (SelectedMaand)
            {
                case "Jan": SelectedMaandnr = 1; break;
                case "Feb": SelectedMaandnr = 2; break;
                case "Maart": SelectedMaandnr = 3; break;
                case "April": SelectedMaandnr = 4; break;
                case "Mei": SelectedMaandnr = 5; break;
                case "Juni": SelectedMaandnr = 6; break;
                case "Juli": SelectedMaandnr = 7; break;
                case "Aug": SelectedMaandnr = 8; break;
                case "Sept": SelectedMaandnr = 9; break;
                case "Okt": SelectedMaandnr = 10; break;
                case "Nov": SelectedMaandnr = 11; break;
                case "Dec": SelectedMaandnr = 12; break;
            }
            
            // op basis van maand en jaar van startdatum gaan we zoeken in opleidingen
            Opleidingen = new ObservableCollection<Opleiding>(_unitOfWork.OpleidingRepo.Ophalen(x => x.Startdatum.Year == SelectedJaar && x.Startdatum.Month == SelectedMaandnr));
        }
        public void OpleidingstypeAanmaken() 
        {
            models.OpleidingType Opleidingtype1 = new models.OpleidingType();
            Opleidingtype1.Naam = SoortOpleiding;

            if (Opleidingtype1.Naam != null )
            {
                // testing of nieuw opleidingstype minstens 3 karakters heeft
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
                    MessageBox.Show("Het opleidingstype is toegevoegd.");
                    SoortOpleiding = "";
                    }
                    else
                    {
                    MessageBox.Show("Het opleidingstype is niet toegevoegd.");
                    }
                }
            }
            else
            {
                ErrorOpleiding = "Opleidingstype invullen!";
            }

            
            
        }
        public void ZoekDeelnemer() 
        {
            
            if (string.IsNullOrWhiteSpace(Deelnemer))
                GezochteDeelnemers = new ObservableCollection<Gebruiker>(_unitOfWork.GebruikerRepo.Ophalen());
            else
                GezochteDeelnemers = new ObservableCollection<Gebruiker>(_unitOfWork.GebruikerRepo.Ophalen(x => x.Naam.Contains(Deelnemer) || x.Voornaam.Contains(Deelnemer)));
        }
        public void VoegDeelnemerToe() 
        {
            
            Opleiding GeclickteOpleiding5 = SelectedOpleiding;
            Gebruiker GeclickteDeelnemer5 = SelectedDeelnemer;

            // als beide voorgaande verschillend van null, dan pas komt de knop Voegdeelnemer toe beschikbaar.

            // de GebruikerOpleiding heeft 2 FK: 1 verwijzend naar PK-gebruiken en 1 verwijzend naar PK-opleiding

            if (SelectedDeelnemer != null && SelectedOpleiding != null  )
            {
                GebruikerOpleiding GebruikerOpleiding1 = new GebruikerOpleiding();
                GebruikerOpleiding1.GebruikerId = SelectedDeelnemer.Id;
                GebruikerOpleiding1.OpleidingId = SelectedOpleiding.Id;

                _unitOfWork.GebruikerOpleidingRepo.Toevoegen(GebruikerOpleiding1);
                int oke = _unitOfWork.Save();
                if (oke > 0)
                {
                    MessageBox.Show("Opleiding toegevoegd voor user.");
                    Deelnemer = "";
                    SelectedDeelnemer = null;
                    GezochteDeelnemers = null;
                    SelectedOpleiding = null;
                }
                else
                {
                    MessageBox.Show("er ging iets mis.");
                }

            }
            else
            {
                ErrorOpleiding = "Selecteer opleiding en deelnemer.";
            }

        }

        public void VerwijderDeelnemer() 
        {
            
            // hier gaan we geen deelnemer deleten, maar een gebruikeropleiding
            // namelijk het kruispunt tussen SelectedDeelnemerDelete en SelectedOpleiding
            

            if (SelectedDeelnemerDelete != null && SelectedOpleiding != null)
            {
                int PKselectedDeelnemer = SelectedDeelnemerDelete.Id;               // we bepalen de primary key vna de user
                int PKselectedOpleiding = SelectedOpleiding.Id;

                GebruikerOpleiding Gebruikeropleiding5 = new GebruikerOpleiding();

                // we zoeken de PK-x van de gebruikersopleiding .. waar de FK1 =  PKuser en FK2 = PKopleiding
                foreach (var item in GebruikerOpleidingen)
                {
                    if (item.OpleidingId == PKselectedOpleiding && item.GebruikerId == PKselectedDeelnemer)
                    {
                        Gebruikeropleiding5.Id = item.Id;
                    }
                }

                // vervolgens delete van gebruikersopleiding met PK-x
                
                _unitOfWork.GebruikerOpleidingRepo.Verwijderen(Gebruikeropleiding5.Id);
                int oke = _unitOfWork.Save();
                if (oke > 0 )
                {
                    MessageBox.Show("gebruiker verwijderd van opleiding.");
                    SelectedOpleiding = null;
                }

            }

        }
    }
}
