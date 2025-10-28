using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashLearning
{
    public class Hash
    {
        //private const int MAX_HASH_VALUE = 99;
        //private const int HASH_VALUE_LENGTH = 2;
        Random random = new Random();

        // OPGAVE 3 - fra lektion 9
        public int GetHashValue(string password)
        {
            int result = 0;
            for (int i = 0; i < password.Length; i++)
            {
                result += Convert.ToInt32(password[i]);
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Password Hashed: {result % 100}");
            Console.ForegroundColor = ConsoleColor.White;
            return result % 100;
        }

        // OPGAVE 4 - fra lektion 9
        public string GetSaltedHashValue(string password)
        {
            int result = 0;
            for (int i = 0; i < password.Length; i++)
            {
                result += Convert.ToInt32(password[i]);
            }
            result = result % 100;

            int salt = random.Next(3, 6);
            int salted = 0;
            for (int i = 0; i <= salt; i++)
            {
                salted = random.Next(0, 1001);
                salted += salted;
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Password Hashed with salt: {result % 100} - {salted}");
            Console.ForegroundColor = ConsoleColor.White;
            string NewResult = result.ToString() + salted.ToString();

            return NewResult;
        }
    }
}
