using KMA.ProgrammingInCSharp2022.Practice3LoginControlMVVM.Models;

namespace KMA.ProgrammingInCSharp2022.Practice3LoginControlMVVM.ViewModels
{
    class SignInViewModel
    {
        #region Fields
        private UserCandidate _user = new UserCandidate();
        #endregion

        #region Properties
        public string Login
        {
            get
            {
                return _user.Login;
            }
            set
            {
                _user.Login = value;
            }
        }

        public string Password
        {
            get
            {
                return _user.Password;
            }
            set
            {
                _user.Password = value;
            }
        }
        #endregion
    }
}
