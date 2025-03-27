using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADT
{
    public interface ILinkedList
    {
        int Count { get; }        
        void InsertAt(int index, object o);
        public void DeleteAt(int index);
        public object ItemAt(int index);
        public void Swap(int index);

        object First { get; }
        object Last { get; }
        void Insert(object o);
        void Append(object o);
    }
}
