using Domain;
using PersistanceLibrary;
using System;

namespace AppLogicCommandsAndQueries
{
    public class SearchWordLogic
    {
        public static bool WordExistsOffline(string word)
        {
            SearchWord sw;
            try
            {
                sw = new SearchWord();
            }
            catch (Exception e)
            {
                throw new Exception("Could not open connection to offline database.", e);
            }

            bool found;
            using(sw)
            {
                found = sw.SearchForWordOffline(word);
            }

            return found;
        }

        public static Word GetWord(string word)
        {
            SearchWord sw;
            try
            {
                sw = new SearchWord();
            }
            catch (Exception e)
            {
                throw new Exception("Could not open connection to offline database.", e);
            }

            Word w = sw.GetWordOffline(word);
            return w;
        }
    }
}
