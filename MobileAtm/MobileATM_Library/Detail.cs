namespace MobileATM_Library
{
    public class Detail
    {
        private string name;
        public double resource;

        public double Resource
        {
            get
            {
                return resource;
            }

            private set
            {
                resource = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            private set
            {
                name = value;
            }
        }
    }
}
