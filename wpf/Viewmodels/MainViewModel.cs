using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using wpf.UserControls;

namespace wpf.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
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
                case "Personen": return true;
                case "Inschrijvingen": return true;
                case "Groepsreizen": return true;
                case "Opleidingen": return true;
                case "Bestemmingen": return true;
                case "Uitloggen": return true;
            }
            return true;
        }

        public override void Execute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "Personen": Personen(); break;
                case "Inschrijvingen": Inschrijvingen(); break;
                case "Groepsreizen": Groepsreizen(); break;
                case "Opleidingen": Opleidingen(); break;
                case "Bestemmingen": Bestemmingen(); break;
                case "Uitloggen": Uitloggen(); break;
            }
        }

        public void Personen() { }
        public void Inschrijvingen() { }
        public void Groepsreizen() { }
        public void Opleidingen() { }
        public void Bestemmingen() { }
        public void Uitloggen() { }
    }
}
