namespace Lommeregner
{
    public class Calculator
    {
        public int Add(int xAdd, int yAdd)
        {
            return xAdd + yAdd;
        }
        public int Subtract(int xSubtract, int ySubtract)
        {
            return xSubtract - ySubtract;
        }
        public double Divide(double xDivide, double yDivide)
        {
            if (xDivide == 0 || yDivide == 0)
            {
                Console.WriteLine("Du kan ikke dividere med 0 så derfor vil resultatet altid blive 0");
                Console.WriteLine();
            }
            else
            {
                return xDivide / yDivide;
            }
            return 0;
        }
        public int Multiply(int xMultiply, int yMultiply)
        {
            return xMultiply * yMultiply;
        }
        static void Main(string[] args)
        {
            // Opsættelse af variablen bool
            bool beregning = false;

            // Laver et do while loop for at bruge lommeregnen
            do
            {
                // Sætter vores if statement menu up med bruger inputtet 1,2,3,4
                Console.WriteLine("Hvad vil du beregne?\n1: +\n2: -\n3: /\n4: *\n");
                Console.Write("Indtast hvad du vil skrive her: ");

                // Gemmer hvad brugeren skriver ind
                string input = Console.ReadLine();


                Calculator regneren = new Calculator();
                

                if (input == "1" || input == "+")
                {
                    Console.Clear();
                    Console.WriteLine("Du har valgt at lægge tal sammen");
                    Console.WriteLine();

                    // X delen for input
                    Console.Write("Indtast x: ");
                    string inputXAdd = Console.ReadLine();
                    int inputxAdd = int.Parse(inputXAdd);

                    // Mellemrum
                    Console.WriteLine();

                    // Y delen for input
                    Console.Write("Indtast y: ");
                    string inputYAdd = Console.ReadLine();
                    int inputyAdd = int.Parse(inputYAdd);

                    // Her bliver regnestykket udregnet
                    Console.WriteLine();
                    Console.WriteLine("Regnestykket er: " + regneren.Add(inputxAdd, inputyAdd));
                    beregning = true;
                    Console.WriteLine();
                }
                else if (input == "2" || input == "-")
                {
                    Console.Clear();
                    Console.WriteLine("Du har valgt at minus tal sammen");

                    // X delen for input
                    Console.Write("Indtast x: ");
                    string inputXMinus = Console.ReadLine();
                    int inputxMinus = int.Parse(inputXMinus);

                    // Mellemrum
                    Console.WriteLine();

                    // Y delen for input
                    Console.Write("Indtast y: ");
                    string inputYMinus = Console.ReadLine();
                    int inputyMinus = int.Parse(inputYMinus);

                    // Her bliver regnestykket udregnet
                    Console.WriteLine();
                    Console.WriteLine("Regnestykket er: " + regneren.Subtract(inputxMinus, inputyMinus));
                    beregning = true;
                    Console.WriteLine();
                }
                else if (input == "3" || input == "/")
                {
                    Console.Clear();
                    Console.WriteLine("Du har valgt at dividere tal sammen");

                    // X delen for input
                    Console.Write("Indtast x: ");
                    string inputXDividere = Console.ReadLine();
                    int inputxDividere = int.Parse(inputXDividere);

                    // Mellemrum
                    Console.WriteLine();

                    // Y delen for input
                    Console.Write("Indtast y: ");
                    string inputYDividere = Console.ReadLine();
                    int inputyDividere = int.Parse(inputYDividere);

                    // Her bliver regnestykket udregnet
                    Console.WriteLine();
                    Console.WriteLine("Regnestykket er: " + regneren.Divide(inputxDividere, inputyDividere));
                    beregning = true;
                    Console.WriteLine();
                }
                else if (input == "4" || input == "*")
                {
                    Console.Clear();
                    Console.WriteLine("Du har valgt at gange tal sammen");

                    // X delen for input
                    Console.Write("Indtast x: ");
                    string inputXGange = Console.ReadLine();
                    int inputxGange = int.Parse(inputXGange);

                    // Mellemrum
                    Console.WriteLine();

                    // Y delen for input
                    Console.Write("Indtast y: ");
                    string inputYGange = Console.ReadLine();
                    int inputyGange = int.Parse(inputYGange);

                    // Her bliver regnestykket udregnet
                    Console.WriteLine();
                    Console.WriteLine("Regnestykket er: " + regneren.Multiply(inputxGange, inputyGange));
                    beregning = true;
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Du har ikke indtastet et korrekt input");
                    Console.WriteLine("Prøv igen: ");
                }

            }
            while (beregning == false);
        }
    }
}
