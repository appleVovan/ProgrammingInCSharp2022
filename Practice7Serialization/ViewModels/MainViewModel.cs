using System;
using KMA.ProgrammingInCSharp2022.Practice7Serialization.Navigation;

namespace KMA.ProgrammingInCSharp2022.Practice7Serialization.ViewModels
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
