using System.ComponentModel.DataAnnotations;

namespace testkodning
{
    internal class testkodning
    {
        static void Main(string[] args)
        {
            // Brugeren skriver et ord ind
            Console.Write("Skriv et ord: ");
            string input = Console.ReadLine();

            // index er lig med 0 som start værdi
            int index = 0;

            // vi sætter length lig med det man skriver ind og dens længde
            int length = input.Length;

            while (index < length)
            {
                Console.WriteLine(index + ": " + input[index]); // Der sker en kontenering

                // Forøgelse af index med 1 kan skrives på mange måder index++, index += 1, ++index
                // Med andre ord vi inkremeringere index
                index = index + 1;
            }
            Console.ReadLine();
        }
    }
}
