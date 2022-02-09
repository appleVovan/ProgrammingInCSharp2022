using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMA.ProgrammingInCSharp2022.Practice4Navigation.ViewModels
{
    class AuthViewModel
    {
        private List<object> _viewModels = new List<object>();

        public object CurrentViewModel
        {
            get;
            private set;
        }

        public AuthViewModel()
        {
            
        }

        internal void Navigate(int type)
        {
            if (CurrentViewModel != null && CurrentViewModel)
            {

            }
        }
    }
}
