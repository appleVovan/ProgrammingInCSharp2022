namespace KMA.ProgrammingInCSharp2022.Practice4Navigation.Navigation
{
    enum MainNavigationTypes
    {
        Main,
        Auth
    }

    internal interface IMainNavigatable
    {
        MainNavigationTypes ViewType
        {
            get;
        }
    }
}
