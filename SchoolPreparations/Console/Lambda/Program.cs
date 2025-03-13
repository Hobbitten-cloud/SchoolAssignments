using System.Security.Cryptography.X509Certificates;

namespace Lambda
{
    // Same signature as the method below
    public delegate DateTime MyDelegateType(int hour, int minutes, int seconds);

    public static class DateTimeExtensions
    {
        // The keyword "this" extends the DateTime class
        public static string HMS(this DateTime dt)
        {
            return $"{dt.Hour}:{dt.Minute}:{dt.Second}";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            int year = 2024, month = 12, day = 12;


            MyDelegateType del;

            // Defined delegate - Has a name - This is the same as below
            del = HMS2DateTime;

            // An anonymous delegate - Does not have a name - This is the same as above
            del = delegate (int h, int m, int s)
            {
                return new DateTime(year, month, day, h, m, s);
            };

            // Lambda expression - Explicit that return is behind new
            // You can even delete the ints below
            // Does the same as the 2 other methods shown above
            del = (int h, int m, int s) => new DateTime(year, month, day, h, m, s);

            // Defines what will be written to console
            DateTime dt = del(13, 45, 30);

            // Converts the DateTime to a string to be displayes
            // Console.WriteLine(dt.ToString());

            // Extension on the method above for the writeline
            Console.WriteLine(dt.HMS());


            // Stops the console for exciting when code is finished
            Console.ReadLine();
        }

        // Same signature as the delegate above
        public static DateTime HMS2DateTime(int h, int m, int s)
        {
            return new DateTime(1, 1, 1, h, m, s);
        }

    }
}
