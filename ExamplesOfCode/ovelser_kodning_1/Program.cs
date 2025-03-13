namespace ovelser_kodning_1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            bool kartofler = false;

            while (kartofler == false)
            {
                try
                {
                    Console.Write("Indtast nummer 1: ");
                    string userinput1 = Console.ReadLine();
                    double userinput1Int = double.Parse(userinput1);

                    Console.Write("Indtast nummer 2: ");
                    string userinput2 = Console.ReadLine();
                    double userinput2Int = double.Parse(userinput2);

                    double result = userinput1Int + userinput2Int;

                    Console.WriteLine(result);
                    kartofler = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine();
                    Console.WriteLine("Du er en gulerod fordi at du har skrevet bogstaver");
                }
            }
        }
    }
}
