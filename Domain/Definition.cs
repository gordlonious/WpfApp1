using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
  public class Definition
  {
    public string Meaning { get; set; }
    public IList<string> Context { get; set; }
  }
}
