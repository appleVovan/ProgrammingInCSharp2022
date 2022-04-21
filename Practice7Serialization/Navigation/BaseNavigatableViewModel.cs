using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace KMA.ProgrammingInCSharp2022.Practice7Serialization.Navigation
{
    internal abstract class BaseNavigatableViewModel<TObject> : INotifyPropertyChanged where TObject : Enum
    {
        private List<INavigatable<TObject>> _viewModels = new();
        private INavigatable<TObject> _currentViewModel;

        public INavigatable<TObject> CurrentViewModel
        {
            get 
            {
                return _currentViewModel;
            }
            private set 
            {
                if (_currentViewModel == value)
                    return;
                _currentViewModel = value;
                OnPropertyChanged();
            }
        }

        internal void Navigate(TObject type)
        {
            if (CurrentViewModel != null && CurrentViewModel.ViewType.Equals(type))
                return;

            INavigatable<TObject> viewModel = GetViewModel(type);

            if (viewModel == null)
                return;
            
            _viewModels.Add(viewModel);
            CurrentViewModel = viewModel;
        }

        private INavigatable<TObject> GetViewModel(TObject type)
        {
            INavigatable<TObject> viewModel = _viewModels.FirstOrDefault(viewModel => viewModel.ViewType.Equals(type));

            if (viewModel != null) 
                return viewModel;
            
            return CreateViewModel(type);
        }

        protected abstract INavigatable<TObject> CreateViewModel(TObject type);
        
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
