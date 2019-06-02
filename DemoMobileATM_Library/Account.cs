namespace DemoMobileATM_Library
{
    public class Account
    {
        protected static short _type;

        public Account(short type)
        {
            _type = type;
        }

        public short Type { get => _type; set => _type = value; }
        public virtual int Balance { get; set; }

        public virtual string Withdraw(int sum)
        {
            return "Error";
        }

        public virtual string Deposit(int sum)
        {
            return "Error";
        }
    }
}
