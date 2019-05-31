using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileATM_Server_Library
{
    public class ServiceStaff
    {
        private string name;
        private string surname;
        private short pin;

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

        public string Surname
        {
            get
            {
                return surname;
            }

            private set
            {
                surname = value;
            }
        }

        public ServiceStaff(string name, string surname, short pin)
        {
            this.name = name;
            this.surname = surname;
            this.pin = pin;
        }

        public bool isCorrectPin() { return true; }

        public void Repair() { }
    }
}
