namespace DemoMobileATM_Library
{
    public class Account
    {
        public static string _id;
        public static short _type;

        public Account(string id, short type)
        {
            _id = id;
            _type = type;
        }

        public string Id { get => _id; set => _id = value; }
        public virtual int Balance { get; set; }
        public short Type { get => _type; set => _type = value; }

        public virtual string Withdraw(int sum) => null;
        public virtual string Deposit(int sum) => null;
    }
}
