using System.Collections.Generic;

namespace MobileATM_Server_Library
{
    public class Client
    {
        private string name;
        private int id;
        private Account account;

        public string Name
        {
            get => name;
        }

        public int GetId()
        {
            return id;
        }

        public Client(int id, string name, Account account)
        {
            this.name = name;
            this.id = id;
            this.account = account;
        }
    }
}