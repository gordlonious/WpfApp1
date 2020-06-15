using System.Collections.Generic;

namespace Domain
{
    public class Definition
    {
        public Definition(string definition)
        {
            Meaning = definition;
            Context = new List<string>();
        }
        public string Meaning { get; set; }
        public IList<string> Context { get; set; }
    }
}
