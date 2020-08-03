using System;
using System.Data.SQLite;

namespace PersistanceLibrary
{
    public class SearchDefinition : IDisposable
    {
        private SQLiteConnection _connection;
        public SearchDefinition(string connectionString = "Data Source=OfflineDatabase.sqlite;")
        {
            _connection = new SQLiteConnection(connectionString);
            _connection.Open();
        }
        public void Dispose()
        {
            _connection.Close();
            _connection.Dispose();
        }

        public bool SearchDefinitionOffline(string definition)
        {
            using (SQLiteCommand cmd = new SQLiteCommand(_connection))
            {
                cmd.CommandText =
$@"
SELECT
    EXISTS
    (
        SELECT NULL
        FROM Definition
        WHERE meaning = '{definition}'
    )
";
                object result = cmd.ExecuteScalar();
                bool definitionExists = Convert.ToBoolean(result);
                return definitionExists;
            }
        }
    }
}
