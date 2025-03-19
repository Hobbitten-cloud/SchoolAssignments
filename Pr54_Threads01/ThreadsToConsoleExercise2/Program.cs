using System;

namespace ThreadsToConsoleExercise2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // WriteLine to console
            Thread thread1 = new Thread(WriteToConsole);
            thread1.Start(); // starts our thread
            thread1.Join(); // joins our thread in correct order

            // Lambda version
            Thread thread2 = new Thread(new ThreadStart(() =>
            {
                for (int i = 0; i < 4; i++)
                {
                    Console.WriteLine("Hello world (Lambda)");
                }
            }));
            thread2.Start(); // starts our thread
            thread2.Join(); // joins our thread in correct order

            // Delegate version aka anonymous way
            Thread thread3 = new Thread(new ThreadStart(delegate
            {
                for (int i = 0; i < 4; i++)
                {
                    Console.WriteLine("Hello world (Anonymous)");
                }
            }));
            thread3.Start(); // starts our thread
            thread3.Join(); // joins our thread in correct order


            // Static method for allowing the writing to console
            static void WriteToConsole()
            {
                for (int i = 0; i < 4; i++)
                {
                    Console.WriteLine("Hello world (Metode)");
                }
            }
        }
    }
}
