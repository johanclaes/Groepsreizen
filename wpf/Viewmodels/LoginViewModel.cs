using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using models;
using wpf.ViewModels;

namespace wpf.Viewmodels
{
    public class LoginViewModel : BaseViewModel
    {
        private string _email;
        private SecureString _paswoord;
        private string _errorMessage;
       // private IUserRepository userRepository;
        //Properties
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
                NotifyPropertyChanged(nameof(Email));
            }
        }
        public SecureString Paswoord
        {
            get
            {
                return _paswoord;
            }
            set
            {
                _paswoord = value;
                NotifyPropertyChanged(nameof(Paswoord));
            }
        }
        public string ErrorMessage
        {
            get
            {
                return _errorMessage;
            }
            set
            {
                _errorMessage = value;
                NotifyPropertyChanged(nameof(ErrorMessage));
            }
        }
        //-> Commands
        public ICommand LoginCommand { get; }
        public ICommand ShowPasswordCommand { get; }
        public ICommand RememberPasswordCommand { get; }
        //Constructor
        public LoginViewModel()
        {
            //userRepository = new UserRepository();
            //LoginCommand = new ViewModelCommand(ExecuteLoginCommand, CanExecuteLoginCommand);
        }
        //private bool CanExecuteLoginCommand(object obj)
        //{
        //    //bool validData;
        //    //if (string.IsNullOrWhiteSpace(Username) || Username.Length < 3 ||
        //    //    Paswoord == null || Paswoord.Length < 3)
        //    //    validData = false;
        //    //else
        //    //    validData = true;
        //    //return validData;
        //}
        //private void ExecuteLoginCommand(object obj)
        //{
        //    var isValidUser = userRepository.AuthenticateUser(new NetworkCredential(Email, Paswoord));
        //    if (isValidUser)
        //    {
        //        Thread.CurrentPrincipal = new GenericPrincipal(
        //            new GenericIdentity(Username), null);
        //    }
        //    else
        //    {
        //        ErrorMessage = "* Invalid username or password";
        //    }
        //}

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
            }
            return true;
        }

        public override void Execute(object parameter)
        {
            switch (parameter.ToString())
            {
            }
        }
    }
}
