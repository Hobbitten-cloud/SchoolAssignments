using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern
{

    public delegate void NotifyHandler();

    public class Academy : Organization, INotifyPropertyChanged
    {
        // public event EventHandler MessageChanged;

        public event PropertyChangedEventHandler PropertyChanged;

        // private List<IObserver> students = new List<IObserver>();

        private string _message;

        public string Message
        {
            get { return _message; }
            set
            {
                _message = value;
                //MessageChanged.Invoke();
                OnMessageChanged();
            }
        }

        public Academy(string name, string address) : base(name)
        {
            this.Address = address;
        }

        //public void Attach(IObserver o)
        //{
        //    //students.Add(o);

        //    Students += o.Update; // Chaining
        //}

        //public void Detach(IObserver o)
        //{
        //    //students.Remove(o);

        //    Students -= o.Update; // Unchaining
        //}

        public void OnMessageChanged()
        {
            //foreach (IObserver o in students)
            //{
            //    o.Update();
            //}

            //Students.Invoke();

            PropertyChanged(this, null);

        }
    }
}
