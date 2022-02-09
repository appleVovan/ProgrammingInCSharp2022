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
    class MainWindowViewModel : INotifyPropertyChanged
    {
        private List<IMainNavigatable> _viewModels = new List<IMainNavigatable>();
        private IMainNavigatable _currentViewModel;

        public IMainNavigatable CurrentViewModel
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

        public MainWindowViewModel()
        {
            Navigate(MainNavigationTypes.Auth);
        }

        internal void Navigate(MainNavigationTypes type)
        {
            if (CurrentViewModel != null && CurrentViewModel.ViewType == type)
                return;

            IMainNavigatable viewModel = GetViewModel(type);

            if (viewModel == null)
                return;
            
            _viewModels.Add(viewModel);
            CurrentViewModel = viewModel;
        }

        private IMainNavigatable GetViewModel(MainNavigationTypes type)
        {
            IMainNavigatable viewModel = _viewModels.FirstOrDefault(viewModel => viewModel.ViewType == type);

            if (viewModel != null) 
                return viewModel;
            
            switch (type)
            {
                case MainNavigationTypes.Auth:
                    viewModel = new AuthViewModel(()=>Navigate(MainNavigationTypes.Main));
                    break;
                case MainNavigationTypes.Main:
                    viewModel = new MainViewModel(() => Navigate(MainNavigationTypes.Auth));
                    break;
                default:
                    return null;
            }

            return viewModel;
        }
        
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
