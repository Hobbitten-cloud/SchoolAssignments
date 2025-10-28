using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashLearning
{
    public class FromTeacher
    {
        // BILLAG A - LÆRERENS LØSNING TIL OPGAVE 3 OG 4
        private const int MAX_HASH_VALUE = 99;
        private const int HASH_VALUE_LENGTH = 2;
        public void Run()
        {
            bool running = true;
            Console.WriteLine("Enter a password and get the hashed value.");
            while (running)
            {
                Console.Write("Enter password ('q' to end) : ");
                string answer = Console.ReadLine();
                if (answer.Equals("q"))
                {
                    running = false;
                    Console.WriteLine("Bye");
                }
                else
                {
                    Console.WriteLine(PadZero(GetHashValue(answer), HASH_VALUE_LENGTH));
                }
            }
        }

        public string PadZero(int value, int length)
        {
            string result = value.ToString();
            for (int idx = 0; result.Length < HASH_VALUE_LENGTH; idx++)
            {
                result = "0" + result;
            }
            return result;
        }

        public int GetHashValue(string password)
        {
            int result = 0;
            for (int i = 0; i < password.Length; i++)
            {
                result += Convert.ToInt16(password[i]);
            }
            return result % (MAX_HASH_VALUE + 1);
        }
    }
}
