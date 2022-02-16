using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        private LoaderManager()
        {

        }

        public void ShowLoader()
        {

        }

        public void HideLoader()
        {

        }
    }
}
