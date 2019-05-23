using MobileATM_Library;
using System.Windows.Forms;

namespace MainApp
{
    public partial class MainApp : Form
    {
        private MainApp()
        {
            InitializeComponent();
        }

        public static void main()
        {
            Arduino arduino = new Arduino();

            while (true)
            {
                string cardNumber = arduino.requestCardNumber();


            }
        }
    }
}
