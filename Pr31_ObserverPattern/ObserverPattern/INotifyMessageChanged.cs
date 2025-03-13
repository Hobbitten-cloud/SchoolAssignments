using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern
{
    public interface INotifyMessageChanged
    {
        public event EventHandler MessageChanged;
    }
}
