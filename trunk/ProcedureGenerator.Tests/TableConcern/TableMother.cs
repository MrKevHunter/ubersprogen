using System.Collections.Generic;
using System.Data;
using ProcedureGenerator.Core;
using ProcedureGenerator.Core.Domain;

namespace ProcedureGenerator.Tests.TableConcern
{
   public static class TableMother
   {
      public static Table GetTable()
      {
         return new Table
                   {
                      Name = "Customer",
                      PrimaryKey = new Column {Name = "CustomerId"},
                      Columns =
                         new List<Column> {new Column {Name = "CustomerId",ColumnType =SqlDbType.Int}, new Column {Name = "CustomerName",ColumnType = SqlDbType.VarChar}}
                   };
      }
   }
}