using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPFNavigation02.Services;
using WPFNavigation02.Stores;
using WPFNavigation02.Commands;
using WPFNavigation02.Models;

namespace WPFNavigation02.ViewModels
{
    public class PersonListViewModel : BaseViewModel
    {
        private readonly PersonService _personService;
        public ObservableCollection<PersonViewModel> PersonsVM { get; set; }

        public ICommand NavigateAddPersonViewCommand { get; set; }

        public PersonListViewModel(NavigationStore navigationStore, PersonService personService)
        {
            NavigateAddPersonViewCommand = new NavigateCommand(new NavigationService(navigationStore, () => new AddPersonViewModel(navigationStore, personService)));
            _personService = personService;
            GetPersonsVM();

        }
        public ObservableCollection<PersonViewModel> GetPersonsVM() 
        {
            PersonsVM = new ObservableCollection<PersonViewModel>();
            foreach (Person person in _personService.GetAll()) 
            {
                PersonViewModel personVM = new PersonViewModel(person);
                PersonsVM.Add(personVM);    
            }
            return PersonsVM;
        }
    }
}
