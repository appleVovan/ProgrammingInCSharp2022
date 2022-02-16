using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using KMA.ProgrammingInCSharp2022.Practice6Async.ViewModels;

namespace KMA.ProgrammingInCSharp2022.Practice6Async.Managers
{
    class LoaderManager
    {
        private static readonly object _locker = new object();
        private static LoaderManager _instance;


        public static LoaderManager Instance
        {
            get
            {
                if (_instance != null)
                    return _instance;
                lock (_locker)
                {
                    return _instance ??= new LoaderManager();
                }
            }
        }

        private MainWindowViewModel _loaderOwner;

        private LoaderManager()
        {
        }

        public void Initialize(MainWindowViewModel loaderOwner)
        {
            _loaderOwner = loaderOwner;
        }

        public void ShowLoader()
        {
            _loaderOwner.IsEnabled = false;
            _loaderOwner.LoaderVisibility = Visibility.Visible;
        }

        public void HideLoader()
        {
            _loaderOwner.IsEnabled = true;
            _loaderOwner.LoaderVisibility = Visibility.Collapsed;
        }
    }
}
