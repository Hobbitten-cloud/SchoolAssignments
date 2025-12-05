using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynchronousExecutionAndAsynchronousExecution
{
    public class Assignment2
    {
        private const string URL = "https://docs.microsoft.com/en-us/dotnet/csharp";
        public async void Run()
        {
            DoSynchronousWork();


            var someTask =  DoAsynchronousWork();


            DoStuffWhileAwaiting();


            Console.Write("\nPress any key to terminate...");
            Console.ReadKey();
        }

        public void DoSynchronousWork()
        {
            Console.WriteLine("Doing some work synchronously...");
        }

        public async Task DoAsynchronousWork()
        {
            Console.WriteLine("Async work has started...");


            using (var httpClient = new HttpClient())
            {
                Console.WriteLine("Awaiting the result of GetStringAsync......");
                string result = await httpClient.GetStringAsync(URL);


                Console.WriteLine($"The awaited task has completed. +" +
                          $"Length of http: {result.Length} chars");
            }
        }

        public void DoStuffWhileAwaiting()
        {
            Console.WriteLine("While waiting for the async task to finish, " +
                        "do some unrelated work...");
            for (var i = 0; i <= 5; i++)
            {
                for (var j = i; j <= 5; j++)
                {
                    Console.Write("*");
                    Thread.Sleep(30);
                }
                Console.WriteLine();
            }
        }

    }
}
