using System.Net.Sockets;
using System.Xml.Linq;

namespace SimpleBank
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BankAccount bankAccount1 = new BankAccount("Jimmy", 600.434, false);
            

            Console.WriteLine(bankAccount1);

        }
    }
}
