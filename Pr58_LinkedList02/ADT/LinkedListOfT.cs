namespace ADT
{
    public class LinkedList<T> : ILinkedList<T>
    {
        private class Node
        {
            public Node Next { get; set; }
            public Node Previous { get; set; }
            public T Data { get; set; }
            public override string ToString()
            {
                return Data.ToString();
            }
        }

        private Node _head; // Den første node i listen.

        private int _count; // Antallet af elementer i listen.

        public int Count
        {
            get { return _count; }
        }

        public T First
        {
            get { return _count > 0 ? ItemAt(0) : default(T); }
        }

        public T Last
        {
            get { return _count > 0 ? ItemAt(Count - 1) : default(T); }
        }

        public void Insert(T o)
        {
            InsertAt(0, o);
        }

        public void Append(T o)
        {
            InsertAt(_count, o);
        }

        public void InsertAt(int index, T o)
        {
            Node newNode = new Node(); // Opretter en ny node med det givne objekt.
            newNode.Data = o;

            if (index == 0) // Hvis den ønskede placering er først i listen.
            {
                newNode.Next = _head; // Den nye node bliver den første i listen.
                newNode.Previous = null; // Den første node har ingen foregående node.

                if (_head != null) // Hvis listen ikke er tom...
                {
                    _head.Previous = newNode; // ...så skal den gamle første nodes Previous pege på den nye node.
                }

                _head = newNode; // Opdaterer head til at være den nye node.
            }
            else // Hvis den ønskede placering er et andet sted i listen.
            {
                Node current = _head; // Finder den node, der er lige før den ønskede placering.
                for (int i = 0; i < index - 1; i++)
                {
                    current = current.Next; // Går videre til næste node.
                }

                newNode.Next = current.Next; // Den nye node sættes til at pege på den næste node.
                newNode.Previous = current; // Den nye nodes Previous peger på den foregående node (current).

                if (current.Next != null) // Hvis der findes en node efter den nye node...
                {
                    current.Next.Previous = newNode; // ...skal dens Previous opdateres til at pege på den nye node.
                }

                current.Next = newNode; // Den foregående node sættes til at pege på den nye node.
            }

            _count++; // Øger antallet af elementer i listen.
        }


        public void DeleteAt(int index)
        {
            if (index < 0 || index >= _count) // Hvis index er uden for listen, kastes en undtagelse.
            {
                throw new IndexOutOfRangeException("Slemme slemme fy fy næ næ nix nix, slut forbudt! Ugyldig sletning!");
            }

            if (index == 0) // Hvis den ønskede placering er først i listen.
            {
                if (_head != null) // Hvis listen ikke er tom.
                {
                    _head = _head.Next; // Fjerner den første node fra listen.
                    _head.Previous = null;
                }
            }
            else // Hvis den ønskede placering er et andet sted i listen.
            {
                Node current = _head; // Finder den node, der er lige før den ønskede placering.
                for (int i = 0; i < index - 1; i++)
                {
                    current = current.Next;
                }

                if (current.Next != null) // Hvis den næste node findes.
                {
                    current.Next = current.Next.Next; // Fjerner den ønskede node fra listen.

                    if (current.Next != null)
                    {
                        current.Next.Previous = current;
                    }
                }

            }
            _count--; // Reducerer antallet af elementer i listen.
        }

        public T ItemAt(int index)
        {
            if ((index < 0) || (index + 1 > _count)) // Hvis index er uden for listen, kastes en undtagelse.
            {
                throw new IndexOutOfRangeException("Fy fy skamme skamme fy fy ah ah. Kan du ikke finde her!");
            }

            Node nodeToFind = _head; // Opretter en variabel til at traversere listen.
            int i = 0;

            while (nodeToFind != null) // Traverserer listen indtil den ønskede placering.
            {
                if (i == index) // Hvis den ønskede placering er nået, afbrydes løkken.
                {
                    break;
                }

                i++;
                nodeToFind = nodeToFind.Next; // Går til næste node i listen.
            }

            return nodeToFind.Data; // Returnerer data fra den ønskede node.
        }

        public void Swap(int index)
        {
            // Først tjekker vi, om det angivne index er gyldigt.
            // Vi må ikke være uden for listen (dvs. negativt index eller sidste element),
            // fordi man ikke kan bytte det sidste element (der findes ingen "nabo" efter det).
            if (index < 0 || index >= _count - 1)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Index er ugyldigt eller der findes ikke et efterfølgende element.");
            }

            // Vi starter fra _head og går frem til den node, vi skal bytte (den første af de to).
            Node first = _head;
            for (int i = 0; i < index; i++)
            {
                first = first.Next;
            }

            // Nu har vi fundet noden ved 'index'. Den kalder vi 'first'.
            // Dens næste node er den, vi vil bytte med. Den kalder vi 'second'.
            Node second = first.Next;

            // Vi gemmer også henvisninger til de noder, der ligger før og efter de to noder vi vil bytte.
            Node prev = first.Previous; // Noden før 'first'. Kan være null hvis first er _head.
            Node next = second.Next;    // Noden efter 'second'. Kan være null hvis second er den sidste node.

            // Nu begynder vi at opdatere forbindelserne (pegerne).

            // Hvis der findes en node før 'first'...
            if (prev != null)
            {
                prev.Next = second; // ...så skal den nu pege frem på 'second' (i stedet for 'first').
            }
            else
            {
                _head = second;     // Hvis 'first' var den første node (_head), så er 'second' nu den nye head.
            }

            // Hvis der findes en node efter 'second'...
            if (next != null)
            {
                next.Previous = first; // ...så skal den nu pege tilbage på 'first' (i stedet for 'second').
            }

            // Nu opdaterer vi selve forbindelserne mellem 'first' og 'second'.

            second.Previous = prev; // 'second' peger nu tilbage på det samme som 'first' gjorde før.
            second.Next = first;    // 'second' peger frem på 'first'.

            first.Previous = second; // 'first' peger nu tilbage på 'second'.
            first.Next = next;       // 'first' peger frem på den node, som 'second' tidligere pegede på.

            // Resultatet er, at 'first' og 'second' har byttet plads i kæden,
            // og alle omkringliggende noder er korrekt opdateret.
        }


        public override string ToString()
        {
            string result = ""; // Streng til at samle data fra hver node.

            Node temp = _head; // Opretter en variabel til at traversere listen.
            while (temp != null) // Traverserer listen indtil slutningen.
            {
                if (result == "") // Hvis resultatet er tomt, indsættes data fra den første node.
                {
                    result = temp.Data.ToString();
                }
                else // Hvis resultatet ikke er tomt, tilføjes data fra den næste node på en ny linje.
                {
                    result = result + "\n" + temp.Data.ToString();
                }

                temp = temp.Next; // Går til næste node i listen.
            }
            return result; // Returnerer resultatet, der indeholder data fra alle noder i listen.
        }
    }
}