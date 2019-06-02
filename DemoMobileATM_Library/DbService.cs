using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;

namespace DemoMobileATM_Library
{
    public class DB_Service
    {
        private static DbConnection _connection = null;
        private static DbProviderFactory _factory = null;

        public DB_Service()
        {
            var provider = ConfigurationManager.AppSettings["provider"];
            var connectionString = ConfigurationManager.AppSettings["connectionString"];
            _factory = DbProviderFactories.GetFactory(provider);

            _connection = _factory.CreateConnection();
            if (_connection == null)
                return;

            _connection.ConnectionString = connectionString;

            _connection.Open();
        }

        public List<string> GetDataList(string commandText)
        {
            var res = new List<string>();

            var command = _factory.CreateCommand();

            if (command == null)
            {
                return null;
            }

            command.Connection = _connection;
            command.CommandText = commandText;

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

        public void UpdateData(string commandText)
        {
            var command = _factory.CreateCommand();

            command.Connection = _connection;
            command.CommandText = commandText;
            command.ExecuteNonQuery();
        }
    }
}
