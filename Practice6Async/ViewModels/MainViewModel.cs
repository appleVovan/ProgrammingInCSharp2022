using System;
using KMA.ProgrammingInCSharp2022.Practice6Async.Navigation;

namespace KMA.ProgrammingInCSharp2022.Practice6Async.ViewModels
{
    class MainViewModel : INavigatable<MainNavigationTypes>
    {
        public MainViewModel(Action exitEvent)
        {
        }

        public MainNavigationTypes ViewType
        {
            get
            {
                return MainNavigationTypes.Main;
            }
        }
    }
}
