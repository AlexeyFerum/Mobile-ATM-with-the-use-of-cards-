using System;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace MobileATM_Library
{
    public class Connection
    {
        IPHostEntry ipHost;
        IPAddress ipAddr;
        IPEndPoint ipEndPoint;
        Socket sender;

        public Connection()
        {
            try
            {
                ipHost = Dns.GetHostEntry("localhost");
                ipAddr = ipHost.AddressList[0];
                ipEndPoint = new IPEndPoint(ipAddr, 11000);

                sender = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString()); // Change
            }
            finally
            {
                Console.ReadLine();
            }
        }

        public string SendMessage(char command, string data)
        {
            // Буфер для входящих данных
            byte[] bytes = new byte[1024];

            // Соединяем сокет с удаленной точкой
            sender.Connect(ipEndPoint);

            string message = command + data;

            byte[] msg = Encoding.UTF8.GetBytes(message);

            // Отправляем данные через сокет
            int bytesSent = sender.Send(msg);

            // Получаем ответ от сервера
            int bytesRec = sender.Receive(bytes);

            return Encoding.UTF8.GetString(bytes, 0, bytesRec);
        }

        public void EndConnection()
        {
            // Освобождаем сокет
            sender.Shutdown(SocketShutdown.Both);
            sender.Close();
        }
    }

}
