using System;
using System.Configuration;
using System.Data.Common;

namespace Connect
{
    class Program
    {
        static void Main(string[] args)
        {
            string provider = ConfigurationManager.AppSettings["provider"];
            string connectionString = ConfigurationManager.AppSettings["connectionString"];
            DbProviderFactory factory = DbProviderFactories.GetFactory(provider);

            using (DbConnection connection = factory.CreateConnection())
            {
                if (connection == null)
                {
                    Console.WriteLine("Connection error");
                    Console.ReadLine();
                    return;
                }

                connection.ConnectionString = connectionString;

                connection.Open();

                DbCommand command = factory.CreateCommand();

                if (command == null)
                {
                    Console.WriteLine("Command error");
                    Console.ReadLine();
                    return;
                }

                command.Connection = connection;

                command.CommandText = "Select * from ServiceStaff";

                using (DbDataReader dataReader = command.ExecuteReader())
                {
                    int i = 0;

                    while (dataReader.Read())
                    {
                        while (i < dataReader.FieldCount)
                        {
                            Console.WriteLine($"{dataReader[i]}");
                            i++;
                        }
                    }
                }

                connection.Close();
                Console.ReadKey();
            }
        }
    }
}
