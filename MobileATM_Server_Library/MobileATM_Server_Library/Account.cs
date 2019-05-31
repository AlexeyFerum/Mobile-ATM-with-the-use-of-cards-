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
        int number;

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
    }
}
