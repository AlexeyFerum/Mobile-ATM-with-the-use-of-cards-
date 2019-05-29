using System.Collections.Generic;

namespace MobileATM_Library
{
    public class Client
    {
        private string name;
        private string surname;
        private List<Account> accountList;

        public string Name
        {
            get => name;

            private set => name = value;
        }

        public string Surname
        {
            get => surname;

            private set => surname = value;
        }

        public Client(string name, string surname)
        {
            accountList = new List<Account>();
            this.name = name;
            this.surname = surname;
        }

        public void addAccount() { }
    }
}