using System.Data;
using Machine.Specifications;

namespace ProcedureGenerator.Tests.ColumnConcern
{
   [Subject("Using a column")]
   public class when_reading : with_a_column
   {
      private Because of = () =>
      {
         column = ColumnMother.GetColumn();
      };

      private It gives_me_the_column_name = () => column.Name.ShouldEqual("CustomerId");
      private It gives_me_the_column_type = () => column.ColumnType.ShouldEqual(SqlDbType.Int);
   }
}