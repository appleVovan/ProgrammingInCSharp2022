using System;

namespace KMA.ProgrammingInCSharp2022.Practice6Async.Navigation
{
    internal interface INavigatable<TObject> where TObject : Enum
    {
        TObject ViewType
        {
            get;
        }
    }
}
