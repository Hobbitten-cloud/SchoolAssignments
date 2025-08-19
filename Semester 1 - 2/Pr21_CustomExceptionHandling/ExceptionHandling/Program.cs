using TotallySafeLib;

namespace CustomExceptionHandling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // En fin lille menu
            Console.WriteLine("Vælg hvad du vil: ");
            Console.WriteLine("1: Divider");
            Console.WriteLine("2: String to int");
            Console.WriteLine("3: Index array test");
            Console.WriteLine();
            Console.Write("Skriv her: ");
            string userInput = Console.ReadLine();

            // Mellemrum for nedenstående informationer
            Console.WriteLine();

            // Tjekker hvad userInput er via det forskellife IFs
            if (userInput == "1") // Udfører divition
            {
                try
                {
                    double posValue = TotallySafe.Divider(3); // Du kan dividere med 0 for at få fejl
                    Console.WriteLine("Din divition virkede");
                    Console.WriteLine(posValue);
                }
                catch (DivideByZeroException ex) // Laver en divition med 0 exception
                {
                    Console.WriteLine(ex.Message); // Udskriver fejlen
                }
            }
            if (userInput == "2") // Udfører string to int
            {
                try
                {
                    int posValue = TotallySafe.StringToInt("3"); // For at lave fejl skriv et ord / bogstaver
                    Console.WriteLine("Din string to int konvention virkede");
                    Console.WriteLine(posValue);
                }
                catch (FormatException ex) // laver en format exception
                {
                    Console.WriteLine(ex.Message); // Udskriver fejlen
                }
            }
            if (userInput == "3") // Udfører array test
            {
                try
                {
                    int posValue = TotallySafe.GetValueAtPosition(-2); // 8 Du kan skrive en værdi som er større end den array længde angivet
                    Console.WriteLine("Din din index værdi virkede");
                    Console.WriteLine(posValue);
                    Console.ReadLine();
                }
                catch (NegativeIndexOutOfRangeException ex) // laver vores custom exception kald
                {
                    Console.WriteLine(ex.Message); // Udskriver fejlen
                }
                catch (IndexOutOfRangeException ex) // laver en indexOutOfRange exception
                {
                    Console.WriteLine(ex.Message); // Udskriver fejlen
                }
            }
            Console.ReadLine();
        }
    }
}
