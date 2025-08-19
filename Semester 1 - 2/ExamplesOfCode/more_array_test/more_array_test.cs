namespace more_array_test
{
    internal class more_array_test
    {
        static void Main(string[] args)
        {
            // vores array laves og har 5 indexes som går fra 0, 1, 2, 3, 4
            int[] arraytest = new int[5];

            // Bool som tjekker om noget er sandt eller falsk
            bool ExitTry = false;

            // Loopet vil køre indtil at ExitTry bliver sand (true)
            while (ExitTry == false)
            {
                // Tjekker koden om der sker fejl af bruger inputs såsom at skrive med bogstaver.
                // Hvis fejl sker så slettes i værdien og starter forfra
                try
                {
                    // i = 0 som resetter værdien, i < arraytest.Length checker om i er mindre end arraytest og forøger sig selv
                    for (int i = 0; i < arraytest.Length; i++)
                    {
                        // Vi spørger brugeren om at skrive noget ind
                        Console.Write("Please write different numbers 5 times: ");

                        // Vi gemmer deres input
                        string UserInput = Console.ReadLine();

                        // Vi konventere deres input til et heltal
                        arraytest[i] = int.Parse(UserInput);
                    }
                    // Når for loppet er færdig vil ExitTry blive til true og afslutte og gå videre.
                    ExitTry = true;
                }
                // Fanger fejl med bogstaver og andre karakterer
                catch (FormatException agurk)
                {
                    Console.WriteLine();
                    Console.WriteLine(agurk.Message); // Udskriver den default error message. Kunne også skrives "Brug tal kun tak"
                    Console.WriteLine();
                }
            }

            // Mellemrum
            Console.WriteLine();

            // i = 0 som resetter værdien, i < arraytest.Length checker om i er mindre end arraytest og forøger sig selv
            for (int i = 0; i < arraytest.Length; i++)
            {
                // Printer alle index værdierne ud til konsole vinduet som der er i arrayen
                Console.WriteLine("Værdi: " + arraytest[i]);
            }

            // Mellemrum
            Console.WriteLine();

            // Viser alle ens tal på hele linjen
            Console.WriteLine("Alletal på samme linje: " + arraytest[0] + arraytest[1] + arraytest[2] + arraytest[3] + arraytest[4]);

            // Mellemrum
            Console.WriteLine();

            // Gør at programmet ikke afslutter
            Console.Write("Press any key to exit the program: ");
            Console.ReadKey();
            Console.WriteLine();
        }
    }
}