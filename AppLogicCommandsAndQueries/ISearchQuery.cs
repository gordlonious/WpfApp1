﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogicCommandsAndQueries
{
  public interface ISearchQuery
  {
    IQueryData Search();
  }
}
