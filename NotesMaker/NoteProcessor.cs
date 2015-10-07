using System;
using System.Collections.Generic;

namespace NotesMaker
{
   class NoteProcessor : IProcessor<string>
   {
      private const string Prefix = "NOTE_";

      public IEnumerable<string> Process(string line)
      {
         return AddPrefixAndMakeUpperCase(line.GetSubstrings());
      }

      private IEnumerable<string> AddPrefixAndMakeUpperCase(IEnumerable<string> lines)
      {
         var items = new Queue<string>();

         lines.ForEach(item => 
            {
               var value = IsPause(item) ? "0" :
                  Prefix + item.ToUpper() + (ContainBeatInfo(item) ? string.Empty : "4");

               items.Enqueue(value);
            }
            );

         return items;
      }

      private bool IsPause(string line)
      {
         return line.ToUpper() == "P";
      }

      private bool ContainBeatInfo(string line)
      {
         return Char.IsDigit(line[line.Length - 1]);
      }
   }
}
