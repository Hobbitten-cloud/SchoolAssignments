namespace Encryption
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool continueProgram = true;

            Method method = new Method();

            while (continueProgram == true)
            {
                Console.Clear();
                Console.WriteLine("Wwrite 0 to exit");
                Console.Write("Write a number: ");
                uint userInput = Convert.ToUInt32(Console.ReadLine());

                if (userInput == 0)
                {
                    continueProgram = false;
                    Environment.Exit(0);
                }

                method.IsPrime(userInput);
                Console.WriteLine();
                Console.Write("Press anything to continue");
                Console.ReadLine();
            }
        }
    }
}
