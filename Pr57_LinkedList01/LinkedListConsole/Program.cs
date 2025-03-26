namespace LinkedListConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("LinkedList Trials ...");
            Console.WriteLine();

            // Instantiate a new list
            LinkedList list = new LinkedList();

            // Insert different types of elements into the list at specific indices
            list.InsertAt(0, 123);
            list.InsertAt(1, "This is a LinkedList test");
            list.InsertAt(2, 456.75);
            list.InsertAt(3, new ClubMember { FirstName = "Donald", LastName = "Duck", Age = 90, Gender = Gender.Male, Id = 1 });

            // Output the entire list to the console
            Console.WriteLine("** list.ToString() **");
            Console.WriteLine(list.ToString());
            Console.WriteLine();

            // Output individual elements using ItemAt() by index
            Console.WriteLine("** list.ItemAt() **");
            Console.WriteLine("Item at 2: " + list.ItemAt(2));
            Console.WriteLine("Item at 0: " + list.ItemAt(0));
            Console.WriteLine("Item at 3: " + list.ItemAt(3));
            Console.WriteLine();

            // Delete an element at index 2 and display the updated list
            Console.WriteLine("** list.DeleteAt(2) **");
            list.DeleteAt(2);
            Console.WriteLine("List after deletion:");
            Console.WriteLine(list.ToString());
            Console.WriteLine();

            // Delete an element at index 0 and display the updated list
            Console.WriteLine("** list.DeleteAt(0) **");
            list.DeleteAt(0);
            Console.WriteLine("List after deletion:");
            Console.WriteLine(list.ToString());
            Console.WriteLine();

            // Trying to access an invalid index (-3) and catch exception
            Console.WriteLine("** Invalid index: list.ItemAt(-3) **");
            try
            {
                Console.WriteLine("Item at -3: " + list.ItemAt(-3));
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine("Caught IndexOutOfRangeException: " + e.Message);
            }
            Console.WriteLine();

            // Trying to access an invalid index (6) and catch exception
            Console.WriteLine("** Invalid index: list.ItemAt(6) **");
            try
            {
                Console.WriteLine("Item at 6: " + list.ItemAt(6));
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine("Caught IndexOutOfRangeException: " + e.Message);
            }
            Console.WriteLine();

            // Insert a new element at index 2 and display the updated list
            list.InsertAt(2, new ClubMember { FirstName = "Pickle", LastName = "Rick", Age = 70, Gender = Gender.Male, Id = 2 });

            // Output the entire list again to the console
            Console.WriteLine("** list.ToString() **");
            Console.WriteLine(list.ToString());
            Console.WriteLine();

            // Navigate through the node structure using Head and print specific node data
            Console.WriteLine("** Navigate Node-structure via Head and write to console **");
            Console.WriteLine("list.Head.Next.Next.Data: " + list.Head.Next.Next.Data);
            Console.WriteLine();

            Console.WriteLine("All Trials Completed");
            Console.ReadLine();

        }
    }
}
