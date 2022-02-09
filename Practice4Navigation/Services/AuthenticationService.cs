using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using KMA.ProgrammingInCSharp2022.Practice4Navigation.Models;

namespace KMA.ProgrammingInCSharp2022.Practice4Navigation
{
    class AuthenticationService
    {
        private static List<DBUser> Storage = new List<DBUser>();

        public User Authenticate(UserCandidate userCandidate)
        {
            if (String.IsNullOrWhiteSpace(userCandidate.Login) || String.IsNullOrWhiteSpace(userCandidate.Password))
                throw new ArgumentException("Login or Password is Empty");
            var dbUser = Storage.FirstOrDefault(user => userCandidate.Login == user.Login && userCandidate.Password == user.Password);
            if (dbUser == null)
                throw new AuthenticationException("Wrong login or password");
            return new User(dbUser.Guid, dbUser.FirstName, dbUser.LastName, dbUser.Email, dbUser.Login);
        }

        public bool RegisterUser(RegistrationUser regUser)
        {
            var dbUser = Storage.FirstOrDefault(user => user.Login == regUser.Login);
            if (dbUser != null)
                throw new Exception("User already exists");
            if (String.IsNullOrWhiteSpace(regUser.Login) || String.IsNullOrWhiteSpace(regUser.Password) || String.IsNullOrWhiteSpace(regUser.FirstName))
                throw new ArgumentException("First Name, Login or Password is Empty");
            dbUser = new DBUser(regUser.FirstName, "Last", regUser.Login + "@gmail.com", regUser.Login, regUser.Password);
            Storage.Add(dbUser);
            return true;
        }
    }
}
