using System.Configuration;
using System.Data.Common;

namespace MobileATM_Server_Library
{
    public class ConnectionHelper
    {
        public string GetDataFromDb(string commandText)
        {
            string provider = ConfigurationManager.AppSettings["provider"];
            string connectionString = ConfigurationManager.AppSettings["connectionString"];
            DbProviderFactory factory = DbProviderFactories.GetFactory(provider);

            using (DbConnection connection = factory.CreateConnection())
            {
                if (connection == null)
                    return "Connection error";

                connection.ConnectionString = connectionString;
                connection.Open();

                DbCommand command = factory.CreateCommand();
                if (command == null)
                    return "Command error";

                command.Connection = connection;
                command.CommandText = commandText;

                using (DbDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        return ($"{dataReader["name"]} ");
                    }
                }
            }

            return "Something went wrong";
        }
    }
}
