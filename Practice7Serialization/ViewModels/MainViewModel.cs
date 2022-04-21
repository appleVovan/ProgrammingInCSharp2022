using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using KMA.ProgrammingInCSharp2022.Practice7Serialization.Managers;
using KMA.ProgrammingInCSharp2022.Practice7Serialization.Models;
using KMA.ProgrammingInCSharp2022.Practice7Serialization.Navigation;
using KMA.ProgrammingInCSharp2022.Practice7Serialization.Services;

namespace KMA.ProgrammingInCSharp2022.Practice7Serialization.ViewModels
{
    class MainViewModel : INavigatable<MainNavigationTypes>, INotifyPropertyChanged
    {
        private ObservableCollection<User> _users;

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<User> Users
        {
            get => _users;
            private set
            {
                _users = value;
                OnPropertyChanged();
            }
        }

        public MainNavigationTypes ViewType
        {
            get
            {
                return MainNavigationTypes.Main;
            }
        }

        public string CurrentUser
        {
            get
            {
                return $"Current User {StationManager.CurrentUser}";
            }
        }


        public MainViewModel(Action exitEvent)
        {
            _users = new ObservableCollection<User>(new UserService().GetAllUsers());
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
