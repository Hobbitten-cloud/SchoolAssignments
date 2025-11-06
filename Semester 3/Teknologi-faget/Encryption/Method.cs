using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Encryption
{
    public class Method
    {
        public bool IsPrime(uint number)
        {
            if (number == 0 || number == 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You cannot write 0 or 1");
                Console.ForegroundColor = ConsoleColor.White;
                return false;
            }

            for (uint i = 2; i < number; i++)
            {
                if (number % i == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(number + " is not a prime number");
                    Console.ForegroundColor = ConsoleColor.White;
                    return false;
                }
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(number + " is a prime number");
            Console.ForegroundColor = ConsoleColor.White;
            return true;
        }

        public List<uint> GetPrimeFactors(uint number)
        {
            //Signatur: public List<uint> GetPrimeFactors(uint number)
            //Precondition: Parameteren number er større end nul
            //Postcondition: Der returneres en liste bestående af alle primtalsfaktorer for number
            //Eksempel: 	GetPrimeFactors(3713) returnerer[47, 79]

            //GetPrimeFactors(2380) returnerer[2, 5, 7, 17]
            if (number == 0 || number == 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You cannot write 0 or 1");
                Console.ForegroundColor = ConsoleColor.White;
                return null;
            }


        }
    }
}
