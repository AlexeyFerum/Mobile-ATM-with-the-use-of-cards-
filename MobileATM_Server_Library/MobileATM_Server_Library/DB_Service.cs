using System;
using System.Configuration;
using System.Data.Common;
using System.Collections.Generic;

namespace MobileATM_Server_Library
{
    class DB_Service
    {
        static private DbConnection connection;
        static private DbProviderFactory factory;

        public DB_Service()
        {
            string provider = ConfigurationManager.AppSettings["provider"];
            string connectionString = ConfigurationManager.AppSettings["connectionString"];
            factory = DbProviderFactories.GetFactory(provider);

            connection = factory.CreateConnection();
            if (connection == null)
            {
                Console.WriteLine("Connection error");
                Console.ReadLine();
                return;
            }

            connection.ConnectionString = connectionString;

            connection.Open();
            Console.WriteLine("Connection successfull");
        }

        private List<string> QueryDB(string query)
        {
            List<string> res = new List<string>();
            res = null;

            DbCommand command = factory.CreateCommand();

            if (command == null)
            {
                Console.WriteLine("Command error");
                Console.ReadLine();
                return null;
            }

            command.Connection = connection;
            command.CommandText = query;

            using (DbDataReader dataReader = command.ExecuteReader())
            {
                int i = 0;

                while (dataReader.Read())
                {
                    while (i < dataReader.FieldCount)
                    {
                        res.Add($"{dataReader[i]}");
                        i++;
                    }
                }
            }
            return res;
        }

        public string CheckClient(string number)
        {
            string command = "Select client_id from Client where account_id = " + $"{number}";
            if(QueryDB(command) != null)
            {
                return "Exist";
            }
            return "Doesn't exist";
        }

    }
}
