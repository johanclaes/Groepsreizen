using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using models;
using dal;
using dal.Data.UnitOfWork;
using wpf.UserControls;

namespace wpf.ViewModels
{
    public class PersonenViewModel : BaseViewModel
    {
        private IUnitOfWork _unitOfWork = new UnitOfWork(new GroepsreizenContext());

        private string _naamGebruiker;
        private ObservableCollection<Gebruiker> _gebruikers;
        private Gebruiker _geselecteerdeGebruiker;
        private Gebruiker _gebruikerRecord;
        private string _foutmeldingen;

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
                GebruikerRecord = GeselecteerdeGebruiker;
                Foutmeldingen = "";
                NotifyPropertyChanged();
            }
        }

        public Gebruiker GebruikerRecord
        {
            get { return _gebruikerRecord; }
            set
            {
                _gebruikerRecord = value;
                NotifyPropertyChanged();
            }
        }

        public string Foutmeldingen
        {
            get { return _foutmeldingen; }
            set
            {
                _foutmeldingen = value;
                NotifyPropertyChanged();
            }
        }

        public PersonenViewModel() 
        {
            GebruikerRecord = new Gebruiker();
            Foutmeldingen = "";
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
                case "GebruikerAanmaken": return true;
                case "GebruikerAanpassen": return GeselecteerdeGebruiker != null;
                case "GebruikerVerwijderen": return GeselecteerdeGebruiker != null;
                case "FormulierLeegmaken": return true;
            }
            return true;
        }

        public override void Execute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "ZoekGebruikers": ZoekGebruikers(); break;
                case "GebruikerAanmaken": GebruikerAanmaken(); break;
                case "GebruikerAanpassen": GebruikerAanpassen(); break;
                case "GebruikerVerwijderen": GebruikerVerwijderen(); break;
                case "FormulierLeegmaken": FormulierLeegmaken(); break;
            }
        }

        public void ZoekGebruikers()
        {
            if (string.IsNullOrWhiteSpace(NaamGebruiker))
                Gebruikers = new ObservableCollection<Gebruiker>(_unitOfWork.GebruikerRepo.Ophalen());
            else
                Gebruikers = new ObservableCollection<Gebruiker>(_unitOfWork.GebruikerRepo.Ophalen(x => x.Naam.Contains(NaamGebruiker) || x.Voornaam.Contains(NaamGebruiker)));
        }

        public void GebruikerAanmaken()
        {
            if (GebruikerRecord.IsGeldig())
            {
                _unitOfWork.GebruikerRepo.Toevoegen(GebruikerRecord);
                int oke = _unitOfWork.Save();

                FoutmeldingNaSave(oke, "De gebruiker is niet toegevoegd!", "De gebruiker is toegevoegd!");
            }
        }

        public void GebruikerAanpassen()
        {
            if (GeselecteerdeGebruiker != null)
            {
                _unitOfWork.GebruikerRepo.ToevoegenOfAanpassen(GebruikerRecord);
                int oke = _unitOfWork.Save();

                FoutmeldingNaSave(oke, "De gebruiker is niet aangepast!", "De gebruiker is aangepast!");
            }
            else
            {
                Foutmeldingen = "Eerst een gebruiker selecteren!";
            }
        }

        public void GebruikerVerwijderen() 
        {
            if (GeselecteerdeGebruiker != null)
            {
                _unitOfWork.GebruikerRepo.Verwijderen(GeselecteerdeGebruiker.Id);
                int oke = _unitOfWork.Save();
                FoutmeldingNaSave(oke, "De gebruiker is niet verwijderd!", "De gebruiker is verwijderd!");
            }
            else
            {
                Foutmeldingen = "Eerst een gebruiker selecteren!";
            }
        }

        public void FormulierLeegmaken()
        {
            GeselecteerdeGebruiker = null;
            Foutmeldingen = "";
            MainWindow window = new MainWindow();
            window.personen2.dateGeboortedatum.SelectedDate = DateTime.Now;

            if (GeselecteerdeGebruiker != null)
            {
                GebruikerRecord = GeselecteerdeGebruiker;
            }
            else
            {
                GebruikerRecord = new Gebruiker();
            }
        }

        private void FoutmeldingNaSave(int ok, string foutmelding, string succesmelding) 
        {
            if (ok > 0)
            {
                FormulierLeegmaken();
                MessageBox.Show(succesmelding);
                ZoekGebruikers();
            }
            else
            {
                Foutmeldingen = foutmelding;
            }
        }
    }
}
