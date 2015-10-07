using System;
using System.Collections.Generic;

namespace NotesMaker
{
   static class Utils
   {
      public static IEnumerable<string> GetSubstrings(this string line)
      {
         return line.Split(new[] { " ", "\t" }, StringSplitOptions.RemoveEmptyEntries);
      }

      public static int DevideRoundingUp(double x, double y)
      {
         var remainder = x % y;
         var value = x / y;
         return remainder > 0 ? value.To<int>() + 1 : value.To<int>();
      }

      public static T To<T>(this object value)
      {
         return (T)Convert.ChangeType(value, typeof(T));
      }

      public static void AddRange<T>(this Queue<T> queue, IEnumerable<T> itemsToAdd)
      {
         foreach(T item in itemsToAdd)
            queue.Enqueue(item);
      }

      public static void ForEach<T>(this IEnumerable<T> collection, Action<T> action)
      {
         foreach(var item in collection)
            action(item);
      }
   }
}