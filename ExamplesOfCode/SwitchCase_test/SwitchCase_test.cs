namespace SwitchCase_test
{
    internal class SwitchCase_test
    {
        static void Main(string[] args)
        {
            // Spørger brugeren om et spørgsmål og gemmer det som de skriver i "day" variablen
            Console.Write("Skriv hvilken dag er det idag? ");
            string day = Console.ReadLine();

            // Sørger for brugeren når han skriver det ind at bogstavet ikke har stort bogstav i sig
            day = day.ToLower();

            // Sådan ser en switch case ud. Den er effektiv når man skal have mange else if i træk
            switch(day)
            {
                case "mandag":
                    Console.WriteLine();
                    Console.WriteLine("Det er Mandag idag!");
                    break;

                case "tirsdag":
                    Console.WriteLine();
                    Console.WriteLine("Det er Tirsdag idag!");
                    break;

                case "onsdag":
                    Console.WriteLine();
                    Console.WriteLine("Det er Onsdag idag!");
                    break;

                case "torsdag":
                    Console.WriteLine();
                    Console.WriteLine("Det er Torsdag idag!");
                    break;

                case "fredag":
                    Console.WriteLine();
                    Console.WriteLine("Det er Fredag idag!");
                    break;

                case "lørdag":
                    Console.WriteLine();
                    Console.WriteLine("Det er Lørdag idag!");
                    break;

                case "søndag":
                    Console.WriteLine();
                    Console.WriteLine("Det er Søndag idag!");
                    break;

                // Dette er den klassiske else som er til sidst i ens if statement. Den her fanger alt andet hvis det ikke bliver fundet i switch casen
                default:
                    Console.WriteLine();
                    Console.WriteLine(day + " Dette er ikke en dag");
                    break;
            }
        }
    }
}
