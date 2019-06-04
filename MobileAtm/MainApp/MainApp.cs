using MobileATM_Library;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MainApp
{
    public partial class MainApp : Form
    {
        private Arduino arduino = new Arduino();
        private Connection connection;
        protected Dictionary<string, double> conditionDictionary;

        public MainApp()
        {
            InitializeComponent();
        }

        private void Start()
        {
            connection = new Connection();
            conditionDictionary = new Dictionary<string, double>();
            string[] details = connection.SendMessage('5', "").Split('|');
            conditionDictionary.Add(details[0].Split(':')[0], Convert.ToDouble(details[0].Split(':')[1]));
            conditionDictionary.Add(details[1].Split(':')[0], Convert.ToDouble(details[0].Split(':')[1]));
            connection.EndConnection();
        }

        private void btn_Card_Click(object sender, System.EventArgs e)
        {
            (sender as Button).Enabled = false;
            btnBalance.Enabled = true;
            btnDeposit.Enabled = true;
            btnWithdraw.Enabled = true;
            btnStaff.Enabled = false;
            btnEndWork.Enabled = true;

            string cardNumber = "25555484855656765486567683"; //arduino.requestCardNumber();

            connection = new Connection();

            string res = connection.SendMessage('1', cardNumber);

            if (res == "Exist")
            {
                lblName.Text = "Welcome";
            }
            else
            {
                lblName.Text = "There is no such client";
            }
        }

        private void buttonStaff_Click(object sender, System.EventArgs e)
        {
            (sender as Button).Enabled = false;
            btnBalance.Enabled = false;
            btnDeposit.Enabled = false;
            btnWithdraw.Enabled = false;
            btnStaff.Enabled = false;
            btnEndWork.Enabled = false;

            Start();
            
            InputNumForm inputNumForm = new InputNumForm(this);
            inputNumForm.ShowDialog();

            if (inputNumForm.Data != "")
            {
                var passwordText = inputNumForm.Data;
                var res = connection.SendMessage('7', inputNumForm.Data.ToString());

                ServiceStaffForm serviceStaffForm = new ServiceStaffForm(this.conditionDictionary);
                serviceStaffForm.ShowDialog();
            }

            (sender as Button).Enabled = false;
            btnBalance.Enabled = false;
            btnDeposit.Enabled = false;
            btnWithdraw.Enabled = false;
            btnStaff.Enabled = false;
            btnEndWork.Enabled = false;
        }

        private void btnWithdraw_Click(object sender, System.EventArgs e)
        {
            InputNumForm inputNumForm = new InputNumForm(this);
            inputNumForm.ShowDialog();
            string res = connection.SendMessage('3', inputNumForm.Data.ToString());
            lblBalance.Text = res;
            conditionDictionary["Check tape"] -= 0.1;
            conditionDictionary["Cartridge"] -= 0.02;
        }

        private void btnDeposit_Click(object sender, System.EventArgs e)
        {
            InputNumForm inputNumForm = new InputNumForm(this);
            inputNumForm.ShowDialog();
            string res = connection.SendMessage('4', inputNumForm.Data.ToString());
            lblBalance.Text = res;
            conditionDictionary["Check tape"] -= 0.1;
            conditionDictionary["Cartridge"] -= 0.02;
        }

        private void btnBalance_Click(object sender, System.EventArgs e)
        {
            string res = connection.SendMessage('2', "");
            lblBalance.Text = res;
        }

        private void btnEndWork_Click(object sender, System.EventArgs e)
        {
            connection.SendMessage('0', "");
            connection.EndConnection();
            connection = null;

            (sender as Button).Enabled = false;
            btnBalance.Enabled = false;
            btnDeposit.Enabled = false;
            btnWithdraw.Enabled = false;
            btnStaff.Enabled = true;
            btn_Card.Enabled = true;

            lblBalance.Text = "";
            lblError.Text = "";
            lblName.Text = "";
        }

        private void SendCondition()
        {
            connection = new Connection();
            string details = connection.SendMessage('6', "Check tape:" + conditionDictionary["Check tape"].ToString()
                                                                      + "|Cartridge" + conditionDictionary["Cartridge"].ToString());
            connection.EndConnection();
        }
    }
}
