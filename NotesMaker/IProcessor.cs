using System.Collections.Generic;

namespace NotesMaker
{
   interface IProcessor
   {
   }

   interface IProcessor<out T> : IProcessor 
   {
      IEnumerable<T> Process(string line);
   }
}
