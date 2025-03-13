namespace length_test
{
    internal class length_test
    {
        static void Main(string[] args)
        {
            // fortæller en hvor lang ens tekst er i bogstaver / karakterer
            Console.Write("Indskriv din tekst du gerne vil vide hvor lang den er: ");
            string text = Console.ReadLine();

            // laver et linje skift
            Console.WriteLine();

            // Vi bruger .length ud fra variablen for at tælle bogstaverne
            Console.WriteLine("Din tekst længde er " + text.Length + " bogstavs linjer");
        }
    }
}
