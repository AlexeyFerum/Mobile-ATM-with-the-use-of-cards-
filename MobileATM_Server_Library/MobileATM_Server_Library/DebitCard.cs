namespace MobileATM_Server_Library
{
    class DebitCard : Account
    {
        private double balance;

        public DebitCard(string number, double balance) : base(type)
        {
            this.balance = balance;
            this.number = number;
        }

        public override string Withdraw(double amount, int id)
        {
            if (amount > balance)
            {
                return "Insufficient funds in the account";
            }

            if (amount > 50000)
            {
                return "Impossible to withdraw more than 50,000 at a time";
            }

            balance -= amount;


            return "OK"; //$"Update Account set balance='{balance}' where account_id='{id}'";
        }

        public override string Deposit(double amount, int id)
        {
            if (amount > 100000)
            {
                return "Impossible to deposit more than 100,000 at a time";
            }

            balance += amount;

            return "OK"; //$"Update Account set balance='{balance}' where account_id='{id}'";
        }

        public override double GetBalance()
        {
            return balance;
        }
    }
}
