using System.Collections.Generic;
using Machine.Specifications;
using ProcedureGenerator.Core;
using ProcedureGenerator.Core.Domain;

namespace ProcedureGenerator.Tests.TableConcern
{
   [Subject("Using a table")]
   public class when_using :with_a_table
   {
      private Because of = () => { table = TableMother.GetTable(); };

      It gives_me_the_table_name = () => table.Name.ShouldEqual("Customer");

      It gives_me_the_primary_key = () => table.PrimaryKey.Name.ShouldEqual("CustomerId");

      It gives_me_a_list_of_columns = () => table.Columns.ShouldContainOnly(testColumns);

      It gives_me_a_list_of_columns_of_a_certain_type =
         () =>
         table.GetColumnsOfType(System.Data.SqlDbType.VarChar).ShouldContainOnly(new Column {Name = "CustomerName"});


      private static List<Column> testColumns = new List<Column>
                                                   {
                                                      new Column {Name = "CustomerId"},
                                                      new Column {Name = "CustomerName"}
                                                   };
   }
}