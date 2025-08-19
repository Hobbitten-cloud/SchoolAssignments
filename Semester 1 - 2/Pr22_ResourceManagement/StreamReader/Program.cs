namespace StreamReader_Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // File path
            string path = @"C:\Users\nickl\OneDrive\Desktop\Datamatiker_Projects\Studiegruppe\Team17\Pr22_ResourceManagement\StreamTest.txt";

            // If the file path does not exist. Then create a file in this path and store following
            if (!File.Exists(path))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine("Hello");
                    sw.WriteLine("And");
                    sw.WriteLine("Welcome");
                }
            }

            // Open the file to read from.
            using (StreamReader sr = File.OpenText(path))
            {
                string read;

                // While read = sr and does is not null
                while ((read = sr.ReadLine()) != null)
                {
                    Console.WriteLine(read);
                }
            }

            while (true)
            {
                Console.WriteLine("Du har skudt papegøjen");

                Console.WriteLine("Daniel du er meget sej og hvid?");
            }

        }
    }
}
