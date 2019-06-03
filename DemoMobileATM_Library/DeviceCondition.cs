using System.Collections.Generic;

namespace DemoMobileATM_Library
{
    public class DeviceCondition
    {
        private List<Detail> detailsList;

        public DeviceCondition(List<Detail> detailsList)
        {
            this.detailsList = detailsList;
        }

        public List<Detail> DetailsList { get => detailsList; set => detailsList = value; }

        public string CheckCondition()
        {
            var output = "Everything is alright";

            foreach (var detail in detailsList)
            {
                if (detail.Resource < 30)
                {
                    output += $"Need to repair the {detail}" + "\r\n";
                }
            }

            return output;
        }

        public string Repair(Detail detail)
        {
            detail.Resource = 100;
            return $"Update Detail set detail_resource='100' where detail_id='{detail.Id}'";
        }
    }
}
