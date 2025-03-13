using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFNavigation02.Models;

namespace WPFNavigation02.Persistence
{
    public class PersonRepo
    {
        private List<Person> persons;

        public PersonRepo()
        {
            persons = new List<Person>
            {
                new Person("John", "Doe", 30),
                new Person("Jane", "Smith", 25),
                new Person("Michael", "Johnson", 40),
                new Person("Emily", "Davis", 35),
                new Person("Chris", "Brown", 28)
            };
        }

        public List<Person> GetAll()
        {
            return persons;
        }

        public void Add(Person person)
        {
            persons.Add(person);
        }
    }
}
