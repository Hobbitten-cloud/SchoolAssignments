using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBank
{
    public class BankAccount
    {
        public string Name { get; set; }
        public double Balance 
        { 
            get {return balance;}
        }

        private double balance;

        private bool locked = false;

        public BankAccount(double balance)
        {

        }
        public BankAccount(string name, double balance)
        {

        }
        public BankAccount(string name, double balance, bool locked)
        {
            this.Name = name;
            this.balance = balance;
            this.locked = locked;

        }
        public void Deposit(double amount)
        {

            this.balance = Balance;

            if (locked == false)
            {
                balance += amount;
            }
            else
            {
                Console.WriteLine("Din konto er låst");
            }

        }
        public void Withdraw(double amount)
        {
            //Withdraw(amount: double): trækker det angivne beløb(en: amount)
            //må ikke trække penge fra bankkontoen, hvis der efterspørges mere, end der er på bankkontoen
            //må ikke trække penge fra en låst bankkonto(en: locked)
            //bool else -if

            this.balance = Balance;

            if (amount <= Balance && locked == false)
            {
                balance -= amount;
            }
            else
            {
                Console.WriteLine("Din konto er låst / der ik nok penge på kontoen");
            }

        }
        public void ChangeLockState()
        {
            this.locked = !locked;
        }
        public override string ToString()
        {
            return "Name: " + Name + "\n" + "Balance: " + Balance;
        }
    }
}
