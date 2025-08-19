namespace indexOf_test
{
    internal class indexOf_test
    {
        static void Main(string[] args)
        {
            // Brug gørelse af convert.toChar metoden. Samt brug af index funktionen som gemmer et bestemt bogstav i vores tekst linje. Index går fra 0, 1, 2 osv
            char chr = Convert.ToChar(Console.ReadLine()[1]); // Lige nu gemmer koden det som brugeren skriver ind i position 2. f.eks. Hej = e

            // Skriver vores char index ud til konsol vinduet
            Console.WriteLine(chr);

        }
    }
}
