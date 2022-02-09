using System;
using KMA.ProgrammingInCSharp2022.Practice4Navigation.Navigation;

namespace KMA.ProgrammingInCSharp2022.Practice4Navigation.ViewModels
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
