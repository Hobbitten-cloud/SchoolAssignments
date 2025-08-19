namespace substring_test
{
    internal class substring_test
    {
        static void Main(string[] args)
        {
            // brugeren skriver noget ind
            Console.WriteLine("Skriv noget ind: ");
            string text = Console.ReadLine();

            // mellemrum
            Console.WriteLine();

            // Gentagelse til brugeren af hvad man har skrevet
            Console.WriteLine("Du har skrevet: " + text);

            // mellemrum
            Console.WriteLine();

            // Sletter ens text altså starter ens text linje senere hen af linjen. Den tæller kun bogstaverne ikke mellemrummne
            string deltext = text;
            Console.WriteLine(deltext.Substring(5, 10));
        }
    }
}
