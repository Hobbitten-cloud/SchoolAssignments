namespace OrangeTreeSim
{
    internal class Program
    {
        static void Main(string[] args)
        {
            OrangeTree orangetree = new OrangeTree();
            orangetree.OneYearPasses();

            Console.WriteLine();

            orangetree.Age = 23;
            Console.WriteLine("Daniel er så gammel her: " + orangetree.Age);
        }
    }
}
