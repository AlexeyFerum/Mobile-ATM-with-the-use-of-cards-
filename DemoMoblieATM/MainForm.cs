using DemoMobileATM_Library;
using System;
using System.Windows.Forms;

namespace DemoMoblieATM
{
    public partial class MainForm : Form
    {
        private Client mainClient;
        private Account mainAccount;
        private ServiceStaff serviceStaff;
        private DB_Service mainDbService;

        public MainForm()
        {
            InitializeComponent();
        }

        private void btn_Card_Click(object sender, EventArgs e)
        {
            //var arduino = new Arduino();
            var cardNumber = "25648484848655356495067483"; //arduino.RequestCardNumber();

            (sender as Button).Enabled = false;
            btnBalance.Enabled = true;
            btnDeposit.Enabled = true;
            btnWithdraw.Enabled = true;
            btnStaff.Enabled = false;

            mainDbService = new DB_Service();
            var clientDataList = mainDbService.GetDataList(
                "Select * from Client where account_id = " + $"{cardNumber}");
            if (clientDataList.Count == 0)
            {
                lblError.Text = "You are not a customer of our bank.";
            }
            else
            {
                var accountDataList = mainDbService.GetDataList(
                    "Select * from Account where account_id = " + $"{clientDataList[2]}");

                if (accountDataList[2] == "0")
                {
                    mainAccount = new DebitCard(Convert.ToInt32(accountDataList[1]))
                    {
                        Id = accountDataList[0],
                        Type = 0
                    };
                    mainClient = new Client(Convert.ToInt32(clientDataList[0]), clientDataList[1], mainAccount);
                }

                lblName.Text = "Welcome, " + mainClient.Name;
            }
        }

        private void btnBalance_Click(object sender, EventArgs e)
        {
            lblError.Text = "";

            lblBalance.Text = lblBalance.Text.Length == 0 ? $"Your balance is: {mainClient.Account.Balance}" : "";
        }

        private void btnWithdraw_Click(object sender, EventArgs e)
        {
            lblError.Text = "";

            InputNumForm inputNumForm = new InputNumForm(this);
            inputNumForm.ShowDialog();
            var commandText = mainAccount.Withdraw(Convert.ToInt32(inputNumForm.Data));

            if (!commandText.Contains("Update"))
            {
                lblError.Text = commandText;
            }
            else
                mainDbService.UpdateData(commandText);
        }

        private void btnDeposit_Click(object sender, EventArgs e)
        {
            lblError.Text = "";

            InputNumForm newForm = new InputNumForm(this);
            newForm.ShowDialog();
            var commandText = mainAccount.Deposit(Convert.ToInt32(newForm.Data));

            if (!commandText.Contains("Update"))
            {
                lblError.Text = commandText;
            }
            else
                mainDbService.UpdateData(commandText);
        }

        private void btnStaff_Click(object sender, EventArgs e)
        {
            InputNumForm inputNumForm = new InputNumForm(this);
            inputNumForm.ShowDialog();

            var passwordText = inputNumForm.Data;

            mainDbService = new DB_Service();
            var serviceStaffDataList = mainDbService.GetDataList(
                "Select * from ServiceStaff where password = " + passwordText);

            if (serviceStaffDataList.Count == 0)
            {
                lblError.Text = "Wrong password.";
            }
            else
            {
                serviceStaff = new ServiceStaff(Convert.ToInt32(serviceStaffDataList[0]),
                    serviceStaffDataList[1], Convert.ToInt16(serviceStaffDataList[2]));

                ServiceStaffForm serviceStaffForm = new ServiceStaffForm();
                serviceStaffForm.ShowDialog();
            }
        }
    }
}
