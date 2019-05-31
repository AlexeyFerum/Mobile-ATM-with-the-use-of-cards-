using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileATM_Server_Library
{
    public class DeviceCondition
    {
        private List<Detail> detailsList;

        public DeviceCondition(List<Detail> detailsList)
        {
            this.detailsList = detailsList;
        }

        public void Repair(Detail detail) { }

        public bool checkCondition(Detail detail) { return true; }
    }
}
