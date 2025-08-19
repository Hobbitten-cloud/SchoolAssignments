namespace ShowCasePersistence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Vi beder brugeren om at skrive noget
            Console.Write("Hello please write something: ");
            string userinput = Console.ReadLine();

            // Du laver if statementet for at tjekke om brugeren først har filen. Hvis filen ikke eksisitere laver den filen
            // Læg mærke til ! som gør det modsatte
            if (!File.Exists("GemFil.txt"))
            {
                using (StreamWriter sw = File.CreateText("GemFil.txt"))
                {
                    // For at splitte ens data
                    // txt = ;
                    // csv = ,
                    
                    // json = not sure

                    // Du kan bruge hvilken som helst måde at splitte informationen på
                }
            }

            // Her gemmes filen i en .txt format det kunne også være .csv eller .json
            using (StreamWriter sw = new StreamWriter("GemFil.txt", false))
            {
                // Du skriver navnet på din StreamWriter "sw" og bruger writeline samt det du vil gemme i vores tilfælde userinput
                sw.Write(userinput + "hejsa");
                sw.Write(userinput);
                sw.Write(userinput);
                sw.Write(userinput);
                sw.Write(userinput);
            }
            
            // Mellemrum
            Console.WriteLine();

            // Feedback besked på at programmet er kørt igennem
            Console.WriteLine("Din information er nu gemt");

            Console.WriteLine();


            using (StreamReader sr = new StreamReader("GemFil.txt"))
            {
                Console.WriteLine("Din tekst er igang med at blive læst");
                foreach (var info in "GemFil.txt")
                {
                    Console.WriteLine(sr.ReadLine());
                }
            }

            
        }
    }
}
