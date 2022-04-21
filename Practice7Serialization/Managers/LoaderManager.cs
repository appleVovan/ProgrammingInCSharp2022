using System.Windows;

namespace KMA.ProgrammingInCSharp2022.Practice7Serialization.Managers
{
    class LoaderManager
    {
        private static readonly object Locker = new object();
        private static LoaderManager _instance;


        public static LoaderManager Instance
        {
            get
            {
                if (_instance != null)
                    return _instance;
                lock (Locker)
                {
                    return _instance ??= new LoaderManager();
                }
            }
        }

        private ILoaderOwner _loaderOwner;

        private LoaderManager()
        {
        }

        public void Initialize(ILoaderOwner loaderOwner)
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
