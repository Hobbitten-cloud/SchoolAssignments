using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BonusApp
{
    public class Order
    {
        public BonusProvider Bonus {  get; set; }

        // Liste oprettes på grund af en til mange associationen
        public List<Product> products = new List<Product>();

        public void AddProduct(Product p)
        {
            // AddProduct(Product p) tilføjer et Product-objekt
            // til ordren (husk at implementere en-til-mange associationen mellem Product og Order med en passende datastruktur)
            products.Add(p);
        }
        public double GetValueOfProducts()
        {
            // GetValueOfProducts() returnerer den samlede værdi af de tilknyttede Product-objekter

            double ValueOfProducts = 0.0;

            foreach (Product p in products)
            {
                ValueOfProducts += p.Value;
            }

            return ValueOfProducts;
        }
        public double GetBonus()
        {
            // GetBonus() benytter ordrens delegate til at udregne bonus af den samlede værdi af de tilknyttede Product-objekter
            return Bonus(GetValueOfProducts());

            // return Bonus.Invoke(GetValueOfProducts());
        }

        // With Delegate 
        //public double GetBonus(BonusProvider amount)
        //{

        //    return amount(GetValueOfProducts());
        //}

        // With Func delegate
        public double GetBonus(Func<double, double> amount)
        {

            return amount(GetValueOfProducts());
        }

        public double GetTotalPrice()
        {
            // GetTotalPrice() returnerer den samlede værdi af de tilknyttede Product-objekter minus den beregnede bonus
            return GetValueOfProducts() - GetBonus();
        }

        public double GetTotalPrice(Func<double, double> amount)
        {

            return GetValueOfProducts() - GetBonus(amount);
        }
    } 
}
