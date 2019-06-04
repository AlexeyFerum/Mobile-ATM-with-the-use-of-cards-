using MobileATM_Server_Library;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MainApp
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

        private void button1_Click(object sender, EventArgs e)
        {
            Detail detail1 = detailsList[0];
            Detail detail2 = detailsList[1];

            textBox1.Text = $"{detail1.Name} " + $"{detail1.Resource} " + "\r\n";
            textBox1.Text += $"{detail2.Name} " + $"{detail2.Resource} ";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                Data = "Update Detail set detail_resource=100 where detail_id=2";
            }
            else
            {
                if (radioButton2.Checked)
                {
                    Data = "Update Detail set detail_resource=100 where detail_id=1"; ;
                }
            }
        }
    }
}
