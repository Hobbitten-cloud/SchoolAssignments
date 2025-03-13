namespace array_and_for_test
{
    internal class array_and_for_test
    {
        // Overordnet sagt er dette en funktion som kan kaldes istedet for at skrive den samme ting ind flere gange.
        private static bool IsTheNameInsideTheDatabase(string name, string[] database)
        {
            // Int i variablen laves
            // i < names.length kan ikke være større end array listen
            // For hvert loop bliver i størrer med 1 ved brug af += eller i++
            for (int i = 0; i < database.Length; i++)
            {
                string selected = database[i];
                if (selected == name)
                {
                    return true;
                }
            }
            return false;
        }

        // Vores main kode
        static void Main(string[] args)
        {
            // Array med arbejderne fra firmaet
            // Tælles fra 0, 1, 2, 3, 4, 5
            string[] names = ["Jakob", "Linda", "Ida", "Jonas", "Bob", "Nicklas"];

            // Gemmer hvad brugeren af programmet skriver ind
            Console.Write("Enter a name to continue: ");
            string name = Console.ReadLine();


            // Bool laves for at tjekke om personen eksisterer i firmaet. Vi kalder derfor funktionen foroven i det tidligere method
            bool found = array_and_for_test.IsTheNameInsideTheDatabase(name, names);
            if (found == true)
            {
                // Hvis brugeren eksisterer i names array så sker dette
                Console.WriteLine("Login successful");
                Console.WriteLine("Welcome " + name);
            }
            else
            {
                // Hvis brugeren ikke eksisterer i names array så sker dette
                Console.WriteLine();
                Console.WriteLine("Login Failed");
                Console.WriteLine("User was not found in the database");
            }
        }
    }
}
