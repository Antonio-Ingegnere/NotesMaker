using System;
using System.Collections.Generic;

namespace NotesMaker
{
   class ProcessorCarer
   {
      private readonly IDictionary<Type, IProcessor> _processors;

      public ProcessorCarer()
      {
         _processors = new Dictionary<Type, IProcessor>();
      }

      public void Register<T>()
         where T : IProcessor, new()
      {
         _processors[typeof(T)] = new T();
      }

      public T Get<T>()
      {
         return (T)_processors[typeof(T)];
      }
   }
}
