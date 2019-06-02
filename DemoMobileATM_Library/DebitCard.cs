namespace DemoMobileATM_Library
{
    public class DebitCard : Account
    {
        private const int DEPOSIT_SUM = 100000;
        private const int WITHDRAW_SUM = 50000;

        protected int _balance;
        protected string _id;

        public DebitCard(string cardNumber, int balance) : base(_type)
        {
            _balance = balance;
        }

        public override int Balance { get => _balance; set => _balance = value; }
        public string Id { get => _id; set => _id = value; }

        //public override string Deposit(int sum)
        //{
        //    if (sum > DEPOSIT_SUM)
        //    {
        //        return "Impossible to deposit more than 100,000 at a time";
        //    }
        //    else
        //    {
        //        DB_Service 
        //    }
        //}

        public override string Withdraw(int sum)
        {
            if (sum > _balance)
            {
                return "Insufficient funds in the account";
            }

            if (sum > WITHDRAW_SUM)
            {
                return "Impossible to withdraw more than 50,000 at a time";
            }

            _balance -= sum;

            return "Update Account set balance='" + _balance + "' where account_id='" + _id + "'";
            //return "Update Account set balance='0' where account_id='" + _id + "'";
        }
    }
}
