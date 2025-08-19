using System;
using System.IO;

namespace test_kodning_med_test
{
    internal class test_kodning_med_test
    {
        static void Main(string[] args)
        {
            // Fil sti til hvor du gemmer filen
            string path = @"C:\Users\nickl\OneDrive\Desktop\Datamatiker_Projects\gemfiler\datainformation.txt";

            // Læs hele filens indhold som en streng
            string fileContent = File.ReadAllText(path);
            Console.WriteLine("Indhold af filen:");
            Console.WriteLine();
            Console.WriteLine(fileContent);

            // Check ind tid & Farver konsol tekst med grøn farve
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Skriv dit navn for at tjekke ind: ");

            // Fjerner farven så den bliver hvid igen
            Console.ResetColor();
            
            string userInput = Console.ReadLine();
            DateTime CheckInd = DateTime.Now;
            string CheckIndContent = CheckInd.ToString();
            Console.WriteLine(userInput + ", du har registreret din ankomst kl. " + CheckInd);

            // Gemmer brugerens navn og check-in tid
            File.WriteAllText(path, "Navn: " + userInput); // Overskriver med navn
            File.AppendAllText(path, "\n"); // Tilføjer ny linje
            File.AppendAllText(path, "Check ind tid: " + CheckIndContent); // Tilføjer check-in tid
            File.AppendAllText(path, "\n"); // Ny linje
            File.AppendAllText(path, "\n"); // Ny linje
            Console.WriteLine("Check-in informationerne er blevet gemt.");

            // Mellemrum
            Console.WriteLine();

            // Check ud tid
            Console.WriteLine();
            Console.Write("Skriv dit navn igen for at tjekke ud: ");
            userInput = Console.ReadLine(); // Bruger tjekker ud
            DateTime CheckUd = DateTime.Now;
            string CheckUdContent = CheckUd.ToString();
            Console.WriteLine(userInput + ", du har registreret din forladelsestid kl. " + CheckUd);

            // Tilføjer check-ud information til filen
            File.AppendAllText(path, "Navn: " + userInput); // Tilføjer navn igen ved check-ud
            File.AppendAllText(path, "\n"); // Ny linje
            File.AppendAllText(path, "Check ud tid: " + CheckUdContent); // Tilføjer check-ud tid
            File.AppendAllText(path, "\n"); // Ny linje
            Console.WriteLine("Check-ud informationerne er blevet gemt.");
        }
    }
}