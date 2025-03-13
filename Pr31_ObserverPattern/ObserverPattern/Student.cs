using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern
{
    public class Student : Person, IObserver
    {
        // private Academy academy;

        private string _message;

        public string Message
        {
            get { return _message; }
            set 
            { 
                _message = value; 
            }
        }



        public Student(string name) : base(name)
        {
            // this.academy = academy;
        }


        public void Update(object sender, EventArgs e)
        {
            if (sender is Academy academy)
            {
                Message = academy.Message;
                Console.WriteLine($"Studerende {Name} modtog nyheden {Message} {academy.Name}");
            }
        }
    }
}
