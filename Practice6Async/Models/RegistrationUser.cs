namespace KMA.ProgrammingInCSharp2022.Practice6Async.Models
{
    class RegistrationUser
    {
        #region Fields
        private string _firstName;
        private string _login;
        private string _password;
        #endregion

        #region Properties
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
            }
        }
        public string Login
        {
            get
            {
                return _login;
            }
            set
            {
                _login = value;
            }
        }
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
            }
        } 
        #endregion
    }
}
