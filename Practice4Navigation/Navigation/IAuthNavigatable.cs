namespace KMA.ProgrammingInCSharp2022.Practice4Navigation.Navigation
{
    enum AuthNavigationTypes
    {
        SignIn,
        SignUp
    }

    internal interface IAuthNavigatable
    {
        AuthNavigationTypes ViewType
        {
            get;
        }
    }
}
