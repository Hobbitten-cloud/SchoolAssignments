using System;
using System.Collections.Generic;
using System.Threading.Tasks;

internal class Program
{
    static void Main(string[] args)
    {
        Program p = new Program();

        // Kører metoden Getfactors på en baggrundstråd
        Task.Run(() => p.GetFactors(200))
            // Når Task er færdig udskrives resultatet
            .ContinueWith(t =>
            {
                Console.WriteLine("Faktorer:");

                // t.Result indeholder listen af faktorer
                foreach (var f in t.Result)
                {
                    Console.Write(f + " ");
                }
            });

        Console.ReadLine(); // Holder programmet åbent
    }

    // Metode der finder alle faktorer af et positivt tal
    public List<ulong> GetFactors(ulong number)
    {
        var factors = new List<ulong>(); // Liste til at gemme faktorer

        // Loop fra 1 til 'number'
        for (ulong i = 1; i <= number; i++)
        {
            // Hvis i går op i number er det en faktor
            if (number % i == 0)
            {
                factors.Add(i); // Tilføj faktor til listen
            }
        }

        return factors; // Returner den færdige liste
    }
}
