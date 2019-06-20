﻿using System.Collections.Generic;

namespace Domain
{
    public class Word
  {
    public Word(string word)
    {
      Spelling = word;
    }
    // private int Id; handling duplicate word entries in a dictionary?
    public string Spelling { get; set; }
    public IList<Definition> DefinitionList { get; set; }
  }
}
