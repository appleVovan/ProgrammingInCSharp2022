using System;

namespace KMA.ProgrammingInCSharp2022.Practice4Navigation.Navigation
{
    internal interface INavigatable<TObject> where TObject : Enum
    {
        TObject ViewType
        {
            get;
        }
    }
}
