namespace Rektanglets_areal_test
{
    internal class Rektanglets_areal_test
    {
        static void Main(string[] args)
        {
            int højdeInt, breddeInt;
            string højdeString, breddeString;


            Console.Write("Indtast Højden af rektangelen: ");
            højdeString = Console.ReadLine();
            højdeInt = int.Parse(højdeString);
            
            Console.WriteLine("Du har indtastet at længden er " + højdeString);

            Console.WriteLine();


            Console.Write("Indtast længden af rektangelen: ");
            breddeString = Console.ReadLine();
            breddeInt = int.Parse(breddeString);
            Console.WriteLine("Du har indtastet at længden er " + breddeString);

            int areal = højdeInt * breddeInt;

            Console.WriteLine("Arealet er: " + areal);

        }
    }
}
