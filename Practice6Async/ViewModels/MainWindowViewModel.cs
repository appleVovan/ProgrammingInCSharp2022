using KMA.ProgrammingInCSharp2022.Practice6Async.Navigation;

namespace KMA.ProgrammingInCSharp2022.Practice6Async.ViewModels
{
    class MainWindowViewModel : BaseNavigatableViewModel<MainNavigationTypes>
    {
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
