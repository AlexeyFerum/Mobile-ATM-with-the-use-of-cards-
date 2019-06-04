using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            get
            {
                return type;
            }
        }

        public virtual double GetBalance()
        {
            return 0;
        }

    }
}
