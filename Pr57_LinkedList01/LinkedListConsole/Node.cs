using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListConsole
{
    public class Node
    {
        public object? Data;
        public Node? Next;

        public override string ToString()
        {

            return Data.ToString();
        }
    }
}
