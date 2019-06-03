namespace DemoMobileATM_Library
{
    public class DebitCard : Account
    {
        private const int DEPOSIT_SUM = 100000;
        private const int WITHDRAW_SUM = 50000;

        public int _balance;

        public DebitCard(int balance) : base(_id, _type)
        {
            _balance = balance;
        }

        public override int Balance { get => _balance; set => _balance = value; }

        public override string Deposit(int sum)
        {
            if (sum > DEPOSIT_SUM)
            {
                return "Impossible to deposit more than 100,000 at a time";
            }

            _balance += sum;

            return $"Update Account set balance='{_balance}' where account_id='{_id}'";
        }

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

            return $"Update Account set balance='{_balance}' where account_id='{_id}'";
        }
    }
}
