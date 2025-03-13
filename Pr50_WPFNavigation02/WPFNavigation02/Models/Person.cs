using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFNavigation02.Models
{
    public class Person
    {
        private static int idCount = 0;
        private int id; 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; } 
        public Person(string firstName, string lastName, int age)
        {
            id = idCount++;
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }
    }
}
