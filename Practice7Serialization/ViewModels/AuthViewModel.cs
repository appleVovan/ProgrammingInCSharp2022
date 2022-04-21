using System;
using KMA.ProgrammingInCSharp2022.Practice7Serialization.Navigation;

namespace KMA.ProgrammingInCSharp2022.Practice7Serialization.ViewModels
{
    class AuthViewModel : BaseNavigatableViewModel<AuthNavigationTypes>, INavigatable<MainNavigationTypes>
    {
        private Action _exitNavigation;
        
        public MainNavigationTypes ViewType
        {
            get
            {
                return MainNavigationTypes.Auth;
            }
        }

        public AuthViewModel(Action exitNavigationAction)
        {
            _exitNavigation = exitNavigationAction;
            Navigate(AuthNavigationTypes.SignIn);
        }

        protected override INavigatable<AuthNavigationTypes> CreateViewModel(AuthNavigationTypes type)
        {
            switch (type)
            {
                case AuthNavigationTypes.SignIn:
                    return new SignInViewModel(() => Navigate(AuthNavigationTypes.SignUp), ExitNavigation);
                case AuthNavigationTypes.SignUp:
                    return new SignUpViewModel(() => Navigate(AuthNavigationTypes.SignIn));
                default:
                    return null;
            }
        }

        private void ExitNavigation()
        {
            _exitNavigation.Invoke();
        }
    }
}
