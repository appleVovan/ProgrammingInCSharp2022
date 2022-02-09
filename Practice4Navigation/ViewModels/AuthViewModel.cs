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

        internal void Navigate(int type)
        {
            if (CurrentViewModel != null && CurrentViewModel.ViewType == type)
                return;

            IAuthNavigatable viewModel = _viewModels.FirstOrDefault(viewModel => viewModel.ViewType == type);

            if (viewModel == null)
            {
                if (type == 1)
                    viewModel = new SignInViewModel(() => Navigate(2), ExitNavigation);
                else if (type == 2)
                    viewModel = new SignUpViewModel(() => Navigate(1));
                else
                    return;
            }
            
            _viewModels.Add(viewModel);
            CurrentViewModel = viewModel;
        }

        private void ExitNavigation()
        {
            throw new NotImplementedException();
        }
    }
}
