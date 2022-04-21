using System.ComponentModel;
using System.Windows;

namespace KMA.ProgrammingInCSharp2022.Practice7Serialization.Managers
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
