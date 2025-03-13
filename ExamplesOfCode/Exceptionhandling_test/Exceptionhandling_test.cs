namespace Exceptionhandling_test
{
    internal class Exceptionhandling_test
    {
        static void Main(string[] args)
        {
            // Exceptions = er fejl som sker mens programmet kører

            // Integers
            int x;
            int y;
            int result;


            // try = prøver noget kode som kan være farligt for brugeren at udføre såsom at skrive bogstav ind et sted hvor vi kun vil have tal
            try
            {
                Console.Write("Enter number 1: ");
                x = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter number 2: ");
                y = Convert.ToInt32(Console.ReadLine());

                result = x / y;

                Console.WriteLine("Result: " + result);
            }
            // catch = Fanger fejlen og laver noget
            // Her fanger den problemer med bogstaver
            catch (FormatException e)
            {
                Console.WriteLine("ENTER ONLY NUMBERS PLEASE!");
            }
            // Her fanger den problemer med folk som prøver at dividere med 0
            catch (DivideByZeroException)
            {
                Console.WriteLine("You cannot divide with 0");
            }
            // Her fanger den alt men den er svær at give feedback tilbage til brugeren hvis brugt
            catch (Exception)
            {
                Console.WriteLine("Something went wrong!");
            }
            // finally = Bliver altid udført til sidst. Det lige gyldigt om fejlen fanges eller ej
            finally
            {
                Console.WriteLine();
                Console.WriteLine("Program has now finished");
            }
        }
    }
}
