using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFNavigation02.Models;

namespace WPFNavigation02.ViewModels
{
    public class PersonViewModel : BaseViewModel
    {
        private Person person; 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public PersonViewModel(Person person)
        {
            this.person = person;
            FirstName = person.FirstName; 
            LastName = person.LastName;
            Age = person.Age;
        }
    }
}
