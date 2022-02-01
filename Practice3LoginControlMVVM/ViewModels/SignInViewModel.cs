using System;
using System.Windows;
using KMA.ProgrammingInCSharp2022.Practice3LoginControlMVVM.Models;
using KMA.ProgrammingInCSharp2022.Practice3LoginControlMVVM.Tools;

namespace KMA.ProgrammingInCSharp2022.Practice3LoginControlMVVM.ViewModels
{
    class SignInViewModel
    {
        #region Fields
        private UserCandidate _user = new UserCandidate();
        private RelayCommand<object> _signInCommand;
        private RelayCommand<object> _signUpCommand;
        private RelayCommand<object> _cancelCommand;
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

        private void SignIn()
        {
            MessageBox.Show($"Login successful for user {_user.Login}");
        }

        private void SignUp()
        {
            MessageBox.Show($"User with name {_user.Login} was created");
        }

        private bool CanExecute(object obj)
        {
            return !String.IsNullOrWhiteSpace(_user.Login) && !String.IsNullOrWhiteSpace(_user.Password);
        }
    }
}
