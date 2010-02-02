using Machine.Specifications;
using ProcedureGenerator.Core;
using ProcedureGenerator.Core.Domain;

namespace ProcedureGenerator.Tests.ColumnConcern
{
   public abstract class with_a_column
   {
      protected static Column column;
      Establish context = () =>
      {
         column = null;
      };
   }
}