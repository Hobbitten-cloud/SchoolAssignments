using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheMovies.Model
{
    public class Resevation
    {
        public string PaymentMethod { get; set; }
        public int Amount { get; set; }
        public double SalePrice { get; set; }
        public string Seat { get; set; }
        public Resevation(string paymentMethod, int amount, double saleprice, string seat)
        {

            PaymentMethod = paymentMethod;
            Amount = amount;
            SalePrice = saleprice;
            Seat = seat;

        }

    }
}
