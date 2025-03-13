using ListBox.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListBox.ViewModels
{
    public class MainViewModel
    {
        public List<Person> Persons { get; set; } =
            new List<Person>
            {
                new Person { FirstName = "Ged", LastName = "Hejsa" },
                new Person { FirstName = "YEs", LastName = "Nea" },
                new Person { FirstName = "HEwahew", LastName = "GWEwagea" }
            };


        public Person SelectedPerson { get; set; }


    }
}
