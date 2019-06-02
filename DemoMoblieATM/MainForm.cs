using DemoMobileATM_Library;
using System;
using System.Windows.Forms;

namespace DemoMoblieATM
{
    public partial class MainForm : Form
    {
        private Client mainClient;
        private Account mainAccount;
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
            var clientDataList = mainDbService.GetDataList("Select * from Client where account_id = " + $"{cardNumber}");
            if (clientDataList.Count == 0)
            {
                lblName.Text = "You are not a customer of our bank.";
            }
            else
            {
                var accountDataList = mainDbService.GetDataList("Select * from Account where account_id = " + $"{clientDataList[2]}");

                if (accountDataList[2] == "0")
                {
                    mainAccount = new DebitCard(accountDataList[0], Convert.ToInt32(accountDataList[1]));
                    mainClient = new Client(Convert.ToInt32(clientDataList[0]), clientDataList[1], mainAccount);
                }


                lblName.Text = "Welcome, " + mainClient.Name;
            }

            //dbService.
        }

        private void btnBalance_Click(object sender, EventArgs e)
        {
            lblBalance.Text = lblBalance.Text.Length == 0 ? $"Your balance is: {mainClient.Account.Balance}" : "";
        }

        private void btnWithdraw_Click(object sender, EventArgs e)
        {
            InputNumForm newForm = new InputNumForm(this);
            newForm.ShowDialog();
            var commandText = mainAccount.Withdraw(Convert.ToInt32(newForm.Data));
            mainDbService.UpdateData(commandText);
        }

        private void btnDeposit_Click(object sender, EventArgs e)
        {

        }

        private void btnStaff_Click(object sender, EventArgs e)
        {
        }
    }
}
