using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheMovies.Model
{
    public class Employee
    {


        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Employee(string name, string username, string password)
        {
        
            Name = name;
            Username = username; 
            Password = password;
        }
    }
}
