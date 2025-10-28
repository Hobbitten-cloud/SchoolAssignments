namespace HashLearning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // My solution
            Hash hash = new Hash();

            // Teachers solution
            FromTeacher fromTeacher = new FromTeacher();

            // properties
            bool keepRunning = true;
            bool applicationRunning = true;
            string selectionInput = "";

            while (applicationRunning == true)
            {
                Console.WriteLine("Select what you want to do");
                Console.WriteLine("1: Student Solution: ");
                Console.WriteLine("2: Teacher Solution: ");
                Console.WriteLine();
                Console.Write("Your answer: ");
                selectionInput = Console.ReadLine();

                if (selectionInput == "1")
                {
                    Console.Clear();
                    while (keepRunning)
                    {
                        Console.Write("Enter password: ");
                        string userInput = Console.ReadLine();
                        hash.GetHashValue(userInput);
                        hash.GetSaltedHashValue(userInput);
                        Console.WriteLine();
                    }
                }
                else if (selectionInput == "2")
                {
                    Console.Clear();
                    fromTeacher.Run();
                }
                else
                {
                    Console.WriteLine("Invalid input, please try again.");
                }
            }
        }
    }
}
