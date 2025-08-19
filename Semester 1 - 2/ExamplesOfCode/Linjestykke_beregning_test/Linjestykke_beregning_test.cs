namespace Linjestykke_beregning_test
{
    internal class Linjestykke_beregning_test
    {
        static void Main(string[] args)
        {
            // Indtastning af variablerne
            string x1, x2, y1, y2;
            double Doublex1, Doublex2, Doubley1, Doubley2;

            // Brugeren skriver x1 ind
            Console.Write("Indtast hvad x1 er: ");
            x1 = Console.ReadLine();
            Doublex1 = double.Parse(x1);

            // Brugeren skriver y1 ind
            Console.Write("Indtast hvad y1 er: ");
            y1 = Console.ReadLine();
            Doubley1 = double.Parse(y1);

            // Brugeren skriver x2 ind
            Console.Write("Indtast hvad x2 er: ");
            x2 = Console.ReadLine();
            Doublex2 = double.Parse(x2);

            // Brugeren skriver y2 ind
            Console.Write("Indtast hvad y2 er: ");
            y2 = Console.ReadLine();
            Doubley2 = double.Parse(y2);

            // Her sætter vi resultatet op mod hinanden og giver det direkte til brugeren
            Console.WriteLine();
            double result = (Doubley2 - Doubley1) / (Doublex2 - Doublex1);
            Console.WriteLine("Resultatet er: " + result);
        }
    }
}
