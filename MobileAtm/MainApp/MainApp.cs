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
            Start();
        }

        private void Start()
        {
            connection = new Connection();
            conditionDictionary = new Dictionary<string, double>();
            string[] details = connection.SendMessage('5', "").Split('|');
            conditionDictionary.Add(details[0].Split(':')[0], Convert.ToDouble(details[0].Split(':')[1]));
            conditionDictionary.Add(details[1].Split(':')[0], Convert.ToDouble(details[1].Split(':')[1]));
            connection.SendMessage('0', "");
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

            (sender as Button).Visible = false;
            btnBalance.Visible = true;
            btnDeposit.Visible = true;
            btnWithdraw.Visible = true;
            btnStaff.Visible = false;
            btnEndWork.Visible = true;

            string cardNumber = "25555484855656765486567683"; //arduino.requestCardNumber();

            connection = new Connection();

            string res = connection.SendMessage('1', cardNumber);

            if (res == "Exist")
            {
                lblName.Text = "Welcome to our MobileATM";
            }
            else
            {
                lblName.Text = "There is no such client";
                (sender as Button).Visible = false;
                btnBalance.Visible = false;
                btnDeposit.Visible = false;
                btnWithdraw.Visible = false;
                btnStaff.Visible = false;
                btnEndWork.Visible = true;
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
            btn_Card.Enabled = false;

            InputNumForm inputNumForm = new InputNumForm(this);
            inputNumForm.ShowDialog();

            if (inputNumForm.Data != "")
            {
                connection = new Connection();
                var passwordText = inputNumForm.Data;

                var res = connection.SendMessage('7', inputNumForm.Data.ToString());
                if (res == "Exist")
                {
                    ServiceStaffForm serviceStaffForm = new ServiceStaffForm(this.conditionDictionary);
                    serviceStaffForm.ShowDialog();
                    connection.SendMessage('6', "Check tape:" + Convert.ToString(conditionDictionary["Check tape"])
                                                              + "|Cartridge:" + Convert.ToString(conditionDictionary["Cartridge"]));
                    connection.SendMessage('0', "");
                    connection.EndConnection();
                }
                else
                {
                    connection.SendMessage('0', "");
                    connection.EndConnection();
                    lblError.Text = res;
                }
            }

            (sender as Button).Enabled = true;
            btn_Card.Enabled = true;
        }

        private void btnWithdraw_Click(object sender, System.EventArgs e)
        {
            InputNumForm inputNumForm = new InputNumForm(this);
            inputNumForm.ShowDialog();
            if (inputNumForm.Data != null)
            {
                string res = connection.SendMessage('3', inputNumForm.Data.ToString());
                lblBalance.Text = "Withdrawals were successfull";//res;
                conditionDictionary["Check tape"] -= 0.1;
                conditionDictionary["Cartridge"] -= 0.02;
            }
        }

        private void btnDeposit_Click(object sender, System.EventArgs e)
        {
            InputNumForm inputNumForm = new InputNumForm(this);
            inputNumForm.ShowDialog();
            if (inputNumForm.Data != null)
            {
                string res = connection.SendMessage('4', inputNumForm.Data.ToString());
                lblBalance.Text = "Deposit was successfull";//res;
                conditionDictionary["Check tape"] -= 0.1;
                conditionDictionary["Cartridge"] -= 0.02;
            }
        }

        private void btnBalance_Click(object sender, System.EventArgs e)
        {
            string res = connection.SendMessage('2', "");
            lblBalance.Text = "Your balance is: " + res;
            conditionDictionary["Check tape"] -= 0.1;
            conditionDictionary["Cartridge"] -= 0.02;
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

            (sender as Button).Visible = false;
            btnBalance.Visible = false;
            btnDeposit.Visible = false;
            btnWithdraw.Visible = false;
            btnStaff.Visible = true;
            btn_Card.Visible = true;

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

        private void lblBalance_Click(object sender, EventArgs e)
        {

        }
    }
}
