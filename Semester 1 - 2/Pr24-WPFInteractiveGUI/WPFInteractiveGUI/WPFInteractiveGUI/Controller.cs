using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFInteractiveGUI
{
    public class Controller
    {
        private PersonRepository personRepo;
        public Person CurrentPerson { get; private set; }
        public int PersonCount { get; private set; }
        public int PersonIndex { get; private set; }

        public Controller()
        {
            CurrentPerson = null;
            personRepo = new PersonRepository();
            PersonCount = 0;
            PersonIndex = -1;
        }

        public void AddPerson()
        {
            Person person = new Person();
            CurrentPerson = person;
            personRepo.AddPerson(person);
            PersonCount = personRepo.Count;
            PersonIndex = PersonCount - 1;
        }

        public void DeletePerson()
        {
            if (CurrentPerson != null)
            {
                personRepo.RemovePerson(CurrentPerson);
                
                PersonCount = personRepo.Count;
                if (PersonIndex == PersonCount) // Vi har slettet bagerste person i repositoriet
                {
                    PersonIndex--;
                }

               CurrentPerson = personRepo.GetPersonAtIndex(PersonIndex);
            }
        }

        public void NextPerson()
        {
            if (PersonIndex < PersonCount - 1)
            {
                PersonIndex++;
                CurrentPerson = personRepo.GetPersonAtIndex(PersonIndex);
            }
        }
        public void PrevPerson()
        {
            if (PersonIndex > 0)
            {
                PersonIndex--;
                CurrentPerson = personRepo.GetPersonAtIndex(PersonIndex);
            }
        }


    }
}
