using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using WPFAndMVVM2.Commands;
using WPFAndMVVM2.Models;

namespace WPFAndMVVM2.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private PersonRepository personRepo = new PersonRepository();

        public ObservableCollection<PersonViewModel> PersonsVM { get; set; } = new ObservableCollection<PersonViewModel>();

        public ICommand NewCmd { get; set; } = new NewCommand();
        public ICommand DeleteCmd { get; set; } = new DeleteCommand();

        public MainViewModel()
        {
            foreach (Person person in personRepo.GetAll())
            {
                PersonViewModel currentPersonVM = new PersonViewModel(person);
                PersonsVM.Add(currentPersonVM);
            }
        }


        public void AddDefaultPerson()
        {
            Person person = personRepo.Add("Specify FirstName", "Specify LastName", 0, "Specify Phone");
            PersonViewModel personViewModel = new PersonViewModel(person);
            PersonsVM.Add(personViewModel);
            SelectedPerson = personViewModel;
        }

        public void DeleteSelectedPerson()
        {
            if (SelectedPerson != null)
            {
                SelectedPerson.DeletePerson(personRepo);
                PersonsVM.Remove(SelectedPerson);
                // SelectedPerson = PersonsVM.LastOrDefault();
            }
        }

        private PersonViewModel _selectedPerson;
        public PersonViewModel SelectedPerson
        {
            get { return _selectedPerson; }
            set
            {
                _selectedPerson = value; OnPropertyChanged("SelectedPerson");

                // Another method to achieve the same result as above
                // _selectedPerson = value; OnPropertyChanged(nameof(SelectedPerson));
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if (propertyChanged != null)
            {
                propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
