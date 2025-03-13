using System;
using System.Collections.Generic;
using System.IO;

namespace WPFAndMVVM2.Models
{
    public class PersonRepository
    {
        // persons is the internal datastructure to represent the Person collection of the repository pattern
        private List<Person> persons = new List<Person>();

        public PersonRepository()
        {
            InitializeRepository();
        }

        private void InitializeRepository()
        {
            try
            {   // Open the text file using a stream reader.
                using (StreamReader sr = new StreamReader("Persons.csv"))
                {
                    // Read the stream to a string, and instantiate a Person object
                    String line = sr.ReadLine();

                    while (line != null)
                    {
                        string[] parts = line.Split(',');

                        // parts[0] contains first name, parts[1] contains last name, parts[2] contains age as text, parts[3] contains phone

                        this.Add(parts[0], parts[1], int.Parse(parts[2]), parts[3]);

                        //Read the next line
                        line = sr.ReadLine();
                    }
                }
            }
            catch (IOException)
            {
                throw;
            }
        }

        public Person Add(string firstName, string lastName, int age, string phone)
        {
            Person result = null;

            if (!string.IsNullOrEmpty(firstName) &&
                !string.IsNullOrEmpty(lastName) &&
                age >= 0 &&
                !string.IsNullOrEmpty(phone))
            {
                result = new Person()
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Age = age,
                    Phone = phone
                };

                // Add to persons list
                persons.Add(result);
            }
            else
                throw (new ArgumentException("Not all arguments are valid"));

            return result;
        }

        public Person Get(int id)
        {
            Person result = null;

            foreach (Person p in persons)
            {
                if (p.Id == id)
                {
                    result = p;
                    break;
                }
            }

            return result;
        }

        public List<Person> GetAll()
        {
            return persons;
        }

        public void Update(int id, string firstName, string lastName, int age, string phone)
        {
            // Find the person in the internal persons list with same Id as the 'id'-parameter
            Person foundPerson = this.Get(id);

            if (foundPerson != null)
            {
                if (!string.IsNullOrEmpty(firstName) &&
                    !string.IsNullOrEmpty(lastName) &&
                    age >= 0 &&
                    !string.IsNullOrEmpty(phone))
                {
                    // Update only changed properties for this person
                    if (foundPerson.FirstName != firstName)
                        foundPerson.FirstName = firstName;
                    if (foundPerson.LastName != lastName)
                        foundPerson.LastName = lastName;
                    if (foundPerson.Age != age)
                        foundPerson.Age = age;
                    if (foundPerson.Phone != phone)
                        foundPerson.Phone = phone;
                }
                else
                    throw (new ArgumentException("Not all arguments for person are valid"));
            }
            else
                throw (new ArgumentException("Person with id = " + id + " not found"));
        }

        public void Remove(int id)
        {
            // Find the person in the internal persons list with same Id as the 'id'-parameter
            Person foundPerson = this.Get(id);

            if (foundPerson != null)
                persons.Remove(foundPerson);
            else
                throw (new ArgumentException("Person with id = " + id + " not found"));
        }

    }
}
