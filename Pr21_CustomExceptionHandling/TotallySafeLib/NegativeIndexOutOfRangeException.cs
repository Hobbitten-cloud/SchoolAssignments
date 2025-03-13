using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TotallySafeLib
{
    public class NegativeIndexOutOfRangeException : Exception // Nedarver fra system.exception klassen
    {
        // Constructor chaining
        public NegativeIndexOutOfRangeException() // Vores constructor uden input parametere
        {

        }

        public NegativeIndexOutOfRangeException(string message) : base(message) // base message som kommer fra exception klassen
        {

        }

        public NegativeIndexOutOfRangeException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
