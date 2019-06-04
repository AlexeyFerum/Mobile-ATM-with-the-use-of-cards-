using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MainApp
{
    public partial class ServiceStaffForm : Form
    {
        private Dictionary<string, double> _conditionDictionary;

        public ServiceStaffForm(Dictionary<string, double> conditionDictionary)
        {
            InitializeComponent();
            this._conditionDictionary = conditionDictionary;
        }

        public ServiceStaffForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) // check device connection
        {
            textBox1.Text = "Check tape: " + _conditionDictionary["Check tape"].ToString() + "\r\n";
            textBox1.Text += "Cartridge: " + _conditionDictionary["Cartridge"].ToString();
        }

        private void button3_Click(object sender, EventArgs e) // cancel
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e) // repair
        {
            if (!radioButton1.Checked && !radioButton2.Checked)
            {
                textBox1.Text = "Choose detail to repair";
            }
            else
            {
                if (radioButton1.Checked) //check tape
                {
                    _conditionDictionary["Check tape"] = 100;
                    textBox1.Text = "Successfully repaired";
                }
                else
                {
                    _conditionDictionary["Cartridge"] = 100;
                    textBox1.Text = "Successfully repaired";
                }
            }
        }
    }
}
