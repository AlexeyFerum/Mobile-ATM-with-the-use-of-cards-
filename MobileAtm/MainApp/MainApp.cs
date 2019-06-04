using MobileATM_Library;
using System.Windows.Forms;

namespace MainApp
{
    public partial class MainApp : Form
    {
        private Arduino arduino = new Arduino();
        private Connection connection;

        public MainApp()
        {
            InitializeComponent();
        }

        public void main()
        {

        }

        private void btn_Card_Click(object sender, System.EventArgs e)
        {
            (sender as Button).Enabled = false;
            btnBalance.Enabled = true;
            btnDeposit.Enabled = true;
            btnWithdraw.Enabled = true;
            btnStaff.Enabled = false;
            btnEndWork.Enabled = true;

            string cardNumber = arduino.requestCardNumber();

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
            InputNumForm inputNumForm = new InputNumForm(this);
            inputNumForm.ShowDialog();

            var passwordText = inputNumForm.Data;

            ServiceStaffForm serviceStaffForm = new ServiceStaffForm();
            serviceStaffForm.ShowDialog();
        }

        private void btnWithdraw_Click(object sender, System.EventArgs e)
        {
            InputNumForm inputNumForm = new InputNumForm(this);
            inputNumForm.ShowDialog();
            string res = connection.SendMessage('3', inputNumForm.Data.ToString());
            lblBalance.Text = res;
        }

        private void btnDeposit_Click(object sender, System.EventArgs e)
        {
            InputNumForm inputNumForm = new InputNumForm(this);
            inputNumForm.ShowDialog();
            string res = connection.SendMessage('4', inputNumForm.Data.ToString());
            lblBalance.Text = res;
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


    }
}
