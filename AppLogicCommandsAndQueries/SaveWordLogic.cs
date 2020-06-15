using System;
using PersistanceLibrary;

namespace AppLogicCommandsAndQueries
{
    public class SaveWordLogic
    {
        public static void SaveWordOffline(string word, string definition = null)
        {
            SaveWord sw;
            try
            {
                sw = new SaveWord();
            }
            catch (Exception e)
            {
                throw new Exception("Could not open connection to offline database.", e);
            }

            bool successfulSave;
            using (sw)
            {
                successfulSave = sw.Save(word, definition);
            }

           if (!successfulSave)
           {
                throw new Exception($"Could not save word: {word}.");
           }
        }
    }
}
