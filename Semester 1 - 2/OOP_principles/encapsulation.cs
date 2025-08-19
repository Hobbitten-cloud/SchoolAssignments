using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_principles
{
    internal class encapsulation
    {
        // Denne variable har man adgang til i hele programmet
        string hejsa = "lel";

        public void encap()
        {
            // Hejsa variablen bliver brugt.
            Console.WriteLine(hejsa);

            // Denne variable har man kun adgang til i dette scope som er mellem de brackets
            string virkerikke = "Ej forkert";
        }

        // string variablen kan ikke tilgås da programmet ikke kan finde den
        // virkerikke

    }
}
