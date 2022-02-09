using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KMA.ProgrammingInCSharp2022.Practice4Navigation.Navigation;

namespace KMA.ProgrammingInCSharp2022.Practice4Navigation.ViewModels
{
    class AuthViewModel
    {
        private List<IAuthNavigatable> _viewModels = new List<IAuthNavigatable>();

        public IAuthNavigatable CurrentViewModel
        {
            get;
            private set;
        }

        public AuthViewModel()
        {
            
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
            throw new NotImplementedException();
        }
    }
}
