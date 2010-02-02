using System.Data;
using Machine.Specifications;
using ProcedureGenerator.Core;

namespace ProcedureGenerator.Tests.ColumnFactoryConcern
{
   [Subject("Creating a column")]
   public class when_creating : with_a_ColumnFactory
   {
      private Because of = () =>
      {
         factory = new ColumnFactory();
      };

      It knows_how_to_get_the_correct_sql_type_for_a_char = () => factory.BuildColumn(COLUMNMother.GetCharColumn()).ColumnType.ShouldEqual(SqlDbType.Char);

   }
}