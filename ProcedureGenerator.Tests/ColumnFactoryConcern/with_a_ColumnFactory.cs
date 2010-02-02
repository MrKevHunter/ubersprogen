using System.Data;
using Machine.Specifications;
using ProcedureGenerator.Core;

namespace ProcedureGenerator.Tests.ColumnFactoryConcern
{
   
   public abstract class with_a_ColumnFactory
   {
      protected static ColumnFactory factory;
      Establish context = () =>
      {
         factory = null;
      };

      
   }
}