using System;
using System.Runtime.Serialization;

namespace ProcedureGenerator.Core.Exceptions
{
   [Serializable]
   public class UnMappedSqlTypeException : Exception
   {
      //
      // For guidelines regarding the creation of new exception types, see
      //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
      // and
      //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
      //

      public UnMappedSqlTypeException()
      {
      }

      public UnMappedSqlTypeException(string message) : base(message)
      {
      }

      public UnMappedSqlTypeException(string message, Exception inner) : base(message, inner)
      {
      }

      protected UnMappedSqlTypeException(
         SerializationInfo info,
         StreamingContext context) : base(info, context)
      {
      }
   }
}