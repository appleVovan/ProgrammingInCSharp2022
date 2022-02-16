using System.ComponentModel;
using System.Windows;

namespace KMA.ProgrammingInCSharp2022.Practice6Async.Managers
{
    interface ILoaderOwner : INotifyPropertyChanged
    {
        public bool IsEnabled
        {
            get;
            set;
        }

        public Visibility LoaderVisibility
        {
            get;
            set;
        }
    }
}
