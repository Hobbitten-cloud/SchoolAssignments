namespace skriv_med_farve_test
{
    internal class skriv_med_farve_test
    {
        static void Main(string[] args)
        {
            // Skift farven på teksten til rød
            Console.Write("Skriv dit navn: ");
            string userInput = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Red; // Skift tekstfarven til rød
            Console.WriteLine("Hej " + userInput + ", din tekst er nu rød!");

            // Skift farven tilbage til standard (grå eller det som standarden er sat til)
            Console.ResetColor();

            Console.WriteLine("Nu er farven tilbage til normal.");
        }
    }
}
