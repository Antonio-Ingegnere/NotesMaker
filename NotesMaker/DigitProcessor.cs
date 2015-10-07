using System.Collections.Generic;

namespace NotesMaker
{
   class DigitProcessor : IProcessor<int>
   {
      public IEnumerable<int> Process(string line)
      {
         return ConverToLengts(line.GetSubstrings());
      }

      private IEnumerable<int> ConverToLengts(IEnumerable<string> lines, int beats = 4)
      {
         var lenghts = new Queue<int>();

         foreach(var line in lines)
         {
            lenghts.Enqueue(Utils.DevideRoundingUp(beats, line.To<double>()));
         }

         return lenghts;
      }
   }
}
