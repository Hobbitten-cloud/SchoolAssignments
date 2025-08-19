using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFInteractiveGUI
{
    public class PersonRepository
    {
        private List<Person> persons;

        public int Count
        {
            get { return persons.Count; }
        }

        public PersonRepository()
        {
            persons = new List<Person>();
        }

        public void AddPerson(Person person)
        {
            persons.Add(person);
        }

        public Person GetPersonAtIndex(int index)
        {
            Person personResultat = null;
            if (index >= 0 && index < persons.Count)
            {
                personResultat = persons[index];
            }

            return personResultat;
        }
        public void RemovePersonAtIndex(int index)
        {
            if (index >= 0 && index < persons.Count)
            {
                persons.RemoveAt(index);
            }
        }
        public void RemovePerson(Person person)
        {
            if (person != null)
            {
                persons.Remove(person);
            }
        }

    }
}
