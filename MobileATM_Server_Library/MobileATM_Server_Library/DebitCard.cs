using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileATM_Server_Library
{
    class DebitCard: Account
    {
        private double balance;

        public DebitCard(string number, double balance) : base(type)
        {
            this.balance = balance;
            this.number = number;
        }

        public void withdraw(double amount)
        {

        }

        public void deposit(double amount)
        {

        }
    }
}
