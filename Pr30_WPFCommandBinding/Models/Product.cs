using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pr30_WPFCommandBinding.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ProductType { get; set; }
        public double Price { get; set; }

        private static int Index = 0;


        public Product(string name, string productType, double price)
        {
            // Auto inkrementerer
            Id = Index++;
            Name = name;
            ProductType = productType;
            Price = price;
        }

    }
}
