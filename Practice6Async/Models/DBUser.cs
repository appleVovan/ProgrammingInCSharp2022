using System;

namespace KMA.ProgrammingInCSharp2022.Practice6Async.Models
{
    class DBUser
    {
        public DBUser(string firstName, string lastName, string email, string login, string password)
        {
            Guid = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Login = login;
            Password = password;
        }

        public Guid Guid { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }
        public string Login { get; }
        public string Password { get; }


    }
}
