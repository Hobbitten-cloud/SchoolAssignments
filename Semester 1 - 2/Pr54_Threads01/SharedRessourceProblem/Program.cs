namespace SharedRessourceProblem
{
    internal class Program
    {
        private char _sharedChar; // The shared resource and char is the simplest type to demonstrate the problem by using two threads
        private const int SIMULATE_WORK = 100; // The time to simulate work in milliseconds

        private readonly object _lock = new object();

        static void Main(string[] args) //Main Thread
        {
            Program p = new Program(); // Create an instance of the program
            p.Run(); // Run the program
        }

        public void Run() // Create two threads and start them
        {
            Thread tA = new Thread(WriteA); // Create a new thread and assign the method WriteA
            Thread tB = new Thread(WriteB); // Create a new thread and assign the method WriteB
            tA.Name = "Thread A"; // Set the name of the thread
            tB.Name = "Thread B"; // Set the name of the thread
            tA.Start(); // Start the thread
            tB.Start(); // Start the thread
            tA.Join();// Wait for the thread to finish
            tB.Join();// Wait for the thread to finish
            Console.Write("\nPress a key ...."); // Wait for a key to be pressed
            Console.ReadKey(); // Read the key
        }

        private void WriteA() // Write A to the shared resource and the ressource is shared between the two threads
        {
            lock (_lock)
            {
                for (int i = 0; i < 10; i++) // Loop 10 times
                {
                    _sharedChar = 'A'; // Set the shared resource to A
                    Thread.Sleep(SIMULATE_WORK);// Simulate work

                    // Write the shared resource to the console
                    Console.WriteLine($"{Thread.CurrentThread.Name} : {_sharedChar}");

                    //The yield method is used to signal to the system that the current thread is finished
                    // and another thread can be executed
                    Thread.Yield();
                }
            }
        }

        private void WriteB() // Write B to the shared resource and the ressource is shared between the two threads
        {
            lock (_lock)
            {
                for (int i = 0; i < 10; i++) // Loop 10 times
                {
                    _sharedChar = 'B'; // Set the shared resource to B

                    // Simulate work and the stimulate work is used to simulate the time it takes to write the shared resource
                    Thread.Sleep(SIMULATE_WORK);

                    // Write the shared resource to the console
                    Console.WriteLine($"{Thread.CurrentThread.Name} : {_sharedChar}");

                    //The yield method is used to signal to the system that the current thread is finished
                    // and another thread can be executed
                    Thread.Yield();
                }
            }
        }
    }
}
