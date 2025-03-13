using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern
{
    public interface ISubject
    {

        public void Attach(IObserver o)
        {

        }

        public void Detach(IObserver o)
        {

        }

        public void Notify()
        {

        }

    }
}
