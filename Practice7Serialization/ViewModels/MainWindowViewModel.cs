using System.Windows;
using KMA.ProgrammingInCSharp2022.Practice7Serialization.Managers;
using KMA.ProgrammingInCSharp2022.Practice7Serialization.Navigation;

namespace KMA.ProgrammingInCSharp2022.Practice7Serialization.ViewModels
{
    class MainWindowViewModel : BaseNavigatableViewModel<MainNavigationTypes>, ILoaderOwner
    {
        private bool _isEnabled = true;
        private Visibility _loaderVisibility = Visibility.Collapsed;

        public bool IsEnabled
        {
            get
            {
                return _isEnabled;
            }
            set
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
            set
            {
                _loaderVisibility = value;
                OnPropertyChanged();
            }
        }

        public MainWindowViewModel()
        {
            LoaderManager.Instance.Initialize(this);
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
