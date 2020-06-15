using Domain;
using System;
using System.Data.SQLite;

namespace PersistanceLibrary
{
    public class SearchWord : IDisposable
    {
        private SQLiteConnection _connection;
        public SearchWord(string connectionString = "Data Source=OfflineDatabase.sqlite;")
        {
            _connection = new SQLiteConnection(connectionString);
            _connection.Open();
        }

        public void Dispose()
        {
            _connection.Close();
        }

        public bool SearchForWordOffline(string word)
        {
            using (SQLiteCommand cmd = new SQLiteCommand(_connection))
            {
                cmd.CommandText =
    $@"
    SELECT
        EXISTS
        (
            SELECT NULL
            FROM Word
            WHERE spelling = '{word}'
        )
";
                object result = cmd.ExecuteScalar();
                return Convert.ToBoolean(result);
            }
        }

        public Word GetWordOffline(string word)
        {
            using (SQLiteCommand cmd = new SQLiteCommand(_connection))
            {
                cmd.CommandText =
    $@"
    SELECT spelling, meaning
    FROM 
        Word
        LEFT JOIN Definition ON Word.wordId = Definition.wordId
    WHERE 
        spelling = '{word}'
";
                using (SQLiteDataReader result = cmd.ExecuteReader())
                {
                    if (result.HasRows && result.Read())
                    {
                        Word w = new Word(result.GetString(0));
                        if (!result.IsDBNull(1))
                            w.DefinitionList.Add(new Definition(result.GetString(1)));
                        // ignore entries with duplicate spellings for now
                        return w;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }
    }
}
