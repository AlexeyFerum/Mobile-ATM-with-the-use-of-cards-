using System;
using System.IO.Ports;
using System.Linq;

namespace DemoMobileATM_Library
{
    public class Arduino
    {
        private string _cardNumber;

        public string CardNumber
        {
            get => CardNumber;
            private set => _cardNumber = value;
        }

        public string RequestCardNumber()
        {
            const string PORT_NAME = "COM4";
            const int BAUD_RATE = 9600;

            var portNames = SerialPort.GetPortNames();
            if (!portNames.Contains(PORT_NAME))
                return "Port error";

            using (var arduinoPort = new SerialPort(PORT_NAME, BAUD_RATE))
            {
                var t = true;

                arduinoPort.Open();
                Console.WriteLine("Attach card: ");
                var data = "";
                data = arduinoPort.ReadLine();

                while (t)
                {
                    if (data != null)
                        t = false;
                    else
                        data = arduinoPort.ReadLine();
                }

                Console.WriteLine($"Received: {data}");
                _cardNumber = data;

                arduinoPort.Close();
            }

            return _cardNumber;
        }
    }
}
