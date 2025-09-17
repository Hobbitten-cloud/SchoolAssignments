namespace ConsoleTestProgram
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TestClass testClass = new TestClass();

            testClass.MenuWithCounting();
        }

        public class TestClass
        {
            public void MenuWithCounting()
            {
                Console.Write("Skriv din alder: ");
                string Input = Console.ReadLine();
                Console.WriteLine();
                Console.WriteLine("Din alder er: " + Input);
            }

            public void FunWithWhileLoops()
            {
                int i = 0;
                while (i < 5)
                {
                    Console.WriteLine(i);
                    //i++;
                    i = i + 1;
                }
            }

            public void PrintHelloWorld()
            {
                Console.WriteLine("Hello World");
            }

            public void LoopPrintOne()
            {
                for (int i = 0; i <= 100; i++)
                {
                    Console.WriteLine(i);
                }
            }

            public void LoopPrintTwo()
            {
                for (int i = 0; i < 101; i++)
                {
                    Console.WriteLine(i + " " + (i + 1) + " " + (i + 2));
                }
            }

            public void LoopPrintThree()
            {
                for (int i = 0; i <= 104; i++)
                {
                    if (i % 5 == 0 && i > 0)
                    {
                        Console.WriteLine();
                    }

                    Console.Write(i + " ");
                }
            }

            public string A(string text)
            {
                return text + text;
            }

            public string A(string text1, string text2)
            {
                return text1 + text2 + text1 + text2;
            }

            public string A(string text1, string text2, string text3)
            {
                return text1 + text2 + text3;
            }
        }
    }
}
