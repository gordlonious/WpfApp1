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
            _connection.Dispose();
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
                    Word w;
                    if (result.HasRows && result.Read())
                    {
                        w = new Word(result.GetString(0));
                        w.DefinitionList.Add(new Definition(result.GetString(1)));

                        while (result.Read())
                        {
                            w.DefinitionList.Add(new Definition(result.GetString(1)));
                        }

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
