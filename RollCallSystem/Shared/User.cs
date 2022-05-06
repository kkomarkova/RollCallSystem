using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RollCallSystem.Shared
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; } 
        public string Email { get; set; }
        public string Token { get; set; }

        public User() { }

        public User(int id, string firstName, string lastName, string email, string token)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Token = token;
        }
    }
}
