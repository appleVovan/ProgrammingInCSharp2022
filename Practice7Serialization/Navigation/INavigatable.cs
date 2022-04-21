using System;

namespace KMA.ProgrammingInCSharp2022.Practice7Serialization.Navigation
{
    internal interface INavigatable<TObject> where TObject : Enum
    {
        TObject ViewType
        {
            get;
        }
    }
}
