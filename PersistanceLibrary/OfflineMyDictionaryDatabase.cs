using System.Data.SQLite;
using System.IO;

namespace PersistanceLibrary
{
  public static class OfflineMyDictionaryDatabase
  {
    private static SQLiteConnection dbConnecion = new SQLiteConnection("Data Source=MyDictionaryOfflineDatabase.sqlite;");
    public static void CreateDb()
    {
      // this should only happen once (during installation...)
      if (!File.Exists("MyDictionaryOfflineDatabase.sqlite"))
      {
        SQLiteConnection.CreateFile("MyDictionaryOfflineDatabase.sqlite");
        CreateSchema();
      }
    }

    private static void CreateSchema()
    {
      dbConnecion.Open();
      string definitionsql = 
        @"CREATE TABLE Definition 
        (
            definitionId INTEGER PRIMARY KEY,
            wordId INTEGER,
            meaning VARCHAR(300),
            FOREIGN KEY(wordId) REFERENCES Word(wordId)
        );";
      string wordsql =
        @"CREATE TABLE Word 
        (
            wordId INTEGER PRIMARY KEY,
            spelling VARCHAR(90)
        );";
      SQLiteCommand createDefinitionCommand = new SQLiteCommand(definitionsql, dbConnecion);
      SQLiteCommand createWordCommand = new SQLiteCommand(wordsql, dbConnecion);
      createDefinitionCommand.ExecuteNonQuery();
      createWordCommand.ExecuteNonQuery();
      dbConnecion.Close();
    }
  }
}