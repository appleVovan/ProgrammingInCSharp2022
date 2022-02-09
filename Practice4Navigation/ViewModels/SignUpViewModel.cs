using System;
using System.Windows;
using KMA.ProgrammingInCSharp2022.Practice4Navigation.Models;
using KMA.ProgrammingInCSharp2022.Practice4Navigation.Navigation;
using KMA.ProgrammingInCSharp2022.Practice4Navigation.Tools;

namespace KMA.ProgrammingInCSharp2022.Practice4Navigation.ViewModels
{
    class SignUpViewModel : IAuthNavigatable
    {
        #region Fields
        private RegistrationUser _registrationUser = new RegistrationUser();
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
        public string FirstName
        {
            get
            {
                return _registrationUser.FirstName;
            }
            set
            {
                _registrationUser.FirstName = value;
            }
        }
        public string Login
        {
            get
            {
                return _registrationUser.Login;
            }
            set
            {
                _registrationUser.Login = value;
            }
        }

        public string Password
        {
            get
            {
                return _registrationUser.Password;
            }
            set
            {
                _registrationUser.Password = value;
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

        public AuthNavigationTypes ViewType
        {
            get
            {
                return AuthNavigationTypes.SignUp;
            }
        }
        #endregion

        private void GotoSignIn()
        {
           _gotoSignIn.Invoke();
        }

        private void SignUp()
        {
            if (String.IsNullOrWhiteSpace(_registrationUser.Login) || String.IsNullOrWhiteSpace(_registrationUser.Password) || String.IsNullOrWhiteSpace(_registrationUser.FirstName))
                MessageBox.Show("Login or password is empty.");
            else
            {
                var authService = new AuthenticationService();
                try
                {
                    authService.RegisterUser(_registrationUser);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Sign Up failed: {ex.Message}");
                    return;
                }

                MessageBox.Show($"User successfully registered, please Sign In");
                _gotoSignIn.Invoke();
            }
        }

        private bool CanExecute(object obj)
        {
            return !String.IsNullOrWhiteSpace(_registrationUser.Login) && !String.IsNullOrWhiteSpace(_registrationUser.Password) && !String.IsNullOrWhiteSpace(_registrationUser.FirstName);
        }
    }
}
