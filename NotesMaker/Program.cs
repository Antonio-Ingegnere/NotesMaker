using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;

namespace NotesMaker
{
   class Program
   {
#if DEBUG
      static void Main()
      {
         var args = new[] { "hava_nagila" };
#endif

#if !DEBUG
      static void Main(string[] args)
      {
         if(args == null || args.Length == 0)
         {
            Console.WriteLine("Please, specify the input file name as the first parameter");
            Console.WriteLine("Please, specify the output file name as the second parameter (optional)");
            Console.WriteLine("Please, specify the amount of beats as the third parameter (optional, 4 by default)");

            return;
         }
#endif

         var allLengths = new Queue<int>();
         var allNotes = new Queue<string>();
         var carer = new ProcessorCarer();

         carer.Register<DigitProcessor>();
         carer.Register<NoteProcessor>();

         using(var reader = new StreamReader(args[0]))
         {
            string line;


            while((line = reader.ReadLine()) != null)
            {
               if(string.IsNullOrEmpty(line))
                  continue;

               if(char.IsLetter(line[0]))
               {
                  allNotes.AddRange(carer.Get<NoteProcessor>().Process(line));
               }
               else if(char.IsDigit(line[0]) || line.StartsWith("."))
               {
                  allLengths.AddRange(carer.Get<DigitProcessor>().Process(line));
               }
            }
         }

         Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));

         Stream outFile = null;
         try
         {
            if(args.Length > 2)
            {
               outFile = File.Create(args[1]);
               Trace.Listeners.Add(new TextWriterTraceListener(outFile));
            }

            Trace.Write("Notes:\n");
            Trace.Write(string.Join(", ", allNotes));

            Trace.Write("\nLengths: \n");
            Trace.Write(string.Join(", ", allLengths));
         }
         finally
         {
            if(outFile != null)
               outFile.Dispose();
         }

         Trace.Flush();
      }
   }
}
