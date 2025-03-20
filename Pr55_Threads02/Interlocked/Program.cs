namespace Interlocked
{
    internal class Program
    {
        private const int ITERATIONS = 1000000;
        private Int64 _number;
        public Int64 Number { get { return _number; } set { _number = value; } }

        static void Main(string[] args)
        {
            Program p = new Program();
            p.Run();
        }

        private void Run()
        {
            Number = 0;
            Thread adder = new Thread(Add);
            Thread subtractor = new Thread(Subtract);
            adder.Start();
            subtractor.Start();
            adder.Join();
            subtractor.Join();
            Console.Write($"Number: {Number}. \t\tPress any key...");
            Console.ReadKey();
        }

        private void Add()
        {
            for (int i = 0; i < ITERATIONS; i++)
            {
                // Because I named my solution the same as the class it breaks it without having the direct reference
                //System.Threading.Interlocked.Increment(ref _number);
                System.Threading.Interlocked.Add(ref _number, 1); // Another way to solve the basic increment method

                // Otherwise this would normally work
                //Interlocked.Increment(ref _number);

                // Number++;
            }
        }

        private void Subtract()
        {
            for (int i = 0; i < ITERATIONS; i++)
            {
                // Because I named my solution the same as the class it breaks it without having the direct reference
                System.Threading.Interlocked.Decrement(ref _number);

                // Otherwise this would normally work
                //Interlocked.Decrement(ref _number);

                // Number--;
            }
        }

    }
}
