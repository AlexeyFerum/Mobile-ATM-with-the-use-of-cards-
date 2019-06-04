using DemoMobileATM_Library;
using System;
using System.Collections.Generic;
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
            var arduino = new Arduino();
            var cardNumber = arduino.RequestCardNumber();  /*"25648484848655356495067483"; */

            (sender as Button).Enabled = false;
            btnBalance.Enabled = true;
            btnDeposit.Enabled = true;
            btnWithdraw.Enabled = true;
            btnCancel.Enabled = true;
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
            var commandText = mainAccount.Withdraw(Convert.ToInt32(inputNumForm.Data)).Split('|');

            if (!commandText[0].Contains("Update"))
            {
                lblError.Text = commandText[0];
            }
            else
            {
                mainDbService.UpdateData(commandText[0]);
                //mainDbService.UpdateData(commandText[1]);
                //mainDbService.UpdateData(commandText[2]);
            }
        }

        private void btnDeposit_Click(object sender, EventArgs e)
        {
            lblError.Text = "";

            InputNumForm newForm = new InputNumForm(this);
            newForm.ShowDialog();
            var commandText = mainAccount.Deposit(Convert.ToInt32(newForm.Data)).Split('|');

            if (!commandText[0].Contains("Update"))
            {
                lblError.Text = commandText[0];
            }
            else
            {
                mainDbService.UpdateData(commandText[0]);
                //mainDbService.UpdateData(commandText[1]);
                //mainDbService.UpdateData(commandText[2]);
            }

        }

        private void btnStaff_Click(object sender, EventArgs e)
        {
            InputNumForm inputNumForm = new InputNumForm(this);
            inputNumForm.ShowDialog();

            var passwordText = inputNumForm.Data;

            mainDbService = new DB_Service();
            var serviceStaffDataList = mainDbService.GetDataList(
                "Select * from ServiceStaff where password = " + passwordText);

            var checkTapeDataList = mainDbService.GetDataList("Select * from Detail where name = 'Check tape'");
            Detail checkTapeDetail = new Detail(Convert.ToInt32(checkTapeDataList[0]), checkTapeDataList[1], Convert.ToInt32(checkTapeDataList[2]));

            var cartridgeDataList = mainDbService.GetDataList("Select * from Detail where name = 'Cartridge'");
            Detail cartridgeDetail = new Detail(Convert.ToInt32(cartridgeDataList[0]), cartridgeDataList[1], Convert.ToInt32(cartridgeDataList[2]));

            var detailsList = new List<Detail>() { checkTapeDetail, cartridgeDetail };

            DeviceCondition deviceCondition = new DeviceCondition(detailsList);

            if (serviceStaffDataList.Count == 0)
            {
                lblError.Text = "Wrong password.";
            }
            else
            {
                serviceStaff = new ServiceStaff(Convert.ToInt32(serviceStaffDataList[0]),
                    serviceStaffDataList[1], Convert.ToInt16(serviceStaffDataList[2]));

                var serviceStaffForm = new ServiceStaffForm(deviceCondition.DetailsList);
                serviceStaffForm.ShowDialog();

                mainDbService.UpdateData(serviceStaffForm.Data);

                if (serviceStaffForm.Data.Contains("Check"))
                {
                    checkTapeDetail.Resource = 100;
                    //mainDbService.UpdateData($"Insert into History values (date_of_visit='{DateTime.Now.Day}', detail_id=1', staff_id='{serviceStaff.Id}')");
                }
                else
                {
                    if (serviceStaffForm.Data.Contains("Cartridge"))
                    {
                        cartridgeDetail.Resource = 100;
                        //mainDbService.UpdateData($"Insert into History values (date_of_visit='{DateTime.Now.Day}', detail_id=2', staff_id='{serviceStaff.Id}')");
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
