using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Persistens
{
    public class DataHandler
    {
        public string DataFileName { get; }

        public DataHandler(string dataFileName)
        {
            this.DataFileName = dataFileName;
        }
        public void SavePerson(Person person)
        {
            using (StreamWriter sw = new StreamWriter(DataFileName))
            {
                sw.Write(person.MakeTitle());
            }
        }
        public Person LoadPerson()
        {
            using (StreamReader sr = new StreamReader(DataFileName))
            {
                // Læs linjen fra filen og split den på ";"
                string[] data = sr.ReadLine().Split(';');

                // Opret en ny Person baseret på de splittede data
                string name = data[0];
                DateTime birthDate = DateTime.Parse(data[1]);
                double height = double.Parse(data[2]);
                bool isMarried = bool.Parse(data[3]);
                int noOfChildren = int.Parse(data[4]);

                return new Person(name, birthDate, height, isMarried, noOfChildren);
            }
        }
        public void SavePersons(Person[] persons)
        {
            using (StreamWriter sw = new StreamWriter(DataFileName))
            {
                for (int i = 0; i < persons.Length; i++)
                {
                    sw.WriteLine(persons[i].MakeTitle());
                }
            }
        }
        public Person[] LoadPersons()
        {
            int count = 0;

            using (StreamReader sr = new StreamReader(DataFileName))
            {
                while (sr.ReadLine() != null)
                {
                    count++;
                }
            }

            Person[] persons = new Person[count];
            int i = 0;

            using (StreamReader sr = new StreamReader(DataFileName))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] list = line.Split(';');

                    persons[i] = new Person(list[0], DateTime.Parse(list[1]), double.Parse(list[2]), bool.Parse(list[3]), int.Parse(list[4]));
                    i++;
                }
            }

            return persons;
        }
    }
}
