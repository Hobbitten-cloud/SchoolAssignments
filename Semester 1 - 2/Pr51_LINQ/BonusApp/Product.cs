using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BonusApp
{
    public class Product
    {
        public string Name { get; set; }
        public double Value { get; set; }

        // AvailableFrom angiver fra hvilken dato, produktet er tilgængeligt
        public DateTime AvailableFrom { get; set; }

        // AvailableTo angiver til hvilken dato, produktet er tilgængeligt
        public DateTime AvailableTo { get; set; }
    }
}
