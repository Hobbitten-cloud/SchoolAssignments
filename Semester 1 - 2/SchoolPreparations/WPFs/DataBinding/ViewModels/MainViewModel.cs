using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWPF.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
		private string firstName = "Gede";
		public string FirstName
		{
			get { return firstName; }
			set 
            { 
                firstName = value; 
                OnPropertyChanged("FirstName");
                OnPropertyChanged("FullName");

            }
		}

        private string lastName = "Bukken";


        public string LastName
        {
            get { return lastName; }
            set 
            { 
                lastName = value;
                OnPropertyChanged("LastName");
                OnPropertyChanged("FullName");
            }
        }

        public string FullName
        {
            get { return firstName + " " + LastName; }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }

        }
    }
}
