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
            _connection.Dispose();
        }

        public bool Save(string word, string definition = null)
        {
            using (SQLiteCommand cmd = new SQLiteCommand(_connection))
            {
                cmd.CommandText =
$@"
INSERT INTO Word (spelling)
VALUES ('{word}');
";
                int wordRowsAffected = cmd.ExecuteNonQuery();

                cmd.CommandText =
$@"
SELECT last_insert_rowid();
";
                long wordId = (long)cmd.ExecuteScalar();

                cmd.CommandText =
$@"
INSERT INTO Definition (wordId, meaning)
VALUES ('{wordId}', '{definition}');
";

                int definitionRowsAffected = cmd.ExecuteNonQuery();
                return wordRowsAffected > 0 && definitionRowsAffected > 0;
            }
        }

        public bool AddDefinition(string word, string definition)
        {
            using (SQLiteCommand cmd = new SQLiteCommand(_connection))
            {
                cmd.CommandText =
$@"
SELECT wordId
FROM Word
WHERE spelling = '{word}'
";
                object result = cmd.ExecuteScalar();
                int wordId = Convert.ToInt32(result);

                cmd.CommandText =
$@"
INSERT INTO Definition (wordId, meaning)
VALUES ('{wordId}', '{definition}');
";

                int rowsInserted = cmd.ExecuteNonQuery();

                return rowsInserted > 0;
            }
        }
    }
}
