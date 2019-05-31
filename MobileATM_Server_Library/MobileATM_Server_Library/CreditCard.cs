using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileATM_Server_Library
{
    public class CreditCard : Account
    {
        private DateTime dateOfInitiation;
        private DateTime dateOfRepairment;
        private double debt;
        private double balance;
        private short period;

        public CreditCard(double balance, short period) : base(type)
        {
            this.balance = balance;
            this.period = period;
        }

        public void addPayment(DateTime dateOfInitiation, double amount)
        {

        }

        public void Repayment(DateTime dateOfRepayment, double amount)
        {

        }
    }
}
