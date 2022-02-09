using System;
using System.Windows;
using KMA.ProgrammingInCSharp2022.Practice4Navigation.Models;
using KMA.ProgrammingInCSharp2022.Practice4Navigation.Tools;

namespace KMA.ProgrammingInCSharp2022.Practice4Navigation.ViewModels
{
    class SignUpViewModel
    {
        #region Fields
        private UserCandidate _user = new UserCandidate();
        private RelayCommand<object> _gotoSignInCommand;
        private RelayCommand<object> _signUpCommand;
        private RelayCommand<object> _cancelCommand;
        private Action _gotoSignIn;

        public SignUpViewModel(Action gotoSignIn)
        {
            _gotoSignIn = gotoSignIn;
        }

        #endregion

        #region Properties
        public string Login
        {
            get
            {
                return _user.Login;
            }
            set
            {
                _user.Login = value;
            }
        }

        public string Password
        {
            get
            {
                return _user.Password;
            }
            set
            {
                _user.Password = value;
            }
        }

        public RelayCommand<object> GotoSignInCommand
        {
            get
            {
                return _gotoSignInCommand ??= new RelayCommand<object>(_ => GotoSignIn());
            }
        }

        public RelayCommand<object> SignUpCommand
        {
            get
            {
                return _signUpCommand ??= new RelayCommand<object>(_ => SignUp(), CanExecute);
            }
        }

        public RelayCommand<object> CancelCommand
        {
            get
            {
                return _cancelCommand ??= new RelayCommand<object>(_ => Environment.Exit(0));
            }
        }
        #endregion

        private void GotoSignIn()
        {
            _gotoSignIn.Invoke();
        }

        private void SignUp()
        {
            MessageBox.Show($"User with name {_user.Login} was created");
            _gotoSignIn.Invoke();
        }

        private bool CanExecute(object obj)
        {
            return !String.IsNullOrWhiteSpace(_user.Login) && !String.IsNullOrWhiteSpace(_user.Password);
        }
    }
}
