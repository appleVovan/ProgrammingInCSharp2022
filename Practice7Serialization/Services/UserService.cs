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
    class UserService
    {
        private static FileRepository Repository = new FileRepository();

        public List<User> GetAllUsers()
        {
            var res = new List<User>();
            foreach (var user in Repository.GetAll())
            {
                res.Add(new User(user.Guid, user.FirstName, user.LastName, user.Email, user.Login));                    
            }
            return res;
        }
    }
}
