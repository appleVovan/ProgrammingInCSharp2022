using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using KMA.ProgrammingInCSharp2022.Practice7Serialization.Managers;
using KMA.ProgrammingInCSharp2022.Practice7Serialization.Models;
using KMA.ProgrammingInCSharp2022.Practice7Serialization.Navigation;
using KMA.ProgrammingInCSharp2022.Practice7Serialization.Services;
using KMA.ProgrammingInCSharp2022.Practice7Serialization.Tools;

namespace KMA.ProgrammingInCSharp2022.Practice7Serialization.ViewModels
{
    class SignInViewModel : INavigatable<AuthNavigationTypes>, INotifyPropertyChanged
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
                    LoaderManager.Instance.ShowLoader();
                    user = await authService.Authenticate(_user);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Sign In failed: {ex.Message}");
                    return;
                }
                finally
                {
                    LoaderManager.Instance.HideLoader();
                }
                MessageBox.Show($"Sign In was successful for user {user.FirstName} {user.LastName}");
                StationManager.CurrentUser = user;
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


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
