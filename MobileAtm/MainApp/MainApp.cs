using MobileATM_Library;
using System.Windows.Forms;

namespace MainApp
{
    public partial class MainApp : Form
    {
        public MainApp()
        {
            InitializeComponent();
        }

        public void main()
        {
            Arduino arduino = new Arduino();


            while (true)
            {
                string cardNumber = arduino.requestCardNumber();




            }
        }
    }
}
