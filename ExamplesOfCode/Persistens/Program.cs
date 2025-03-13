using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

namespace Persistens
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person("Anders Andersen", new DateTime(1975, 8, 24), 175.9, true, 3);

            DataHandler dataHandler = new DataHandler("Data.txt");
            dataHandler.SavePerson(person);

            Console.Write("Writing person: ");
            Console.WriteLine(person.MakeTitle());

            Person loadedPerson = dataHandler.LoadPerson();
            Console.Write("Reading person: ");
            Console.WriteLine(loadedPerson.MakeTitle());

            Console.ReadLine();
        }
    }
}