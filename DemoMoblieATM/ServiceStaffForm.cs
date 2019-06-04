using DemoMobileATM_Library;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DemoMoblieATM
{
    public partial class ServiceStaffForm : Form
    {
        List<Detail> detailsList;

        private string _data;
        public string Data
        {
            get => _data;
            set => _data = value;
        }

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
            Detail detail1 = detailsList[0];
            Detail detail2 = detailsList[1];

            tbInput.Text = $"{detail1.Id} " + $"{detail1.Name} " + $"{detail1.Resource} " + "\r\n";
            tbInput.Text += $"{detail2.Id} " + $"{detail2.Name} " + $"{detail2.Resource} ";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRepair_Click(object sender, EventArgs e)
        {
            if (rbCartridge.Checked)
            {
                Data = "Update Detail set detail_resource=100 where detail_id=2";
            }
            else
            {
                if (rbCheckTape.Checked)
                {
                    Data = "Update Detail set detail_resource=100 where detail_id=1"; ;
                }
                else
                {
                    if (rbCartridge.Checked && rbCheckTape.Checked)
                    {
                        Data = "Update Detail set detail_resource=100"; ;
                    }
                }
            }
        }
    }
}
