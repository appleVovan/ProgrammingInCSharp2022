using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using KMA.ProgrammingInCSharp2022.Practice4Navigation.Annotations;
using KMA.ProgrammingInCSharp2022.Practice4Navigation.Navigation;

namespace KMA.ProgrammingInCSharp2022.Practice4Navigation.ViewModels
{
    class AuthViewModel : INotifyPropertyChanged
    {
        private List<IAuthNavigatable> _viewModels = new List<IAuthNavigatable>();
        private Action _exitNavigation;
        private IAuthNavigatable _currentViewModel;

        public IAuthNavigatable CurrentViewModel
        {
            get 
            {
                return _currentViewModel;
            }
            private set 
            {
                if (_currentViewModel == value)
                    return;
                _currentViewModel = value;
                OnPropertyChanged();
            }
        }

        public AuthViewModel(Action exitNavigationAction)
        {
            _exitNavigation = exitNavigationAction;
            Navigate(AuthNavigationTypes.SignIn);
        }

        internal void Navigate(AuthNavigationTypes type)
        {
            if (CurrentViewModel != null && CurrentViewModel.ViewType == type)
                return;

            IAuthNavigatable viewModel = GetViewModel(type);

            if (viewModel == null)
                return;
            
            _viewModels.Add(viewModel);
            CurrentViewModel = viewModel;
        }

        private IAuthNavigatable GetViewModel(AuthNavigationTypes type)
        {
            IAuthNavigatable viewModel = _viewModels.FirstOrDefault(viewModel => viewModel.ViewType == type);

            if (viewModel != null) 
                return viewModel;
            
            switch (type)
            {
                case AuthNavigationTypes.SignIn:
                    viewModel = new SignInViewModel(() => Navigate(AuthNavigationTypes.SignUp), ExitNavigation);
                    break;
                case AuthNavigationTypes.SignUp:
                    viewModel = new SignUpViewModel(() => Navigate(AuthNavigationTypes.SignIn));
                    break;
                default:
                    return null;
            }

            return viewModel;
        }

        private void ExitNavigation()
        {
            _exitNavigation.Invoke();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
