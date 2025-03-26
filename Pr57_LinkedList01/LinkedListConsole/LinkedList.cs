using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListConsole
{
    public class LinkedList
    {
        // Head points to the first node in the linked list
        public Node? Head;

        // Keeps track of the number of nodes in the list
        public int Count = 0;

        public void InsertAt(int index, Object o)
        {
            // Create a new node with the given data
            Node newNode = new Node { Data = o };

            // If inserting at the head (index 0), update Head reference
            if (index == 0)
            {
                newNode.Next = Head;
                Head = newNode;
            }
            else
            {
                // Traverse to the node just before the desired index
                Node current = Head;
                for (int i = 0; i < index - 1 && current != null; i++)
                {
                    current = current.Next;
                }

                // Insert the new node in the list
                newNode.Next = current.Next;
                current.Next = newNode;
            }

            // Increase the count of elements
            Count++;
        }

        public void DeleteAt(int index)
        {
            // If deleting the head node
            if (index == 0)
            {
                Head = Head.Next;
            }
            else
            {
                // Traverse to the node just before the one to delete
                Node current = Head;
                for (int i = 0; i < index - 1; i++)
                {
                    current = current.Next;
                }

                // Skip the node to be deleted
                current.Next = current.Next?.Next;
            }

            // Decrease the count of elements
            Count--;
        }

        public object ItemAt(int index)
        {
            // Check for invalid index
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException();
            }

            // If list is empty, return null (though this is redundant after the index check)
            if (Head == null)
            {
                return null;
            }

            // Traverse to the node at the given index
            Node current = Head;
            for (int i = 0; i < index && current != null; i++)
            {
                current = current.Next;
            }

            // Return the node at the given index
            return current;
        }

        public override string ToString()
        {
            // Start from the head of the list
            Node current = Head;

            // Start building the string from the first node
            string dataString = current.ToString();
            current = current.Next;

            // Append each node's string representation
            while (current != null)
            {
                dataString += "\n" + current.ToString();
                current = current.Next;
            }

            // Return the complete string
            return dataString;
        }

    }
}
