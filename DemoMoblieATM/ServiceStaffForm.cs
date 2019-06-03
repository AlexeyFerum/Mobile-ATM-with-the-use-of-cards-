using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DemoMobileATM_Library;

namespace DemoMoblieATM
{
    public partial class ServiceStaffForm : Form
    {
        List<Detail> detailsList;

        public ServiceStaffForm()
        {
            InitializeComponent();
        }

        public ServiceStaffForm(List<Detail> list)
        {
            InitializeComponent();
            detailsList = list;
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            dgvDeviceCondition.ColumnCount = 3;
            dgvDeviceCondition.RowCount = 2;

            Detail detail1 = detailsList[0];
            Detail detail2 = detailsList[1];

            string[] row1 = {$"{detail1.Id}", $"{detail1.Name}", $"{detail1.Resource}"};
            string[] row2 = { $"{detail2.Id}", $"{detail2.Name}", $"{detail2.Resource}" };
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
