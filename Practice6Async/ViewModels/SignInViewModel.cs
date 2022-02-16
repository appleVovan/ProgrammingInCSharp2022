using System;
using System.Threading.Tasks;
using System.Windows;
using KMA.ProgrammingInCSharp2022.Practice6Async.Models;
using KMA.ProgrammingInCSharp2022.Practice6Async.Navigation;
using KMA.ProgrammingInCSharp2022.Practice6Async.Services;
using KMA.ProgrammingInCSharp2022.Practice6Async.Tools;

namespace KMA.ProgrammingInCSharp2022.Practice6Async.ViewModels
{
    class SignInViewModel : INavigatable<AuthNavigationTypes>
    {
        #region Fields
        private UserCandidate _user = new UserCandidate();
        private RelayCommand<object> _signInCommand;
        private RelayCommand<object> _gotoSignUpCommand;
        private RelayCommand<object> _cancelCommand;
        private Action _gotoSignUp;
        private Action _gotoMain;
        private bool _isEnabled = true;

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
                return _gotoSignUpCommand ??= new RelayCommand<object>(_ => GotoSignUp());
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
                return AuthNavigationTypes.SignIn;
            }
        }

        public bool IsEnabled
        {
            get
            {
                return _isEnabled;
            }
            set
            {
                _isEnabled = value;
            }
        }

        #endregion

        private async void SignIn()
        {
            if (String.IsNullOrWhiteSpace(_user.Login) || String.IsNullOrWhiteSpace(_user.Password))
                MessageBox.Show("Login or password is empty.");
            else
            {
                var authService = new AuthenticationService();
                User user = null;
                try
                {
                    IsEnabled = false;
                    user = await Task.Run(() => authService.Authenticate(_user));
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Sign In failed: {ex.Message}");
                    return;
                }
                finally
                {
                    IsEnabled = true;
                }
                MessageBox.Show($"Sign In was successful for user {user.FirstName} {user.LastName}");
                _gotoMain.Invoke();
            }
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
