namespace DemoMobileATM_Library
{
    public class ServiceStaff
    {
        private int _id;
        private string _name;
        private short _password;

        public ServiceStaff(int staffId, string name, short password)
        {
            _id = staffId;
            _name = name;
            _password = password;
        }

        public int Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
        public short Password { get => _password; set => _password = value; }
    }
}
