using PersistanceLibrary;
using System;

namespace AppLogicCommandsAndQueries
{
    public class SearchDefinitionLogic
    {
        public static bool DefinitionExistsOffline(string definition)
        {
            if (definition == null)
                throw new Exception("Cannot search for NULL definition.");

            SearchDefinition sd;
            try
            {
                sd = new SearchDefinition();
            }
            catch (Exception e)
            {
                throw new Exception("Could not open connection to offline database.", e);
            }

            using (sd)
            {
                return sd.SearchDefinitionOffline(definition);
            }
        }
    }
}
