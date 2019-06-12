using System;
using System.Windows.Forms;

namespace MainApp
{
    public partial class InputNumForm : Form
    {
        private string _data;
        public string Data { get; set; }

        public InputNumForm()
        {
            InitializeComponent();
            _data = "";
        }

        public InputNumForm(MainApp mainForm)
        {
            InitializeComponent();
            _data = "";
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            Data = tbInsert.Text;
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (tbInsert.TextLength != 0)
                tbInsert.Text = tbInsert.Text.Remove(tbInsert.TextLength - 1, 1);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            tbInsert.Text = "";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tbInsert.Text += 1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tbInsert.Text += 2;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tbInsert.Text += 3;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tbInsert.Text += 4;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            tbInsert.Text += 5;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            tbInsert.Text += 6;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            tbInsert.Text += 7;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            tbInsert.Text += 8;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            tbInsert.Text += 9;
        }

        private void button0_Click(object sender, EventArgs e)
        {
            tbInsert.Text += 0;
        }

        //protected override void OnFormClosing(FormClosingEventArgs e)
        //{
        //    this.Close();
        //}
    }
}
