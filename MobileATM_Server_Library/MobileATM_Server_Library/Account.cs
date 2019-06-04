namespace MobileATM_Server_Library
{
    public class Account
    {
        protected static bool type;
        protected string number;

        protected Account(bool type)
        {
            Account.type = type;
        }

        protected bool Type
        {
            get { return type; }
        }

        public virtual double GetBalance()
        {
            return 0;
        }

        public string GetNumber()
        {
            return number;
        }

        public virtual string Withdraw(double sum, int id) => "Error";
        public virtual string Deposit(double sum, int id) => "Error";
    }
}
