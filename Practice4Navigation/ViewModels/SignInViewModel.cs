using System;
using System.Windows;
using KMA.ProgrammingInCSharp2022.Practice4Navigation.Models;
using KMA.ProgrammingInCSharp2022.Practice4Navigation.Tools;

namespace KMA.ProgrammingInCSharp2022.Practice4Navigation.ViewModels
{
    class SignInViewModel
    {
        #region Fields
        private UserCandidate _user = new UserCandidate();
        private RelayCommand<object> _signInCommand;
        private RelayCommand<object> _gotoSignUpCommand;
        private RelayCommand<object> _cancelCommand;
        private Action _gotoSignUp;
        private Action _gotoMain;

        public SignInViewModel(Action gotoSignUp, Action gotoMain)
        {
            _gotoSignUp = gotoSignUp;
            _gotoMain = gotoMain;
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

        public RelayCommand<object> SignInCommand
        {
            get
            {
                return _signInCommand ??= new RelayCommand<object>(_ => SignIn(), CanExecute);
            }
        }

        public RelayCommand<object> GotoSignUpCommand
        {
            get
            {
                return _gotoSignUpCommand ??= new RelayCommand<object>(_ => GotoSignUp(), CanExecute);
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

        private void SignIn()
        {
            MessageBox.Show($"Login successful for user {_user.Login}");
            _gotoMain.Invoke();
        }

        private void GotoSignUp()
        {
            _gotoSignUp.Invoke();
        }

        private bool CanExecute(object obj)
        {
            return !String.IsNullOrWhiteSpace(_user.Login) && !String.IsNullOrWhiteSpace(_user.Password);
        }
    }
}
