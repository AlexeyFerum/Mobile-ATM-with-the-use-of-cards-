namespace DemoMobileATM_Library
{
    public class Detail
    {
        private int _id;
        private string _name;
        private int _resource;

        public Detail(int id, string name, int resource)
        {
            _id = id;
            _name = name;
            _resource = resource;
        }

        public int Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
        public int Resource { get => _resource; set => _resource = value; }
    }
}
