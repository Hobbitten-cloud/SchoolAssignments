using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADT
{
    public interface ILinkedList<T>
    {
        int Count { get; }        
        void InsertAt(int index, T o);
        public void DeleteAt(int index);
        public T ItemAt(int index);
        public void Swap(int index);

        T First { get; }
        T Last { get; }
        void Insert(T o);
        void Append(T o);
    }
}
