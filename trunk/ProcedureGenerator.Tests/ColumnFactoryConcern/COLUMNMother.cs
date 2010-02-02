using ProcedureGenerator.Core;
using ProcedureGenerator.Core.DataAccess;

namespace ProcedureGenerator.Tests.ColumnFactoryConcern
{
   public class COLUMNMother
   {
      public static COLUMN GetCharColumn()
      {
         return new COLUMN(){COLUMN_NAME = "Test",DATA_TYPE = "char"};
      }
   }
}