namespace char_array_test
{
    internal class char_array_test
    {
        static void Main(string[] args)
        {
            // Bool sættes op for loopet kan afsluttes
            bool FullName = false;

            // Vi initialiser vores array name. Der dog ikke nogen string arrays angivet endnu men det får vi fra bruger inputtet.
            string[] name = {};

            // Kører et loop indtil det bliver sandt
            while (FullName == false)
            {
                // Brugeren skriver deres navn ind
                Console.Write("Write your name: ");

                // Konsol vinduet bliver læst af vores method "readline" som efter bliver lavet til lowercase og derefter bliver værdien gemt i en array
                // ReadLine returns "Hello World" -> ToLower returns "hello world" -> Split returns {"hello", "world"}
                name = Console.ReadLine().ToLower().Split(' ');

                // Tjekker om name er mindre end 2 og hvis det er bliver dette kørt
                if (name.Length < 2)
                {
                    Console.WriteLine();
                    Console.WriteLine("ERROR - You have to write your full name!");

                    // Continue er et jumpstatement og hopper til starten af ens loop som kører
                    continue;
                }

                // Afslutter loopet
                FullName = true;
            }

            // Udgangspunkt i {"hello", "world"} foroven. hello er index 0 så name[0] og [0] er det første char index som er h i dette tilfælde mens name[0][1] vil være e.
            // Samt hvis du vil røre ved world skal du hen i den anden string som er name[1] og dens første bogstav er [0] så name[1][0] og andet bogstav name[1][1] vil være o 
            // Bare for at tage et videre gående eksempel så for at få r i world ville det være name[1][2] osv.
            Console.WriteLine("Your username is: " + name[0][0] + name[0][1] + name[1][0] + name[1][1]);


        }
    }
}
