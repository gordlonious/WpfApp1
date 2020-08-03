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

            bool wordAlreadySaved = SearchWordLogic.WordExistsOffline(word);
            bool definitionAlreadySavedOrIsNull = (!string.IsNullOrWhiteSpace(definition)) ? SearchDefinitionLogic.DefinitionExistsOffline(definition) : false;

            bool successfulSave;
            using (sw)
            {
                if (wordAlreadySaved && string.IsNullOrWhiteSpace(definition) || definitionAlreadySavedOrIsNull)
                {
                    return;
                }

                if (wordAlreadySaved && !definitionAlreadySavedOrIsNull && !string.IsNullOrWhiteSpace(definition))
                {
                    successfulSave = sw.AddDefinition(word, definition);
                }
                else
                {
                    successfulSave = sw.Save(word, definition);
                }
            }

           if (!successfulSave)
           {
                throw new Exception($"Could not save word: {word}.");
           }
        }
    }
}
