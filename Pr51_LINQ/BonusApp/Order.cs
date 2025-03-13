using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BonusApp
{
    public class Order
    {
        public BonusProvider Bonus { get; set; }
        private List<Product> _products = new List<Product>();

        public void AddProduct(Product p)
        {
            _products.Add(p);
        }

        public double GetValueOfProducts()
        {
            //double valueOfProducts = 0;
            //foreach (Product product in _products)
            //{
            //    valueOfProducts += product.Value;
            //}

            //return valueOfProducts;


            // LINQ Expression. Does the same as above
            return _products.Sum(product => product.Value);
        }

        public double GetValueOfProducts(DateTime date)
        {
            //return _products.Where(product => product.AvailableFrom <= date && product.AvailableTo >= date)
            //                .Sum(product => product.Value);

            // Usage of Ternary operator. 
            // ? asks if product.value and : is just else to end the statement.
            // (condition) ? ref consequent : ref alternative
            return _products.Sum(product => (product.AvailableFrom <= date && product.AvailableTo >= date) ? product.Value : 0);
        }

        public double GetBonus()
        {
            return Bonus(GetValueOfProducts());
        }

        public double GetBonus(DateTime date, BonusProvider bonusProvider) // Anvender vores delegate defineret foroven.
        {
            double productValue = GetValueOfProducts(date);

            return bonusProvider(productValue);
        }

        public double GetTotalPrice()
        {
            return GetValueOfProducts() - GetBonus();
        }

        public double GetTotalPrice(DateTime date, BonusProvider bonusProvider)
        {
            double productValue = GetValueOfProducts(date);
            double bonus = bonusProvider(productValue);

            return productValue - bonus;
        }

        public List<Product> SortProductOrderBy(Func<Product, object> userInput)
        {
            return _products.OrderBy(userInput) // Bruger den givne lambda til at bestemme sorteringen
                            .ToList(); // Konverterer til en liste
        }
    }
}
