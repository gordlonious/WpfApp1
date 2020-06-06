using System;
using System.Data.SQLite;

namespace PersistanceLibrary
{
    public class SaveWord : IDisposable
    {
        private SQLiteConnection _connection;
        public SaveWord(string connectionString = "Data Source=OfflineDatabase.sqlite;")
        {
            _connection = new SQLiteConnection(connectionString);
            _connection.Open();
        }

        public void Dispose()
        {
            _connection.Close();
        }

        public bool Save(string word, string definition = null)
        {
            SQLiteCommand cmd = new SQLiteCommand(_connection);
            cmd.CommandText =
$@"
    INSERT INTO Word (spelling)
    VALUES ('{word}')
";
            int rowsAffected = cmd.ExecuteNonQuery();
            return rowsAffected > 0;
        }
    }
}
