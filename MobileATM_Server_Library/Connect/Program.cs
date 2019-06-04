using System;
using System.Configuration;
using System.Data.Common;
using MobileATM_Server_Library;

namespace Connect
{
    public class Program
    {
        static void Main(string[] args)
        {
            Server server = new Server();
            server.StartWorking();
        }

        
    }
}
