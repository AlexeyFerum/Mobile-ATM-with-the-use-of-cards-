using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileATM_Library
{
    public class Detail
    {
        private string name;
        public int resource;

        public int Resource
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
