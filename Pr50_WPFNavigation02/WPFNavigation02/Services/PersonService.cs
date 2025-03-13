using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFNavigation02.Models;
using WPFNavigation02.Persistence;

namespace WPFNavigation02.Services
{
    public class PersonService
    {
        private readonly PersonRepo _personRepo;
        private ObservableCollection<Person> _persons;

        public PersonService(PersonRepo personRepo)
        {
            _personRepo = personRepo;
            _persons = new ObservableCollection<Person>(personRepo.GetAll());
        }

        public void Add(Person person) 
        {
            if (string.IsNullOrWhiteSpace(person.FirstName) || string.IsNullOrWhiteSpace(person.LastName))
            {
                throw new ArgumentException("Personen skal have et fornavn og efternavn");
            }
            if (person.Age < 0) 
            {
                throw new ArgumentException("Personens alder må ikke være negativ");
            }
            _persons.Add(person);
            _personRepo.Add(person);
        }
        public ObservableCollection<Person> GetAll() 
        {
            return _persons;
        }
    }
}
