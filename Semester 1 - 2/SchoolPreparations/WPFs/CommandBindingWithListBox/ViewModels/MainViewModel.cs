using CommandBindingWithListBox.Command;
using ListBox.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ListBox.ViewModels
{
    public class MainViewModel
    {
        public ObservableCollection<Person> Persons { get; set; } =
            new ObservableCollection<Person>
            {
                new Person { FirstName = "Ged", LastName = "Hejsa" },
                new Person { FirstName = "YEs", LastName = "Nea" },
                new Person { FirstName = "HEwahew", LastName = "GWEwagea" }
            };


        public Person SelectedPerson { get; set; }

        public ICommand NewCmd { get; set; } = new NewCommand();
        public ICommand DeleteCmd { get; set; } = new DeleteCommand();
    }
}
