using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynchronousExecutionAndAsynchronousExecution
{
    public class Assignment1
    {
        public void DoAssigment()
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();

            ExecuteTasksAsynchronously();
            timer.Stop();
            Console.WriteLine(timer.Elapsed + " Asynchronously Is now stopped");

            timer.Reset();

            ExecuteTasksSynchronously();
            timer.Stop();
            Console.WriteLine(timer.Elapsed + " Synchronously Is now stopped");
        }

        public void ExecuteTasksSynchronously()
        {
            for (int i = 0; i < 5; i++)
            {
                Task.Delay(2000).Wait(); // Simulate a 2-second task
                Console.WriteLine($"Task {i + 1} completed");
            }
        }

        public async Task ExecuteTasksAsynchronously()
        {
            List<Task> tasks = new List<Task>();

            for (int i = 0; i < 5; i++)
            {
                tasks.Add(Task.Delay(2000)); // Simulate a 2-second task
            }
            Task.WhenAll(tasks);
            Console.WriteLine("All tasks completed");
        }
    }
}
