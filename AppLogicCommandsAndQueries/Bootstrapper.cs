using PersistanceLibrary;

namespace AppLogicCommandsAndQueries
{
  public class Bootstrapper
  {
    public static void Bootstrap()
    {
      Bootstrapper.CreateOfflineDb();
      // what else would go here?
    }
    private static void CreateOfflineDb()
    {
      OfflineMyDictionaryDatabase.CreateDb();
    }
  }
}
