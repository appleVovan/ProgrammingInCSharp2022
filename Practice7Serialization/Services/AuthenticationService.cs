using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Threading;
using System.Threading.Tasks;
using KMA.ProgrammingInCSharp2022.Practice7Serialization.Models;
using KMA.ProgrammingInCSharp2022.Practice7Serialization.Repositories;

namespace KMA.ProgrammingInCSharp2022.Practice7Serialization.Services
{
    class AuthenticationService
    {
        private static FileRepository Repository = new FileRepository();

        public async Task<User> Authenticate(UserCandidate userCandidate)
        {
            if (String.IsNullOrWhiteSpace(userCandidate.Login) || String.IsNullOrWhiteSpace(userCandidate.Password))
                throw new ArgumentException("Login or Password is Empty");
            var dbUser = await Repository.GetAsync(userCandidate.Login);
            if (dbUser == null || userCandidate.Login != dbUser.Login || userCandidate.Password != dbUser.Password)
                throw new AuthenticationException("Wrong login or password");
            return new User(dbUser.Guid, dbUser.FirstName, dbUser.LastName, dbUser.Email, dbUser.Login);
        }

        public async Task<bool> RegisterUser(RegistrationUser regUser)
        {
            var dbUser = await Repository.GetAsync(regUser.Login);
            if (dbUser != null)
                throw new Exception("User already exists");
            if (String.IsNullOrWhiteSpace(regUser.Login) || String.IsNullOrWhiteSpace(regUser.Password) || String.IsNullOrWhiteSpace(regUser.FirstName))
                throw new ArgumentException("First Name, Login or Password is Empty");
            dbUser = new DBUser(regUser.FirstName, "Last", regUser.Login + "@gmail.com", regUser.Login, regUser.Password);
            await Repository.AddOrUpdateAsync(dbUser);
            return true;
        }
    }
}
