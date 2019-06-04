using System;
using System.IO.Ports;
using System.Linq;

namespace MobileATM_Library
{
    public class Arduino
    {
        private string cardNumber;

        public string CardNumber
        {
            get => CardNumber;
            private set => cardNumber = value;
        }

        public string requestCardNumber()
        {
            const string PORT_NAME = "COM4";
            const int BAUD_RATE = 9600;

            var portNames = SerialPort.GetPortNames();
            if (!portNames.Contains(PORT_NAME))
                return "Port error";

            using (var arduinoPort = new SerialPort(PORT_NAME, BAUD_RATE))
            {
                bool t = true;

                arduinoPort.Open();
                Console.WriteLine("Attach card: ");
                var data = arduinoPort.ReadLine();

                while (t)
                {
                    if (data != null)
                        t = false;
                    else
                        data = arduinoPort.ReadLine();
                }

                Console.WriteLine($"Received: {data}");
                cardNumber = data;
            }

            return cardNumber;
        }
    }
}