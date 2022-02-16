using System.Windows;
using KMA.ProgrammingInCSharp2022.Practice6Async.Navigation;

namespace KMA.ProgrammingInCSharp2022.Practice6Async.ViewModels
{
    class MainWindowViewModel : BaseNavigatableViewModel<MainNavigationTypes>
    {
        private bool _isEnabled = true;
        private Visibility _loaderVisibility = Visibility.Collapsed;

        public bool IsEnabled
        {
            get
            {
                return _isEnabled;
            }
            private set
            {
                _isEnabled = value;
                OnPropertyChanged();
            }
        }

        public Visibility LoaderVisibility
        {
            get
            {
                return _loaderVisibility;
            }
            private set
            {
                _loaderVisibility = value;
                OnPropertyChanged();
            }
        }

        public MainWindowViewModel()
        {
            Navigate(MainNavigationTypes.Auth);
        }
        
        protected override INavigatable<MainNavigationTypes> CreateViewModel(MainNavigationTypes type)
        {
            switch (type)
            {
                case MainNavigationTypes.Auth:
                    return new AuthViewModel(()=>Navigate(MainNavigationTypes.Main));
                case MainNavigationTypes.Main:
                    return new MainViewModel(() => Navigate(MainNavigationTypes.Auth));
                default:
                    return null;
            }
        }
    }
}
