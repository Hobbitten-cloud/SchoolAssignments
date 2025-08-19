using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pr30_WPFCommandBinding.Models
{
    public class ProductRepo
    {
        private List<Product> products { get; set; } = new List<Product>()
        {
            new Product("Apple", "Fruit", 7.95),
            new Product("Orange", "Fruit", 5.50),
            new Product("Banana", "Fruit", 8.25)
        };

        public void Add(Product product)
        {
            products.Add(product);
        }


        public void Remove(int id)
        {
            // Find the person in the internal persons list with same Id as the 'id'-parameter
            Product product = Get(id);

            if (product != null)
            {
                products.Remove(product);
            }
            else
            {
                throw (new ArgumentException("Person with id = " + id + " not found"));
            }
        }

        public Product Get(int id)
        {
            Product result = null;

            foreach (Product p in products)
            {
                if (p.Id == id)
                {
                    result = p;
                    break;
                }
            }

            return result;
        }

        public List<Product> GetAll()
        {
            return products;
        }
    }

}
